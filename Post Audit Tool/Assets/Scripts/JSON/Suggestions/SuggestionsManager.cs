using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuggestionsManager : MonoBehaviour {
    public Transform contentWindow;
	public GameObject recallText;

	public void Awake() {
		// Get JSONReader Component
		JSONReader reader = GetComponent<JSONReader>();

		// Read JSON data
		string json = reader.LoadJSON();
		
		// Get list of suggestions
		Suggestions suggestionsJson = JsonUtility.FromJson<Suggestions>(json);

		// If suggestions were found, fill content window with suggestions
		if (suggestionsJson != null) {
			Debug.Log(suggestionsJson);

			// Create text lines
			int i = 0;
			foreach(Suggestion suggestion in suggestionsJson.summaryReport) {
				GameObject SuggestText = Instantiate(recallText, contentWindow);
				SuggestText.GetComponent<Text>().text = "	" + suggestion.solution;
				SuggestText.transform.position += new Vector3(0, -32 * i, 0);
				i++;
			}
		}
	}
}
