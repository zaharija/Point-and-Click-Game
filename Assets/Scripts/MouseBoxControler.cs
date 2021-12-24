using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseBoxControler : MonoBehaviour
{
    [SerializeField]
    private Camera uiCamera;

    private Text text;
    private RectTransform background;

    void Awake() {
        text = GetComponentInChildren<Text>();
    }

    void Update() {
        Vector2 mp = Input.mousePosition;
        mp.x -= 1000;
        mp.y -= 410;
        transform.localPosition = mp;
    }

    public void ShowMouseBox(string highlight) {
        text.text = highlight;
        gameObject.SetActive(true);
    }

    public void HideMouseBox() {
        text.text = "";
        gameObject.SetActive(false);
    }
}
