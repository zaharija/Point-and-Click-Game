using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueControler : MonoBehaviour
{
    public Text dialogueText, choiceOne, choiceTwo, choiceThree;
    public Button buttonOne, buttonTwo, buttonThree;

    public int index;

    void Awake() {
        index = 0;

        buttonOne.onClick.AddListener(oneClick);
        buttonTwo.onClick.AddListener(twoClick);
        buttonThree.onClick.AddListener(threeClick);

        dialogueText.text = "One hundred twenty one...\nOne hundred twenty two...";
        choiceOne.text = "Hello... what's going on?.";
        choiceTwo.text = "Are you all right?";
        choiceThree.text = "Hey, what are you counting.";
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                Disable();
            }
        }
    }

    public void Init() {
        gameObject.SetActive(true);
    }

    public void Disable() {
        index = 0;
        dialogueText.text = "One hundred twenty one...\nOne hundred twenty two...";
        choiceOne.text = "Hello... what's going on?.";
        choiceTwo.text = "Are you all right?";
        choiceThree.text = "Hey, what are you counting.";
        EnableButtons();
        gameObject.SetActive(false);
    }

    public void DisableButtons() {
        buttonTwo.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);
    }

    public void EnableButtons() {
        buttonTwo.gameObject.SetActive(true);
        buttonThree.gameObject.SetActive(true);
    }

    private void oneClick() {
        switch (index) {
            case 0:
                index = 1;
                dialogueText.text = "One hundred twenty three...\nOne hundred twenty five...";
                choiceOne.text = "Umm... Hello, can you hear me?";
                choiceTwo.text = "Do; do you wan't me to call someone?";
                choiceThree.text = "I think you've skipped one.";
                break;
            case 1:
                index = 3;
                dialogueText.text = "One hundred twenty six...";
                choiceOne.text = "-- End Conversation --";
                choiceTwo.text = "-- End Conversation --";
                choiceThree.text = "-- End Conversation --";
                DisableButtons();
                break;
            case 3:
                Disable();
                break;
        }
    }

    private void twoClick() {
        switch (index) {
            case 0:
                index = 1;
                dialogueText.text = "One hundred twenty three...\nOne hundred twenty five...";
                choiceOne.text = "Umm... Hello, can you hear me?";
                choiceTwo.text = "Do; do you wan't me to call someone?";
                choiceThree.text = "I think you've skipped one.";
                break;
            case 1:
                index = 3;
                dialogueText.text = "One hundred twenty six...";
                choiceOne.text = "-- End Conversation --";
                choiceTwo.text = "-- End Conversation --";
                choiceThree.text = "-- End Conversation --";
                DisableButtons();
                break;
            case 3:
                Disable();
                break;
        }
    }

    private void threeClick() {
        switch (index) {
            case 0:
                index = 1;
                dialogueText.text = "One hundred twenty three...\nOne hundred twenty five...";
                choiceOne.text = "Umm... Hello, can you hear me?";
                choiceTwo.text = "Do; do you wan't me to call someone?";
                choiceThree.text = "I think you've skipped one.";
                break;
            case 1:
                index = 3;
                dialogueText.text = "No I didn't.";
                choiceOne.text = "-- End Conversation --";
                choiceTwo.text = "-- End Conversation --";
                choiceThree.text = "-- End Conversation --";
                DisableButtons();
                break;
            case 3:
                Disable();
                break;
        }
    }
}
