using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (AudioSource))]
public class Audio : MonoBehaviour {
    // Start is called before the first frame update
    AudioSource _audiosource;
    public static float[] _samples = new float[512];
    public static float[] _freqBands = new float[8];
    public static float[] _freqBands32 = new float[32];

    /*void Start() {
        _audiosource = GetComponent<AudioSource>();
    }*/

    void Awake() {
        _audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        GetSpectrumAudioSource();
        // MakeFrequencyBands();
        MakeFrequencyBands32();
    }

    void GetSpectrumAudioSource() {
        _audiosource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands() {
        int count = 0;
 
        for (int i = 0; i < 8; i++) {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7) {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++) {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _freqBands[i] = average * 10;
        }
    }

    void MakeFrequencyBands32() {
        int count = 0;
        int sampleCount = 1;
        int power = 0;
        for (int i = 0; i < 32; i++) {
            float average = 0;
            if (i == 8 || i == 16 || i == 20 || i == 24 || i == 28) {
                power++;
                sampleCount = (int)Mathf.Pow(2, power);
                if (power == 3) {
                    sampleCount -= 2;
                }
            }

            for (int j = 0; j < sampleCount; j++) {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;
            _freqBands32[i] = average * 40;
        }
    }
}
