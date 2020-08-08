using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARProgramManager : MonoBehaviour {
    public void GotoSettings() {
    	// Go to the settings menu
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void TakeScreenshot() {
    	// Take a screenshot

    	Debug.Log("Screenshot taken!");
    }
}