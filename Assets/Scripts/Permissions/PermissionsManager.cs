using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class PermissionsManager : MonoBehaviour {
	GameObject dialog;

    void Start() {
    	// Obtain User Permission
        #if PLATFORM_ANDROID
    	if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite)) {
    		Permission.RequestUserPermission(Permission.ExternalStorageWrite);
    		dialog = new GameObject();
    	}
        #endif
    }

    void OnGUI() {
    	#if PLATFORM_ANDROID
    	if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite)) {
    		// User has denied permission to use camera. Display message
    		dialog.AddComponent<PermissionsRationaleDialog>();
    		return;
    	} else if (dialog != null) {
    		Destroy(dialog);
    	}
    	#endif
    }
}
