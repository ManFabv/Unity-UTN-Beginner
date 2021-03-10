using UnityEngine;

public class RotacionContinua : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float velocidadRotacionX;
    [SerializeField] private float velocidadRotacionY;
    [SerializeField] private float velocidadRotacionZ;
#pragma warning restore 0649

    private Transform cachedTransform;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
    }

    private void Update()
    {
        cachedTransform.Rotate(velocidadRotacionX * Time.deltaTime, velocidadRotacionY * Time.deltaTime, velocidadRotacionZ * Time.deltaTime, Space.Self);
    }
}
