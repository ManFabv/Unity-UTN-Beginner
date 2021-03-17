using UnityEngine;

public class DisparadorAutomatico : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject Prefab;
    [SerializeField] private float FireRate = 1;
    [SerializeField] private float VelocidadDisparo = 4;
    [SerializeField] private string tagToApplyDamage = "Untagged";
    [SerializeField] private Transform DisparoSpawnPoint;
#pragma warning restore 0649

    private Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
        InvokeRepeating("FireWeapon", FireRate, FireRate);
        
        if(DisparoSpawnPoint == null)
        {
            Debug.LogError("NO SE ASIGNO UN SPAWN POINT PARA EL DISPARO EN " + nameof(DisparoSpawnPoint) + ". USANDO ESTE OBJETO PARA INSTANCIAR");
            DisparoSpawnPoint = cachedTransform;
        }
        if(Prefab == null)
            Debug.LogError("NO SE ASIGNO UN OBJETO A LA PROPIEDAD " + nameof(Prefab));
    }

    private void FireWeapon()
    {
        if (Prefab != null)
        {
            GameObject weaponFire = Instantiate(Prefab, DisparoSpawnPoint.position, DisparoSpawnPoint.rotation);
            Dañador dañador = weaponFire.GetComponent<Dañador>();

            if(dañador != null)
                dañador.TagToApplyDamage(tagToApplyDamage);

            Bomba bomba = weaponFire.GetComponent<Bomba>();

            if(bomba != null)
                bomba.TagToApplyDamage(tagToApplyDamage);

            MovimientoContinuo movimientoContinuo = weaponFire.GetComponent<MovimientoContinuo>();

            if(movimientoContinuo != null)
                movimientoContinuo.ChangeVelocity(0, 0, VelocidadDisparo);
        }
    }
}
