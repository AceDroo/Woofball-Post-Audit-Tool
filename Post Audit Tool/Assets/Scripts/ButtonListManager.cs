using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListManager : MonoBehaviour {
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private int[] intArray;

    private static List<GameObject> buttons = new List<GameObject>();

    void GenerateList() {
    	if (buttons.Count > 0) {
    		foreach (GameObject button in buttons) {
    			Destroy(button.gameObject);
    		}

    		buttons.Clear();
    	}

    	foreach (int i in intArray) {
    		GameObject button = Instantiate(buttonTemplate) as GameObject;
    		button.SetActive(true);

    		button.GetComponent<ButtonListButton>().setText("Button #" + i);

    		button.transform.SetParent(buttonTemplate.transform.parent, false);
    	
    		buttons.Add(button.gameObject);
    	}
    }

    void Start() {
    	GenerateList();
    }
    public void buttonClicked(string text) {
    	Debug.Log(text);
    }
}
