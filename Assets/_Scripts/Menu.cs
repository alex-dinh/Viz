using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Networking;

public class Menu : MonoBehaviour {
    public static string path = "";
    public AudioSource src;
    public AudioClip clip;

    public void Awake() {
        src = gameObject.AddComponent<AudioSource>();
    }

    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadFile() {
        path = EditorUtility.OpenFilePanel("Viz: Load Audio File", "", "");
        // path = "";
        StartCoroutine(PlaySong2(path));
    }

    public IEnumerator PlaySong(string path) {
        /* Play anything non *.mp3 audio file */
        path = "file://" + path;

        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.AIFF);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.LogError(www.error);
        }

        AudioClip audio = DownloadHandlerAudioClip.GetContent(www);
        src.PlayOneShot(audio);
    }

    public IEnumerator PlaySong2(string path) {
        /* Play *.mp3 audio files */
        path = "file://" + path;

        WWW www = new WWW(path);
        yield return www;

        clip = NAudioPlayer.FromMp3Data(www.bytes);

        src.PlayOneShot(clip);
    }

}
