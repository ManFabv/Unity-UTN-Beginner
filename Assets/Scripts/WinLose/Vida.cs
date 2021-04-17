using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(MeshRenderer))]
public class Vida : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private int vida = 100;
    [SerializeField] private AudioSource cachedDamageAudioSource;
#pragma warning restore 0649

    private bool toBeDestroy = false;
    private MeshRenderer MeshRenderer;
    private bool dead = false;
    private Collider[] cachedColliders;
    
    public int MaxLife { get; private set; }
    public int CurrentVida => vida;

    private void Awake()
    {
        MaxLife = vida;
        cachedDamageAudioSource = this.GetComponent<AudioSource>();
        MeshRenderer = this.GetComponent<MeshRenderer>();

        cachedColliders = this.GetComponentsInChildren<Collider>();
    }

    private void Update()
    {
        if (!dead && vida <= 0 && toBeDestroy == false)
        {
            dead = true;
            toBeDestroy = true;
            SendMessage("Murio");
            StartCoroutine(DelayedDestroy());
        }
    }

    private IEnumerator DelayedDestroy()
    {
        MeshRenderer.enabled = false;
        DisableAllColliders();
        yield return new WaitForSeconds(0.75f);
        Destroy(this.gameObject);
    }

    private void DisableAllColliders()
    {
        if (cachedColliders != null)
        {
            foreach (Collider col in cachedColliders)
            {
                col.enabled = false;
            }
        }
    }

    public void CambiarVida(int nuevaVida)
    {
        vida = nuevaVida;
    }

    public void Dañar(int daño)
    {
        vida -= daño;

        cachedDamageAudioSource.Play();
        
        SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
    }

    public void SetVidaCero()
    {
        vida = 0;
    }
}