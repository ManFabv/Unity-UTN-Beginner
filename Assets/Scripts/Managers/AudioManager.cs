using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private AudioMixerSnapshot GameplayAudioSnapShot;
    [SerializeField] private float SecondsToTransitionAudioSnapshot = 1;
#pragma warning enable 0649

    private void Awake()
    {
        Debug.LogError("LOADED");
        if (GameplayAudioSnapShot == null)
        {
            Debug.LogError("EL " + typeof(AudioMixerSnapshot) + " ES NULO EN " + nameof(GameplayAudioSnapShot));
        }
        else
        {
            StartCoroutine(TransitionToAudioSnapshot());
        }
    }

    private IEnumerator TransitionToAudioSnapshot()
    {
        yield return new WaitForEndOfFrame();
        GameplayAudioSnapShot.TransitionTo(SecondsToTransitionAudioSnapshot);
    }
}
