using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using B83.Win32;
using System.Collections;
using UnityEngine.Networking;

public class FileDragAndDrop : MonoBehaviour {
    List<string> log = new List<string>();
    public static string path = "";
    public AudioSource src;
    public AudioClip clip;
    private float progress;

    void OnEnable () {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable() {
        UnityDragAndDropHook.UninstallHook();
    }

    void OnFiles0(List<string> aFiles, POINT aPos) {
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.
        string str = "Dropped " + aFiles.Count + " files at: " + aPos + "\n\t" +
            aFiles.Aggregate((a, b) => a + "\n\t" + b);
        Debug.LogError(str);
        log.Add(str);
    }

    void OnFiles(List<string> aFiles, POINT aPos) {
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.
        // string str = "Dropped " + aFiles.Count + " files at: " + aPos + "\n\t" +
        //     aFiles.Aggregate((a, b) => a + "\n\t" + b);

        //string path = aFiles.Aggregate((a, b) => a + "\n\t" + b);
        string path = aFiles[0];
        PlaySong(path);

        Debug.LogError(path);
        log.Add(path);
    }

    public IEnumerator PlaySong(string path) {
        path = "file:///" + path;
        Debug.LogError("playing song...");

        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.MPEG);
        var loadingOp = www.SendWebRequest();


        while (!www.isDone) {
            progress = loadingOp.progress;
            yield return null;
        }

        progress = 1f;

        if (!string.IsNullOrEmpty(www.error)) {
            // error occurred
        }

        var audio = DownloadHandlerAudioClip.GetContent(www);
        src.PlayOneShot(audio);
    }

    private void OnGUI() {
        if (GUILayout.Button("clear log"))
            log.Clear();
        foreach (var s in log)
            GUILayout.Label(s);
    }
}
