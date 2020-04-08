using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VizMenu : MonoBehaviour {
    public void GoBack() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        DontDestroyOnLoad(this.gameObject);
    }
}
