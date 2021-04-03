using UnityEngine;

public class Bomba : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private string NombreAccion = "Explotar";
    [SerializeField] private bool Explotar = false;
    [SerializeField] private float TimeToExplode = 5;
#pragma warning restore 0649

    private string tagToApplyDamage = "Untagged";

    public void TagToApplyDamage(string tag)
    {
        if(string.IsNullOrEmpty(tag))
            Debug.LogError("NO HAY UN TAG SELECCIONADO EN " + nameof(tag) + ". USANDO POR DEFECTO UNTAGGED");
        else
            tagToApplyDamage = tag;
    }

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
            if(other.CompareTag(tagToApplyDamage))
            {
                Jugador jugador = other.gameObject.GetComponent<Jugador>();
                if(jugador != null)
                    jugador.Murio();

                Destroy(other.gameObject);
            }

            Destroy(this.gameObject);
        }
    }

    private void OnDisable()
    {
        Explotar = false;
        CancelInvoke("Explota");
    }
}