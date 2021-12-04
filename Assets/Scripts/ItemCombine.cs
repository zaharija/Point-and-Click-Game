using UnityEngine;
using UnityEngine.EventSystems;

public class ItemCombine : MonoBehaviour, IPointerClickHandler
{
    public bool itemClicked;
    public TextController textController;
    public ItemCombine ic;

    public void Awake() {
        itemClicked = false;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Right) {
            if (itemClicked || ic.itemClicked) {
                SecondClick();
                itemClicked = false;
                ic.itemClicked = false;
            }
            else {
                FirstClick();
                itemClicked = true;
            }
        }
    }

    private void FirstClick() {
        string target = "FirstCombine";
        textController.generateText(target);
    }

    private void SecondClick() {
        string target = "SecondCombine";
        textController.generateText(target);
    }
}
