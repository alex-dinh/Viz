using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCircle : MonoBehaviour {
    public GameObject circle;
    public float maxScale;
    float radius = 8f;
    Vector3 loc;
    GameObject[] bars = new GameObject[32];
    float scale;

    public void instantiateInCircle(GameObject prefab, Vector3 location, int num_objects) {
        float angleSection = Mathf.PI * 2f / num_objects;
        for (int i = 0; i < num_objects; i++) {
            float angle = i * angleSection;
            Vector3 newPos = location + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Instantiate(prefab, newPos, prefab.transform.rotation);
            prefab.transform.localScale = new Vector3(1, 1, 1);
            prefab.transform.name = "CircleBar" + i;
        }
    }

    public void instantiate() {
        for (int i = 0; i < 32; i++) {
            GameObject _instanceSampleCube = (GameObject)Instantiate(circle);
            _instanceSampleCube.transform.position = this.transform.position;
            _instanceSampleCube.transform.parent = this.transform;
            _instanceSampleCube.transform.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            _instanceSampleCube.transform.position = Vector3.forward * 100;
            bars[i] = _instanceSampleCube;
        }
    }

    void Start() {
        circle = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // loc = GameObject.FindGameObjectWithTag("center").transform.position;
        loc = new Vector3(0, 0, 0); 
        instantiateInCircle(circle, loc, 32);
        // instantiate();
    }

    void Update() {
        //for (int i = 0; i < 31; i++) {
        //    scale = Mathf.Min(12, _scaleMultiplier);
        //    transform.localScale = new Vector3(transform.localScale.x, (Audio._freqBands32[_band] * scale) + _startScale, transform.localScale.z);
        //}
    }
}
