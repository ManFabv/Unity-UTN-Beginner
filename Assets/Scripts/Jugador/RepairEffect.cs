using UnityEngine;

[RequireComponent(typeof(Vida))]
public class RepairEffect : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject repairEffectGameObject;
#pragma warning restore 0649

    private Transform cachedTransform;
    private GameObject repairGOFX;
    private Vida cachedVida;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
        cachedVida = this.GetComponent<Vida>();

        if (repairEffectGameObject == null)
            Debug.LogError("EL " + typeof(GameObject) + " ES NULO EN " + nameof(repairEffectGameObject));
    }

    public void StartRepairEffect(float tiempoDeBonus, int amoutHealth)
    {
        if (repairEffectGameObject != null)
        {
            if (repairGOFX == null)
            {
                repairGOFX = Instantiate(repairEffectGameObject, cachedTransform.position, cachedTransform.rotation);
                repairGOFX.transform.SetParent(cachedTransform);
            }
        }
        
        cachedVida.Curar(amoutHealth);
        Invoke("StopSpeedEffect", tiempoDeBonus);
    }
    
    private void StopSpeedEffect()
    {
        if (repairGOFX != null)
        {
            GameObject.Destroy(repairGOFX);
        }
    }
}
