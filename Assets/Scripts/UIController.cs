using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject panel;
    private GameObject inventoryItems;
    public TextController textController;

    private void Start()
    {
        Button inventoryButton = panel.transform.GetChild(0).gameObject.GetComponent<Button>();
        inventoryButton.onClick.AddListener(ToggleInventory);
        inventoryItems = panel.transform.GetChild(1).gameObject;

        Button bookButton = inventoryItems.transform.GetChild(0).GetComponent<Button>();
        Button gemButton = inventoryItems.transform.GetChild(1).GetComponent<Button>();
        bookButton.onClick.AddListener(BookClicked);
        gemButton.onClick.AddListener(GemClicked);

        inventoryItems.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                inventoryItems.SetActive(false);
            }
        }
    }

    private void ToggleInventory() {
        if(inventoryItems.activeSelf) {
            inventoryItems.SetActive(false);
        } else inventoryItems.SetActive(true);
    }

    private void BookClicked() {
        string target = "Book";
        textController.generateText(target);
    }

    private void GemClicked() {
        string target = "Gem";
        textController.generateText(target);
    }
}
