using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mini "engine" for analyzing spectrum data
// Feel free to get fancy in here for more accurate visualizations!

public class AudioSpectrum : MonoBehaviour {
    // This value served to AudioSyncer for beat extraction
    public static float spectrumValue { get; private set; }

    // Unity fills this up for us
    private float[] m_audioSpectrum;

    // private void Update() {
    //    // get the data
    //    AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Hamming);

    //    // assign spectrum value
    //    // this "engine" focuses on the simplicity of other classes only..
    //    // ..needing to retrieve one value (spectrumValue)
    //    if (m_audioSpectrum != null && m_audioSpectrum.Length > 0) {
    //        spectrumValue = m_audioSpectrum[0] * 100;
    //    }
    // }

    void Update() {
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        for (int i = 1; i < spectrum.Length - 1; i++) {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        }
    }

    private void Start() {
        /// initialize buffer
        m_audioSpectrum = new float[128];
    }

}
