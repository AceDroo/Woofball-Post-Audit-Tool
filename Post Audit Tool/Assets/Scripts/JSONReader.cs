using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JSONReader : MonoBehaviour {
	public Transform contentWindow;
	public GameObject recallText;

    void Start() {
    	// Get file path
        string json = File.ReadAllText(Application.streamingAssetsPath + "/summary.json");
        Debug.Log(json);

    	// Get list of suggestions
        Suggestions suggestionsJson = JsonUtility.FromJson<Suggestions>(json);

        // If suggestions were found, fill content window with suggestions
        if (suggestionsJson != null) {
            Debug.Log(suggestionsJson);

        	// Create text lines
            int i = 0;
	        foreach(Suggestion suggestion in suggestionsJson.summaryReport) {
	        	GameObject SuggestText = Instantiate(recallText, contentWindow);
	        	SuggestText.GetComponent<Text>().text = "     " + suggestion.solution;
                SuggestText.transform.position += new Vector3(0, -30 * i, 0);
                i++;
	        }
        } else {
            Debug.Log("Error: Failed to load solution.json");
        }
    }
}