using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HideOnIdle : MonoBehaviour {
    public float idleTime = 1f;
    public UnityEvent OnIdleInputEvent;

    Vector3 m_oldInputPosition = Vector3.zero;
    float m_internalTimer = 0f;
    bool m_sentFlag = false;

    bool IsVectorEqual(Vector3 vec1, Vector3 vec2) {
        return (vec1.x == vec2.x && vec1.y == vec2.y && vec1.z == vec2.z);
    }

    void ShowButtons() {
        GameObject.FindGameObjectWithTag("button").transform.localScale = new Vector3(1, 1, 1);
        GameObject.FindGameObjectWithTag("playbutton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.FindGameObjectWithTag("pausebutton").transform.localScale = new Vector3(1, 1, 1);
        GameObject.FindGameObjectWithTag("audiotrack").transform.localScale = new Vector3(1, 1, 1);
    }

    void HideButtons() {
        GameObject.FindGameObjectWithTag("button").transform.localScale = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("playbutton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("pausebutton").transform.localScale = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("audiotrack").transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        // if mouse idle
        Vector2 mousePosition = Input.mousePosition;
        if (IsVectorEqual(m_oldInputPosition, mousePosition)) {
            m_internalTimer += Time.deltaTime;
            m_internalTimer = Mathf.Min(idleTime, m_internalTimer);
        }
        else {
            m_oldInputPosition = mousePosition;
            m_internalTimer = 0f;
            m_sentFlag = false;
            ShowButtons();
        }

        if (m_internalTimer == idleTime) {
            if (!m_sentFlag) {
                m_sentFlag = true;  // guard variable: send only once, until we move mouse again
                OnIdleInputEvent.Invoke();
                HideButtons();
            }
        }

    }
}
