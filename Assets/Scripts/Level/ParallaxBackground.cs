using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float BackgroundOffsetVelocity = 0.11f;

    private Material cachedMaterial;

    private void Awake()
    {
        cachedMaterial = this.GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        cachedMaterial.mainTextureOffset += new Vector2(0, BackgroundOffsetVelocity * Time.deltaTime);
    }
}
