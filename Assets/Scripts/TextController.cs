using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private string textLake;
    private string textHouse;
    private string textCamper;

    public GameObject player;
    private TextMesh playerMesh;

    void Start()
    {
        initiateText();
        playerMesh = player.GetComponentInChildren<TextMesh>();
    }

    public void generateText(string target) {
        switch(target) {
            case "LakeMesh(2)":
                StartCoroutine(generateText(2f, playerMesh, textLake));
                break;
            case "LakeMesh(1)":
                StartCoroutine(generateText(2f, playerMesh, textLake));
                break;
            case "CamperMesh":
                StartCoroutine(generateText(2f, playerMesh, textCamper));
                break;
            case "HouseMesh":
                StartCoroutine(generateText(2f, playerMesh, textHouse));
                break;
        }
    }

    private void initiateText() {
        textLake = "Misty as always.";
        textHouse = "Lights... someone must be home.";
        textCamper = "This rusty thing... Wonder who even owns it.";
    }

    IEnumerator generateText(float time, TextMesh textMesh, string text) {
        textMesh.text = text;
        yield return new WaitForSeconds(time);
        textMesh.text = "";
    }

}
