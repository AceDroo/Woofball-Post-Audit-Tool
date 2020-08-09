using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARObjectManager : MonoBehaviour {
	[SerializeField]
    private GameObject placedPrefab;

    public GameObject PlacedPrefab {
        get {
            return placedPrefab;
        }
        set {
            placedPrefab = value;
        }
    }

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private int maxPrefabSpawnCount = 0;
 	private int placedPrefabCount;

    //private bool onTouchHold = false;

    private List<PlacementObject> placedPrefabList = new List<PlacementObject>();

    private PlacementObject lastSelectedObject;

    private ARRaycastManager raycastManager;

    private bool prefabSelected = false;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public static ARObjectManager Instance { get; private set; }

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
        }

        // Save singleton instance
        Instance = this;

        // Set up raycast manager
        raycastManager = GetComponent<ARRaycastManager>();

        // Make sure we dont destroy between scenes
        DontDestroyOnLoad(gameObject);
    }
 
    void Update() {
    	// Check if the type of object to be placed is not equal to null
        if (placedPrefab == null) {
            return;
        }

        // Check if we're actually getting any inputs
        if (!getTouchPosition(out Vector2 touchPosition)) {
            return;
        }

        // Get selected objects
        getSelectedObjects();

        // Get raycast hits for the touch position
        if (raycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)) {
            // Get hit pose
            Pose hitPose = hits[0].pose;
            
            // If no object has been selected, create a new one
            if (lastSelectedObject == null) {
                if (prefabSelected) {
                    spawnObject(hitPose);
                }
            } else {
                // If an object has been selected, move its position
                // ChangeSelectedObject(placementObject);
                if (lastSelectedObject.isSelected) {
                    lastSelectedObject.transform.position = hitPose.position;
                    lastSelectedObject.transform.rotation = hitPose.rotation;
                }
            }
        }
    }

    private bool getTouchPosition(out Vector2 touchPosition) {
    	// If screen is getting touched, get position
        if (Input.touchCount > 0) {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    public void ChangeSpawnType(string name) {
        // Load type of object to spawn
        GameObject loadedObject = Resources.Load<GameObject>($"Prefabs/{name}");

        // Check if it is a valid object to spawn
        if (loadedObject != null) {
        	Debug.Log("Loaded prefab with name " + name);
            PlacedPrefab = loadedObject;
            prefabSelected = true;
        } else {
            Debug.Log("Failed to load prefab with name " + name);
        }
    }

    private void getSelectedObjects() {
    	// Get touch
    	Touch touch = Input.GetTouch(0);

    	// Check if at start of touch
        if (touch.phase == TouchPhase.Began) {
        	// Get Raycast and get hit object
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            RaycastHit hitObject;

            if (Physics.Raycast(ray, out hitObject)) {
                /* 
                if (hitObject.transform.name.Contains("PlacedObject")) {
                    onTouchHold = true;
                }
                */

                // Get last selected object
                lastSelectedObject = hitObject.transform.GetComponent<PlacementObject>();

                // Check if an object has been selected
                if (lastSelectedObject != null) {
                	// Get all placement objects
                    PlacementObject[] allOtherObjects = FindObjectsOfType<PlacementObject>();
                    
                    // Set selected objects
                    foreach (PlacementObject placementObject in allOtherObjects) {
                        placementObject.isSelected = (placementObject == lastSelectedObject);
                    }
                }
            }
        }

        // Deselect object if no longer touching
        if (touch.phase == TouchPhase.Ended) {
            lastSelectedObject.isSelected = false;
            // onTouchHold = false;
        }
    }

    private void spawnObject(Pose hitPose) {
    	// Create new object
    	Debug.Log("Created new " + placedPrefab);
        PlacementObject spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation).GetComponent<PlacementObject>();
        
        // Add object to placed object list
        placedPrefabList.Add(spawnedObject);
        placedPrefabCount++;

        // Set selected prefab as the newly spawned object
        lastSelectedObject = spawnedObject;
        prefabSelected = false;
    }

    /*
    private void ChangeSelectedObject(PlacementObject selected) {
        foreach (PlacementObject current in placedObjects) {
            if (selected != current) {
                current.isSelected = false;
                meshRenderer.material.color = inactiveColor;
            } else {
                current.isSelected = true;
                meshRenderer.material.color = activeColor;
            }
        }
    }*/
}
