using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARProgramManager : MonoBehaviour {
	public GameObject settingsPanel;

    public void OpenSettings() {
    	// Open the settings menu
    	if (settingsPanel != null) {
    		bool isActive = settingsPanel.activeSelf;
    		settingsPanel.SetActive(!isActive);
    	}

    	//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void TakeScreenshot() {
    	// Take a screenshot

    	Debug.Log("Screenshot taken!");
    }
}

// 3using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PanelOpener : MonoBehaviour {
// 	public GameObject Panel;
	
// 	public void OpenPanel() {
// 		if (Panel != null) {
// 			bool isActive = Panel.activeSelf;
// 			Panel.SetActive(!isActive);
// 		}
// 	}
// }