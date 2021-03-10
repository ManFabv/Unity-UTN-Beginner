using UnityEngine;

public class Bomba : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private string NombreAccion = "Explotar";
    [SerializeField] private bool Explotar = false;
    [SerializeField] private float TimeToExplode = 5;
#pragma warning restore 0649

    private void Awake()
    {
        Invoke("Explota", TimeToExplode);

        if(NombreAccion == null)
            Debug.LogError("NO SE ASIGNO UN NOMBRE A LA ACCION EN " + nameof(NombreAccion));
    }

    private void Update()
    {
        if (Input.GetButtonDown(NombreAccion))
        {
            Explotar = true;
        }
    }

    private void LateUpdate()
    {
        if(Explotar)
            Destroy(this.gameObject, 0.1f);
    }

    private void Explota()
    {
        Explotar = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Explotar)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}