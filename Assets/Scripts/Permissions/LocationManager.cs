using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if PLATFORM_ANDROID
using UnityEngine.Android;
#endif

public class LocationManager : MonoBehaviour
{
	GameObject dialog;

    void Start()
    {
    	// Obtain User Permission
        #if PLATFORM_ANDROID
    	if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation)) {
    		Permission.RequestUserPermission(Permission.FineLocation);
    		dialog = new GameObject();
    	} else {
            StartCoroutine("FindLocation");
    	}
        #endif
    }

    void OnGUI() {
    	#if PLATFORM_ANDROID
    	if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation)) {
    		// User has denied permission to use camera. Display message
    		dialog.AddComponent<LocationPermissionDialog>();
    		return;
    	} else if (dialog != null) {
    		Destroy(dialog);
    	}
    	#endif
    }

    #if PLATFORM_ANDROID
    public void GetLocation() {
        StartCoroutine("FindLocation");
    }
    #endif

    #if PLATFORM_ANDROID
    IEnumerator FindLocation() 
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("Location service is disabled!");
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            float lat = Input.location.lastData.latitude;
            float lng = Input.location.lastData.longitude;
            float alt = Input.location.lastData.altitude;
            print("Location: " + lat + " " + lng + " " + alt + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }
    #endif
}