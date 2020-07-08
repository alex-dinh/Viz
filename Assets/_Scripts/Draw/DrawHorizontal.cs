using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHorizontal : MonoBehaviour {
    public GameObject shape;
    public float maxScale;
    Vector3 loc;
    GameObject[] bars = new GameObject[32];
    public void makeHorizontal(GameObject prefab, Vector3 location, int num_objects) {
        for (int i = -num_objects + 1; i < num_objects; i++) {
            float xPos = i;
            Vector3 newPos = location + new Vector3(xPos, 0, 0);
            GameObject go = Instantiate(prefab, newPos, prefab.transform.rotation);
            prefab.transform.localScale = new Vector3(1, 1, 1);
            prefab.transform.name = "Bar" + i;
            // animate scale
            go.AddComponent<ParamCube>();
            ParamCube p = go.GetComponent<ParamCube>();
            p.band = Mathf.Abs(i);
            p.scaleMultiplier = 25f;
            p.startScale = 1f;
            p.maxScale = 8f;
            
        }
    }

    public void Start() {
        loc = new Vector3(0, 0, 0);
        makeHorizontal(shape, loc, 32);
    }
}
