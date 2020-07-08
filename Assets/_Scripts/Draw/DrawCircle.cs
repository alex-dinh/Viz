using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour {
    public GameObject shape;
    public float maxScale;
    float radius = 10f;
    Vector3 loc;
    float scale;

    // Make sure not to alter the prefab itself
    public void instantiateInCircle(GameObject prefab, Vector3 location, int num_objects) {
        GameObject go;
        
        // float angleSection = Mathf.PI * 2f / num_objects;
        float angleSection = Mathf.PI / num_objects;
        for (int i = -num_objects + 1; i < num_objects; i++) {
            float angle = i * angleSection - Mathf.PI/2; // radians
            Vector3 newPos = location + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            Vector3 rotation = new Vector3(0, 0, angle);
            go = Instantiate(prefab, newPos, prefab.transform.rotation);
            // go.transform.localScale = new Vector3(1, 1, 1);
            go.transform.name = "CircleBar" + i;
            // go.transform.Rotate(new Vector3(0, 0, -90)); // d    egrees
            go.transform.Rotate(new Vector3(0, 0, angle * 180 / Mathf.PI + 90)); // degrees

            // assign paramcube inspector values
            go.AddComponent<ParamCube>();
            ParamCube p = go.GetComponent<ParamCube>();
            p.band = Mathf.Abs(i);
            p.scaleMultiplier = 25;
            p.startScale = 1;
            p.maxScale = maxScale;
        }
    }


    void Start() {
        // shape = GameObject.CreatePrimitive(PrimitiveType.Cube);
        loc = new Vector3(0, 0, 0);
        instantiateInCircle(shape, loc, 32);
    }

}
