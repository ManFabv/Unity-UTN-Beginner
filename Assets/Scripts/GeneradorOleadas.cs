using UnityEngine;

public class GeneradorOleadas : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject Prefab;
    [SerializeField] private float SpawnRate = 5;
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
        if(Prefab != null)
            Instantiate(Prefab, cachedTransform.position, cachedTransform.rotation);
    }
}