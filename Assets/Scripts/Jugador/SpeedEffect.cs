using UnityEngine;

public class SpeedEffect : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject speedEffectGameObject;
#pragma warning restore 0649

    private Transform cachedTransform;
    private GameObject speedGOFX;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();

        if (speedEffectGameObject == null)
            Debug.LogError("EL " + typeof(GameObject) + " ES NULO EN " + nameof(speedEffectGameObject));
    }

    public void StartSpeedEffect(float tiempoDeBonus)
    {
        if (speedEffectGameObject != null)
        {
            speedGOFX = Instantiate(speedEffectGameObject, cachedTransform.position, cachedTransform.rotation);
            speedGOFX.transform.SetParent(cachedTransform);
            Invoke("StopSpeedEffect", tiempoDeBonus);
        }
    }

    private void StopSpeedEffect()
    {
        if (speedGOFX != null)
        {
            GameObject.Destroy(speedGOFX);
        }
    }
}