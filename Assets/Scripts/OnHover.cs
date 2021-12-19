using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHover : MonoBehaviour
{
    public MouseBoxControler mbc;

    void OnMouseEnter() {
        string text = GetComponent<Text>().text;
        mbc.ShowMouseBox(text);
    }

    void OnMouseExit() {
        transform.GetChild(0).gameObject.SetActive(false);
        mbc.HideMouseBox();
    }
}
