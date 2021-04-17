using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private float MinTimeToChangeDirection = 1;
    [SerializeField] private float MaxTimeToChangeDirection = 3;
    [SerializeField] private float Velocity = 5;
#pragma warning restore 0649

    private float _velocity;
    private Transform cachedTransform;

    private void Awake()
    {
        _velocity = Velocity;
        cachedTransform = this.GetComponent<Transform>();
        Invoke("ChangeDirection", MaxTimeToChangeDirection);
    }

    private void Update()
    {
        cachedTransform.Translate(_velocity * Time.deltaTime, 0, 0);
    }

    public void ChangeVelocity(float newVelocity)
    {
        _velocity = newVelocity;
    }

    private void ChangeDirection()
    {
        _velocity *= -1;
        float timeToInvoke = Random.Range(MinTimeToChangeDirection, MaxTimeToChangeDirection);
        Invoke("ChangeDirection", timeToInvoke);
    }
}