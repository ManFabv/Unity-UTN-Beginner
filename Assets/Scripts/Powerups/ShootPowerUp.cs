using UnityEngine;

public class ShootPowerUp : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float DuracionDeBonus = 5;
    [SerializeField] private GameObject TakenEffect;
#pragma warning restore 0649

    private void OnTriggerEnter(Collider other)
    {
        ShootEffect shootEffect = other.gameObject.GetComponent<ShootEffect>();

        shootEffect?.StartShootEffect(DuracionDeBonus);
        
        if (TakenEffect != null)
        {
            Instantiate(TakenEffect, this.transform.position, this.transform.rotation);
        }

        Destroy(this.gameObject);
    }
}