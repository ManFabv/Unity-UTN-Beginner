using UnityEngine;

public class VelocidadPowerUp : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private int Bonus = 2;
    [SerializeField] private float DuracionDeBonus = 5;
#pragma warning restore 0649

    private void OnTriggerEnter(Collider other)
    {
        MovimientoPersonaje movimientoPersonaje = other.gameObject.GetComponent<MovimientoPersonaje>();

        if (movimientoPersonaje != null)
        {
            movimientoPersonaje.AplicarBonusVelocidad(Bonus, DuracionDeBonus);
            Destroy(this.gameObject);
        }
    }
}
