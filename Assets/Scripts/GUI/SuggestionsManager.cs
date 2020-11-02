using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuggestionsManager : MonoBehaviour {
    public Transform contentWindow;
	public GameObject recallText;
	public GameObject auditSelectedText;
	public AuditListManager auditListManager;

	public void UpdateSuggestions()
	{
		if (auditListManager.GetSelectedAudit() == null)
		{
			auditSelectedText.SetActive(true);
		} 
		else 
		{
			auditSelectedText.SetActive(false);

			Suggestion[] suggestions = auditListManager.GetSelectedAudit().summaryReport;
			Debug.Log(suggestions);

			int i = 0;
			foreach (Suggestion suggestion in suggestions) {
				Debug.Log(suggestion.solution);
				GameObject SuggestText = Instantiate(recallText, contentWindow);
				SuggestText.SetActive(true);
				SuggestText.GetComponent<Text>().text = "	" + suggestion.solution;
				SuggestText.transform.position += new Vector3(0, -32 * i, 0);
				i++;
			}
		}
	}

	// public void Awake() {
	// 	Debug.Log("PrintOnEnable: script was enabled");
	// 	if (auditListManager.GetSelectedAudit() == null) {
	// 		Debug.Log("Failed to get audit");
	// 		auditSelectedText.SetActive(true);
	// 	} else {
	// 		auditSelectedText.SetActive(false);
	// 	}
		// Get JSONReader Component
		// JSONReader reader = GetComponent<JSONReader>();

		// // Read JSON data
		// string json = reader.LoadJSON();
		
		// // Get list of suggestions
		// Suggestions suggestionsJson = JsonUtility.FromJson<Suggestions>(json);

		// // If suggestions were found, fill content window with suggestions
		// if (suggestionsJson != null) {
		// 	Debug.Log(suggestionsJson);

		// 	// Create text lines
		// 	int i = 0;
		// 	foreach(Suggestion suggestion in suggestionsJson.summaryReport) {
		// 		GameObject SuggestText = Instantiate(recallText, contentWindow);
		// 		SuggestText.GetComponent<Text>().text = "	" + suggestion.solution;
		// 		SuggestText.transform.position += new Vector3(0, -32 * i, 0);
		// 		i++;
		// 	}
		// }
}