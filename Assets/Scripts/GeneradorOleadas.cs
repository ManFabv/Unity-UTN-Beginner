using UnityEngine;

public class GeneradorOleadas : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject Prefab;
    [SerializeField] private float SpawnRate = 5;
    [SerializeField] private float MaxRandomVelocity = 10;
    [SerializeField] private float MaxRandomRotation = 120;
    [SerializeField] private EnemyManager EnemyManager;
#pragma warning restore 0649

    private Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
        InvokeRepeating("InstanciarObjeto", SpawnRate, SpawnRate);

        if(EnemyManager == null)
            Debug.LogError("EL " + typeof(EnemyManager) + " ES NULO EN " + nameof(EnemyManager));
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
            Enemy enemyComponent = go.GetComponent<Enemy>();

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

            if(enemyComponent != null)
                enemyComponent.SetEnemyManager(EnemyManager);
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