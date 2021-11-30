using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject panel;
    private GameObject inventoryItems;

    private void Start()
    {
        Button inventoryButton = panel.transform.GetChild(0).gameObject.GetComponent<Button>();
        inventoryButton.onClick.AddListener(ToggleInventory);
        inventoryItems = panel.transform.GetChild(1).gameObject;
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
}
