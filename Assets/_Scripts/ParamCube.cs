using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    // Start is called before the first frame update
    public int band;
    public float startScale, scaleMultiplier;
    float scale;
    public float maxScale;
    
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        scale = Mathf.Min(maxScale, scaleMultiplier);
        transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands32[band] * scale) + startScale, transform.localScale.z);
    }
}
