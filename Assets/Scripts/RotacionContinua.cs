using UnityEngine;

public class RotacionContinua : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float velocidadRotacionX;
    [SerializeField] private float velocidadRotacionY;
    [SerializeField] private float velocidadRotacionZ;
#pragma warning restore 0649

    private Transform cachedTransform;

    public void ChangeVelocity(float velX, float velY, float velZ, bool allowOnlyOnY = true)
    {
        velocidadRotacionX = allowOnlyOnY ? 0 : velX;
        velocidadRotacionY = velY;
        velocidadRotacionZ = allowOnlyOnY ? 0 : velZ;
    }

    public void ChangeVelocity(Vector3 vel, bool allowOnlyOnY = true)
    {
        ChangeVelocity(vel.x, vel.y, vel.z, allowOnlyOnY);
    }

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
    }

    private void Update()
    {
        cachedTransform.Rotate(velocidadRotacionX * Time.deltaTime, velocidadRotacionY * Time.deltaTime, velocidadRotacionZ * Time.deltaTime);
    }
}
