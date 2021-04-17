using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject.Destroy(other.gameObject);
    }
}
