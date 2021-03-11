using UnityEngine;

public class MovimientoContinuo : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float velocidadX;
    [SerializeField] private float velocidadY;
    [SerializeField] private float velocidadZ;
#pragma warning restore 0649

    private Transform cachedTransform;

    public void ChangeVelocity(float velX, float velY, float velZ)
    {
        velocidadX = velX;
        velocidadY = velY;
        velocidadZ = velZ;
    }

    public void ChangeVelocity(Vector3 vel)
    {
        ChangeVelocity(vel.x, vel.y, vel.z);
    }

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
    }

    private void Update()
    {
        cachedTransform.Translate(velocidadX * Time.deltaTime, velocidadY * Time.deltaTime, velocidadZ * Time.deltaTime);
    }
}
