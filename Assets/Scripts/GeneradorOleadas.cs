using UnityEngine;

public class GeneradorOleadas : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject Prefab;
    [SerializeField] private float SpawnRate = 5;
    [SerializeField] private float MaxRandomVelocity = 10;
    [SerializeField] private float MaxRandomRotation = 120;
#pragma warning restore 0649

    private Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
        InvokeRepeating("InstanciarObjeto", SpawnRate, SpawnRate);

        if(Prefab == null)
            Debug.LogError("NO SE ASIGNO UN OBJETO A LA PROPIEDAD " + nameof(Prefab));
    }

    private void InstanciarObjeto()
    {
        if (Prefab != null)
        {
            GameObject go = Instantiate(Prefab, cachedTransform.position, cachedTransform.rotation);
            MovimientoContinuo movimientoContinuo = go.GetComponent<MovimientoContinuo>();
            RotacionContinua rotacionContinua = go.GetComponent<RotacionContinua>();

            if (movimientoContinuo != null)
            {
                Vector3 vel = GenerarVelocidadAleatoria(MaxRandomVelocity);
                movimientoContinuo.ChangeVelocity(vel);
            }

            if (rotacionContinua != null)
            {
                Vector3 vel = GenerarVelocidadAleatoria(MaxRandomRotation);
                rotacionContinua.ChangeVelocity(vel);
            }
        }
    }

    private Vector3 GenerarVelocidadAleatoria(float maxValue)
    {
        float x = Random.Range(-maxValue, maxValue);
        float y = Random.Range(-maxValue, maxValue);
        float z = Random.Range(-maxValue, maxValue);

        return new Vector3(x, y, z);
    }
}