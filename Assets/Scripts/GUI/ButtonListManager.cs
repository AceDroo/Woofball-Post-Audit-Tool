using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ButtonListManager : MonoBehaviour {
    [SerializeField]
    private GameObject buttonTemplate = null;

    [SerializeField]
    private ARObjectManager objectManager = null;
    
    public static List<GameObject> buttons = new List<GameObject>();

    void Awake() {
        if (buttonTemplate != null) {
            GenerateList();
        }
    }

    void GenerateList() {
        // Check if buttons have already been generated
        ClearButtonList();

        // Get JSONReader Component
        JSONReader reader = GetComponent<JSONReader>();

        // Read JSON data
        string jsonString = reader.LoadJSON();

        // Get list of props from JSON data
        Props propsJson = JsonUtility.FromJson<Props>(jsonString);

        // If propers were found, generate buttons using JSON data
        if (propsJson != null) {
            Debug.Log(propsJson);

            foreach(Prop prop in propsJson.propsList) {
                // Create button and set it to active
                GameObject button = Instantiate(buttonTemplate) as GameObject;
                button.SetActive(true);

                // Set button data
                button.GetComponent<ButtonListButton>().setProp(prop);
                button.transform.SetParent(buttonTemplate.transform.parent, false);

                // Add button to list of buttons
                buttons.Add(button.gameObject);
            }
        }
    }

    public void buttonClicked(string prefab) {
        objectManager.ChangeSpawnType(prefab);
    }

    private void ClearButtonList() {
        if (buttons.Count > 0) {
            // Destroy buttons in button list
            foreach (GameObject button in buttons) {
                Destroy(button.gameObject);
            }

            // Clear button list
            buttons.Clear();
        }
    }
}