﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SFB;

public class Menu : MonoBehaviour {
    public static string filepath = "";
    public AudioSource src;
    public AudioClip clip;
    public AudioSlider audioslider;
    private Vector3 tmpMousePosition;
    public static float time;
    public static bool loaded;

    public void Start() {
        src = gameObject.AddComponent<AudioSource>();
        src = GameObject.FindGameObjectWithTag("draggedfile").GetComponent<AudioSource>();
        audioslider.SetStartTime();
    }

    void Update() {
        if (loaded) {
            UpdateTime();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!src.isPlaying) {
                src.Play();
            } else {
                src.Pause();
            }
        }

    }
    void UpdateTime() {
        time = (float)(src.time / src.clip.length);
        audioslider.SetTime(time);
    }

    public void Play() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (!src.isPlaying) {
            src.Play();
        }
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadGroundBars() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCircle() {
        SceneManager.LoadScene(2);
    }

    public void LoadFloatingBars() {
        SceneManager.LoadScene(3);
    }

    public void Pause() {
        if (src.isPlaying) {
            src.Pause();
        }
    }

    public void LoadFile() {
        // path = "";
        // filepath = EditorUtility.OpenFilePanel("Viz: Load Audio File", "", "");
        filepath = StandaloneFileBrowser.OpenFilePanel("Viz: Load Audio File", "", "", false)[0];

        if (filepath.EndsWith(".mp3")) {
            StartCoroutine(PlayMP3(filepath));
        } else {
            StartCoroutine(PlayNonMP3(filepath));
        }
        
        if (src.isPlaying) {
            src.Stop();
        }
    }

    public void ChangeAudioTime(float time) {
        if (src != null) {
            src.time = src.clip.length * time;
        }
    }

    public IEnumerator PlayNonMP3(string path) {
        /* Play any non *.mp3 audio file */
        path = "file://" + path;

        // TODO: only support AIF, add WAV
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.AIFF);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            // yield break;
            Debug.LogError(www.error);
        }

        clip = DownloadHandlerAudioClip.GetContent(www);
        src.clip = clip;
        src.Play();
        loaded = true;
    }

    public IEnumerator PlayMP3(string path) {
        /* Play *.mp3 audio files */
        path = "file://" + path;
        WWW www = new WWW(path);
        yield return www;
        clip = NAudioPlayer.FromMp3Data(www.bytes);
        src.clip = clip;
        src.Play();
        loaded = true;
    }
}
