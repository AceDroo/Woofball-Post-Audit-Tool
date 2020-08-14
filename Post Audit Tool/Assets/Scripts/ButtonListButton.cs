using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour {
    [SerializeField]
    private Text myText;

    [SerializeField]
    private ButtonListManager manager;

    private string myTextString;

    public void setText(string text) {
        myText.text = text;
        myTextString = text;
    }

    public void OnClick() {
    	Debug.Log("Pressed " + myTextString);
    	manager.buttonClicked(myTextString);
    }
}
