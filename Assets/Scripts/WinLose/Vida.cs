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

    private void Awake()
    {
        if(cachedDamageAudioSource == null)
            cachedDamageAudioSource = this.GetComponent<AudioSource>();
        MeshRenderer = this.GetComponent<MeshRenderer>();
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
        yield return new WaitForSeconds(0.75f);
        Destroy(this.gameObject);
    }

    public void CambiarVida(int nuevaVida)
    {
        vida = nuevaVida;
    }

    public void Dañar(int daño)
    {
        vida -= daño;

        cachedDamageAudioSource.Play();
        
        SendMessage("TakeDamage");
    }

    public void SetVidaCero()
    {
        vida = 0;
    }

    public int CurrentVida()
    {
        return vida;
    }
}