using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Menu : MonoBehaviour {
    public static string path = "";
    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadFile() {
        // path = EditorUtility.OpenFilePanel("Viz: Load Audio File", "", "");
    }
}
