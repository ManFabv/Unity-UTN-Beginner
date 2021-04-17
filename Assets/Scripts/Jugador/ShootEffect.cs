using UnityEngine;

public class ShootEffect : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject shootEffectGameObject;
#pragma warning restore 0649

    private Transform cachedTransform;
    private GameObject shootGOFX;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();

        if (shootEffectGameObject == null)
            Debug.LogError("EL " + typeof(GameObject) + " ES NULO EN " + nameof(shootEffectGameObject));
    }

    public void StartShootEffect(float tiempoDeBonus)
    {
        if (shootEffectGameObject != null)
        {
            if (shootGOFX == null)
            {
                shootGOFX = Instantiate(shootEffectGameObject, cachedTransform.position, cachedTransform.rotation);
                shootGOFX.transform.SetParent(cachedTransform);
            }
            Invoke("StopShootEffect", tiempoDeBonus);
        }
    }

    private void StopShootEffect()
    {
        if (shootGOFX != null)
        {
            GameObject.Destroy(shootGOFX);
        }
    }
}