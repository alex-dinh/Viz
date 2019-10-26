using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    // Start is called before the first frame update
    public int _band;
    public float _startScale, _scaleMultiplier;
    
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands32[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }
}
