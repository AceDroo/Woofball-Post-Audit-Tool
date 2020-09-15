using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void StartProgram() {
    	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitProgram() {
    	//if (Application.isEditor) {
    	//	EditorApplication.isPlaying = false;
    	//} else {
    		Application.Quit();
    	//}
    }
}