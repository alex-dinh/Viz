﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Networking;

public class Menu : MonoBehaviour {
    public static string filepath = "";
    public AudioSource src;
    public AudioClip clip;

    public void Awake() {
        src = gameObject.AddComponent<AudioSource>();
    }

    public void Play() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (!src.isPlaying) {
            src.Play();
        }
    }

    public void Pause() {
        if (src.isPlaying) {
            src.Pause();
        }
    }

    public void LoadFile() {
        // path = "";
        filepath = EditorUtility.OpenFilePanel("Viz: Load Audio File", "", "");
        
        if (filepath.EndsWith(".mp3")) {
            StartCoroutine(PlayMP3(filepath));
        } else {
            StartCoroutine(PlayNonMP3(filepath));
        }
        
        if (src.isPlaying) {
            src.Stop();
        }
    }


    public IEnumerator PlayNonMP3(string path) {
        /* Play any non *.mp3 audio file */
        path = "file://" + path;

        // TODO: only support AIF, add WAV
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.AIFF);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.LogError(www.error);
        }

        clip = DownloadHandlerAudioClip.GetContent(www);
        src.clip = clip;
        src.Play();
    }

    public IEnumerator PlayMP3(string path) {
        /* Play *.mp3 audio files */
        path = "file://" + path;
        WWW www = new WWW(path);
        yield return www;
        clip = NAudioPlayer.FromMp3Data(www.bytes);
        src.clip = clip;
        src.Play();
    }

}
