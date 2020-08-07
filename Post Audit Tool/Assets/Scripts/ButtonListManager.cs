using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListManager : MonoBehaviour {
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private string[] objectsList;

    [SerializeField]
    private ARObjectManager objectManager;

    public static List<GameObject> buttons = new List<GameObject>();

    void GenerateList() {
    	if (buttons.Count > 0) {
    		foreach (GameObject button in buttons) {
    			Destroy(button.gameObject);
    		}

    		buttons.Clear();
    	}

    	foreach (string obj in objectsList) {
    		GameObject button = Instantiate(buttonTemplate) as GameObject;
    		button.SetActive(true);

    		button.GetComponent<ButtonListButton>().setText(obj);
    		button.transform.SetParent(buttonTemplate.transform.parent, false);

    		buttons.Add(button.gameObject);
    	}
    }

    void Start() {
    	GenerateList();
    }
    public void buttonClicked(string text) {
    	objectManager.ChangeSpawnType(text);
    }
}
