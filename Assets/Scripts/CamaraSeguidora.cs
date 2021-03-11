using UnityEngine;

public class CamaraSeguidora : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private GameObject target;
#pragma warning restore 0649

    private Transform cachedTransform;
    private Transform cachedTargetTransform;
    private float yPosition;

    private void Awake()
    {
        cachedTransform = this.GetComponent<Transform>();
        yPosition = cachedTransform.position.y;
        cachedTransform.parent = null;

        if (target != null)
            cachedTargetTransform = target.GetComponent<Transform>();
        else
            Debug.LogError("NO SE ASIGNO UN OBJETO A SEGUIR EN " + nameof(target));
    }

    private void LateUpdate()
    {
        if (target != null)
            cachedTransform.position = new Vector3(cachedTargetTransform.position.x, yPosition, cachedTargetTransform.position.z);
    }
}
