using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    // Start is called before the first frame update
    public int band;
    public float startScale, scaleMultiplier;
    float scale;
    public float maxScale;
    public Color[] beatColors = {Color.red, Color.yellow, Color.blue};
    public Color restColor = Color.green;
    Renderer rdr;

    void Start() {
        rdr = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        // transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        scale = Mathf.Min(maxScale, scaleMultiplier);
        transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands32[band] * scale) + startScale, transform.localScale.z);

        if (Audio._freqBands32[band] < 1) {
            rdr.material.SetColor("green", restColor);
        } else {
            rdr.material.SetColor("red", Color.red);
        }
     }
}
