using UnityEngine;

public class Dañador : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private int Daño = 5;
#pragma warning restore 0649

    private void OnCollisionEnter(Collision other)
    {
        Vida vida = other.gameObject.GetComponent<Vida>();

        if (vida != null)
            vida.Dañar(Daño);

        Destroy(this.gameObject);
    }
}