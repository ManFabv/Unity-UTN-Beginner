using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float SecondsToTransition = 3;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] private string Menu_Level_Name = "Menu";
    [SerializeField] private UIAnimator LoaderScreen;
    [SerializeField] private GameLevelManager GameManager;
#pragma warning restore 0649

    // private string sceneToLoad = string.Empty;
    
    private void Awake()
    {
        if(GameManager == null)
            Debug.LogError("EL " + typeof(GameLevelManager) + " ES NULO EN " + nameof(GameManager));
        if(string.IsNullOrEmpty(Menu_Level_Name))
            Debug.LogError("EL " + typeof(string) + " ES NULO EN " + nameof(Menu_Level_Name));
        if(LoaderScreen == null)
            Debug.LogError("EL " + typeof(UIAnimator) + " ES NULO EN " + nameof(LoaderScreen));
        if(AudioManager == null)
            Debug.LogError("EL " + typeof(AudioManager) + " ES NULO EN " + nameof(AudioManager));
    }
    
    public void ReturnToMainMenu()
    {
        AudioManager?.TransitionToMuteSnapshot();
        FadeOutLoaderScreen();
        GameManager?.LevelQuit();
        Invoke("LoadScene", SecondsToTransition);
    }

    private void FadeOutLoaderScreen()
    {
        LoaderScreen?.FadeOut();
    }
    
    private void LoadScene()
    {
        if (string.IsNullOrEmpty(Menu_Level_Name))
            Debug.LogError("NOT SPECIFIED SCENE TO LOAD ON " + nameof(Menu_Level_Name));
        else
            SceneManager.LoadScene(Menu_Level_Name);
    }
}
