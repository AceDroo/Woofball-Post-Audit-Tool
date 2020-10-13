using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARProgramManager : MonoBehaviour {
	public GameObject propsPanel;
    public GameObject optionsPanel;
    public GameObject settingsPanel;
    public GameObject suggestionsPanel;
    public GameObject propEditPanel;
    public Slider rotationSlider;
    public Slider scaleSlider;
    public ARSessionOrigin session;

    private ARObjectManager manager;

    void Start() {
        // If ARSessionOrigin is loaded, get ARObjectManager component
        if (session != null) {
            manager = session.GetComponent<ARObjectManager>();
        }
    }

    void Update() {
        if (manager.IsPropSelected()) {
            if (propEditPanel != null) {
                if (!settingsPanel.activeSelf && !suggestionsPanel.activeSelf && !propsPanel.activeSelf) {
                    bool isActive = propEditPanel.activeSelf;
                    propEditPanel.SetActive(!isActive);
                }
            }
        }
    }

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
    public void ScaleObject() {
        if (scaleSlider != null && manager != null) {
            // Get value of slider
            float val = scaleSlider.value;

            // Update scale
            manager.ScaleSelectedObject(val);
        }
    }
    public void RotateObject() {
        if (rotationSlider != null && manager != null) {
            // Get value of slider
            float val = rotationSlider.value;

            // Update rotation
            manager.RotateSelectedObject(val);            
        }
    }
}

// A minimum API level of 16 and target API level of 27 was used during testing for NativeToolkit