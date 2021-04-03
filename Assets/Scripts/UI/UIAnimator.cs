using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIAnimator : MonoBehaviour
{
    private enum UIAnimatorState 
    {
        None,
        FadeIn,
        FadeOut
    }

    [SerializeField] private UIAnimatorState InitialState = UIAnimatorState.None;
    
    private void Awake()
    {
        string tweenToExecute = string.Empty;
        if(InitialState != UIAnimatorState.None)
        {
            tweenToExecute = InitialState.ToString();
        }
        if(!string.IsNullOrEmpty(tweenToExecute))
        {
            Animator animator = this.GetComponent<Animator>();
            animator.SetTrigger(tweenToExecute);
        }
    }
}
