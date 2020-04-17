using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour {
    public Slider audioslider;
    public AudioSource src;

    public void Start() {
        src = GameObject.FindGameObjectWithTag("draggedfile").GetComponent<AudioSource>();
    }

    public void SetStartTime() {
        audioslider.maxValue = 1;
        audioslider.value = 0;
    }

    public void SetTime(float time) {
        audioslider.value = time;
    }

    public void ChangeAudioTime(float time) {
        if (src != null) {
            src.time = src.clip.length * time;
        }
    }
}
