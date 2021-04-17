﻿using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    #pragma warning disable 0649
    // [SerializeField] private AudioSource MusicAudioSource;
    // [SerializeField] private AudioMixerSnapshot MainMenuAudioSnapshot;
    // [SerializeField] private AudioMixerSnapshot MuteAudioSnapShot;
    // [SerializeField] private float SecondsToTransition = 3;
    // [SerializeField] private float SecondsToTransitionAudioSnapshot = 1;
    [SerializeField] private string Menu_Level_Name = "Menu";
    [SerializeField] private UIAnimator LoaderScreen;
#pragma warning enable 0649

    private string sceneToLoad = string.Empty;
    
    private void Awake()
    {
        if(string.IsNullOrEmpty(Menu_Level_Name))
            Debug.LogError("EL " + typeof(string) + " ES NULO EN " + nameof(Menu_Level_Name));
        if(LoaderScreen == null)
            Debug.LogError("EL " + typeof(UIAnimator) + " ES NULO EN " + nameof(LoaderScreen));
        // if(MuteAudioSnapShot == null)
        //     Debug.LogError("EL " + typeof(AudioMixerSnapshot) + " ES NULO EN " + nameof(MuteAudioSnapShot));
        // if(MusicAudioSource == null)
        //     Debug.LogError("EL " + typeof(AudioSource) + " ES NULO EN " + nameof(MusicAudioSource));
        // if (MainMenuAudioSnapshot == null)
        // {
        //     Debug.LogError("EL " + typeof(AudioMixerSnapshot) + " ES NULO EN " + nameof(MainMenuAudioSnapshot));
        // }
        // else
        // {
        //     StartCoroutine(TransitionToAudioSnapshot(MainMenuAudioSnapshot));
        // }
    }
    
    // private IEnumerator TransitionToAudioSnapshot(AudioMixerSnapshot mixerSnapshot)
    // {
    //     yield return new WaitForEndOfFrame();
    //     MusicAudioSource.Play();
    //     yield return new WaitForEndOfFrame();
    //     mixerSnapshot.TransitionTo(SecondsToTransitionAudioSnapshot);
    // }
    
    public void ReturnToMainMenu()
    {
        // TransitionToMuteSnapshot();
        // FadeOutLoaderScreen();
        // Invoke("AppQuit", SecondsToTransition);
    }
    
    // private void TransitionToMuteSnapshot()
    // {
    //     StartCoroutine(TransitionToAudioSnapshot(MuteAudioSnapShot));
    // }

    // private void FadeOutLoaderScreen()
    // {
    //     LoaderScreen?.FadeOut();
    // }
    //
    // private void LoadScene()
    // {
    //     if (string.IsNullOrEmpty(sceneToLoad))
    //         Debug.LogError("NOT SPECIFIED SCENE TO LOAD ON " + nameof(sceneToLoad));
    //     else
    //         SceneManager.LoadScene(sceneToLoad);
    // }
}
