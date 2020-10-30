using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class LocationPermissionDialog : MonoBehaviour {
    const int dialogWidth = 300;
    const int dialogHeight = 100;
    private bool windowOpen = true;

    void DoMyWindow(int windowID) {
    	// Create Window
        GUI.Label(new Rect(10, 20, dialogWidth - 20, dialogHeight - 50), "Give permission to access current location?.");
        GUI.Button(new Rect(10, dialogHeight - 30, 100, 20), "No");
        if (GUI.Button(new Rect(dialogWidth - 110, dialogHeight - 30, 100, 20), "Yes")) {
            #if PLATFORM_ANDROID
            Permission.RequestUserPermission(Permission.FineLocation);
            #endif
            windowOpen = false;
        }
    }

    void OnGUI () {
    	// If window is open, show the request dialog
        if (windowOpen) {
            Rect rect = new Rect((Screen.width / 2) - (dialogWidth / 2), (Screen.height / 2) - (dialogHeight / 2), dialogWidth, dialogHeight);
            GUI.ModalWindow(0, rect, DoMyWindow, "Permissions Request Dialog");
        }
    }
}
