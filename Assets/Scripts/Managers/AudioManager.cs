using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private AudioMixerSnapshot GameplayAudioSnapShot;
    [SerializeField] private AudioMixerSnapshot MuteAudioSnapShot;
    [SerializeField] private AudioClip WinMusic;
    [SerializeField] private AudioClip LoseMusic;
    [SerializeField] private float SecondsToTransitionAudioSnapshot = 1;
#pragma warning enable 0649

    private AudioSource[] cachedAudiosources;

    private void Awake()
    {
        if(WinMusic == null)
            Debug.LogError("EL " + typeof(AudioClip) + " ES NULO EN " + nameof(WinMusic));
        if(LoseMusic == null)
            Debug.LogError("EL " + typeof(AudioClip) + " ES NULO EN " + nameof(LoseMusic));
        if(MuteAudioSnapShot == null)
            Debug.LogError("EL " + typeof(AudioMixerSnapshot) + " ES NULO EN " + nameof(MuteAudioSnapShot));
        if (GameplayAudioSnapShot == null)
        {
            Debug.LogError("EL " + typeof(AudioMixerSnapshot) + " ES NULO EN " + nameof(GameplayAudioSnapShot));
        }
        else
        {
            cachedAudiosources = this.GetComponents<AudioSource>();
            StartCoroutine(TransitionToAudioSnapshot(GameplayAudioSnapShot));
        }
    }

    private IEnumerator TransitionToAudioSnapshot(AudioMixerSnapshot mixerSnapshot)
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        PlayAllAudioSources();
        yield return new WaitForEndOfFrame();
        mixerSnapshot.TransitionTo(SecondsToTransitionAudioSnapshot);
    }

    private void PlayAllAudioSources()
    {
        if (cachedAudiosources != null)
        {
            foreach (AudioSource audioSource in cachedAudiosources)
            {
                audioSource.Play();
            }
        }
    }

    public void PlayWinMusic()
    {
        if(LoseMusic != null)
        {
            Debug.LogError("WIN MUSIC");
        }
    }

    public void PlayLoseMusic()
    {
        if(LoseMusic != null)
        {
            Debug.LogError("LOSE MUSIC");
        }
    }

    public void TransitionToMuteSnapshot()
    {
        StartCoroutine(TransitionToAudioSnapshot(MuteAudioSnapShot));
    }
}
