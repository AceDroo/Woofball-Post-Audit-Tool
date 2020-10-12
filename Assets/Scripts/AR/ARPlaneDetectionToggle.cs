using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class ARPlaneDetectionToggle : MonoBehaviour {
	private ARPlaneManager planeManager = null;
	
	[SerializeField]
	private Text toggleButtonText = null;

	private void Awake() {
		planeManager = GetComponent<ARPlaneManager>();
		if (toggleButtonText != null) {
			toggleButtonText.text = "Disable Plane Detection";
		}
	}
	public void togglePlaneDetection() {
		planeManager.enabled = !planeManager.enabled;
		Debug.Log(planeManager.enabled);
		string toggleButtonMessage = "";

		if (planeManager.enabled) {
			toggleButtonMessage = "Disable Plane Detection";
			SetAllPlanesActive(true);
		} else {
			toggleButtonMessage = "Enable Plane Detection";
			SetAllPlanesActive(false);
		}

		toggleButtonText.text = toggleButtonMessage;
	}

	private void SetAllPlanesActive(bool value) {
		foreach (var plane in planeManager.trackables) {
			plane.gameObject.SetActive(value);
		}
	}
}