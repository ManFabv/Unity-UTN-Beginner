using UnityEngine;

public class RepairPowerUp : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private int Bonus = 20;
    [SerializeField] private GameObject TakenEffect;
#pragma warning restore 0649

    private void OnTriggerEnter(Collider other)
    {
        RepairEffect repairEffect = other.gameObject.GetComponent<RepairEffect>();

        repairEffect?.StartRepairEffect(Bonus);
        
        if (TakenEffect != null)
        {
            Instantiate(TakenEffect, this.transform.position, this.transform.rotation);
        }

        Destroy(this.gameObject);
    }
}