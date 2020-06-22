using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    // Start is called before the first frame update
    public int _band;
    public float _startScale, _scaleMultiplier;
    public float scale;
    
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        scale = Mathf.Min(12, _scaleMultiplier);
        transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands32[_band] * scale) + _startScale, transform.localScale.z);
    }
}
