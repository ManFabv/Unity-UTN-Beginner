using UnityEngine;

public class Disparador : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject Prefab;
    [SerializeField] private string NombreAccion;
    [SerializeField] private float FireRate = 1;
    [SerializeField] private string tagToApplyDamage = "Untagged";
#pragma warning restore 0649

    private Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();

        if(string.IsNullOrEmpty(NombreAccion))
            Debug.LogError("NO SE ASIGNO UN NOMBRE A LA ACCION EN " + nameof(NombreAccion));
        if(Prefab == null)
            Debug.LogError("NO SE ASIGNO UN OBJETO A LA PROPIEDAD " + nameof(Prefab));
    }

    private void Update()
    {
        if (Input.GetButtonDown(NombreAccion))
        {
            InvokeRepeating("FireWeapon", 0, FireRate);
        }

        if (Input.GetButtonUp(NombreAccion))
        {
            CancelInvoke("FireWeapon");
        }
    }

    private void FireWeapon()
    {
        if (Prefab != null)
        {
            GameObject weaponFire = Instantiate(Prefab, cachedTransform.position, cachedTransform.rotation);
            Dañador dañador = weaponFire.GetComponent<Dañador>();

            if(dañador != null)
                dañador.TagToApplyDamage(tagToApplyDamage);
        }
    }
}
