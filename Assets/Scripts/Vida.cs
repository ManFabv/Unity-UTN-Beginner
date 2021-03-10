using UnityEngine;

public class Vida : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private int vida = 100;
#pragma warning restore 0649

    private void Update()
    {
        if(vida <= 0)
            Destroy(this.gameObject);
    }

    public void Dañar(int daño)
    {
        vida -= daño;
    }
}