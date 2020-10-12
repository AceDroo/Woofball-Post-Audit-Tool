using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARProgramManager : MonoBehaviour {
	public GameObject propsPanel;
    public GameObject optionsPanel;
    public GameObject settingsPanel;
    public GameObject suggestionsPanel;

    public void OpenPropsManager() {
        // Open the props manager menu
        if (propsPanel != null) {
            if (!suggestionsPanel.activeSelf && !settingsPanel.activeSelf) {
                bool isActive = propsPanel.activeSelf;
                propsPanel.SetActive(!isActive);
            }
        }
    }
    public void OpenSettings() {
    	// Open the settings menu
    	if (settingsPanel != null) {
            if (!propsPanel.activeSelf && !suggestionsPanel.activeSelf) {
                bool isActive = settingsPanel.activeSelf;
                settingsPanel.SetActive(!isActive);
            }
    		
    	}
    }
    public void OpenSuggestions() {
        // Open the suggestions menu
        if (suggestionsPanel != null) {
            if (!propsPanel.activeSelf && !settingsPanel.activeSelf) {
                bool isActive = suggestionsPanel.activeSelf;
                suggestionsPanel.SetActive(!isActive);
            }
            
        }
    }
    public void TakeScreenshot() {
        // Hides the menus
        if (optionsPanel != null) optionsPanel.SetActive(false);
        if (propsPanel != null) propsPanel.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (suggestionsPanel != null) suggestionsPanel.SetActive(false);

    	// Take a screenshot
        NativeToolkit.SaveScreenshot("PostAudit", "Post Audit", "png");
        
        // Re-enable options panel
        optionsPanel.SetActive(true);
    }
}

// A minimum API level of 16 and target API level of 27 was used during testing for NativeToolkit