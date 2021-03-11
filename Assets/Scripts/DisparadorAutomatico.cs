using UnityEngine;

public class DisparadorAutomatico : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject Prefab;
    [SerializeField] private float FireRate = 1;
    [SerializeField] private string tagToApplyDamage = "Untagged";
#pragma warning restore 0649

    private Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
        InvokeRepeating("FireWeapon", FireRate, FireRate);

        if(Prefab == null)
            Debug.LogError("NO SE ASIGNO UN OBJETO A LA PROPIEDAD " + nameof(Prefab));
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
