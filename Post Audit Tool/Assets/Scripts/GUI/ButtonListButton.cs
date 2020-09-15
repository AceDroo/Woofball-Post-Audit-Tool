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
    private string myPrefab;

    public void setProp(Prop prop) {
        myText.text = prop.name;
        myTextString = prop.name;
        myPrefab = prop.prefab;
    }

    public void OnClick() {
    	Debug.Log("Pressed " + myTextString);
    	manager.buttonClicked(myPrefab);
    }
}
