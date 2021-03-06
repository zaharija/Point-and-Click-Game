using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextController : MonoBehaviour
{
    private string textLake;
    private string textHouse;
    private string textCamper;
    private string textDoor;
    private string textBook;
    private string textGem;
    private string textFirstCombine;
    private string textSecondCombine;
    public DialogueControler dc;
    public AudioController ac;

    public GameObject player;
    private TextMesh playerMesh;

    public GameObject NPC;
    private TextMesh NPCMesh;

    void Start()
    {
        initiateText();
        playerMesh = player.GetComponentInChildren<TextMesh>();
        NPCMesh = NPC.GetComponentInChildren<TextMesh>();
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
            case "DoorMesh":
                ac.DoorOpenSound();
                StartCoroutine(generateText(2f, playerMesh, textDoor));
                break;
            case "Book":
                StartCoroutine(generateText(2f, playerMesh, textBook));
                break;
            case "Gem":
                StartCoroutine(generateText(2f, playerMesh, textGem));
                break;
            case "FirstCombine":
                StartCoroutine(generateText(2f, playerMesh, textFirstCombine));
                break;
            case "SecondCombine":
                StartCoroutine(generateText(2f, playerMesh, textSecondCombine));
                break;
            case "NPCMesh":
                 dc.Init();
                break;
        }
    }

    private void initiateText() {
        textLake = "Misty as always.";
        textHouse = "Lights... someone must be home.";
        textCamper = "This rusty thing... Wonder who even owns it.";
        textDoor = "Locked...";
        textBook = "\"Untitled\"... Hmm, a weird name for a book.";
        textGem = "Strange, I don't quite remember how I got this.";
        textFirstCombine = "How can I use this...";
        textSecondCombine = "Can't combine that.";
    }

    IEnumerator generateText(float time, TextMesh textMesh, string text) {
        textMesh.text = text;
        yield return new WaitForSeconds(time);
        textMesh.text = "";
    }

    private void Wait (float delay, UnityAction action){
        StartCoroutine(ExecuteAction(delay, action));
    }

    private IEnumerator ExecuteAction(float delay, UnityAction action) {
        yield return new WaitForSecondsRealtime(delay);
        action.Invoke();
        yield break;
    }

}
