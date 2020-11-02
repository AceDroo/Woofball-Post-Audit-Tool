using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AuditListManager : MonoBehaviour 
{
    public AuditListButton buttonTemplate = null;
    public Transform contentWindow;
    public GameObject auditsFoundText;

    private ClientAPI api;
    private SuggestionsManager suggestionsManager;

    private Audit[] audits;
    private Audit selectedAudit;
    
    public static List<GameObject> buttons = new List<GameObject>();

    void Awake() 
    {
        api = GetComponent<ClientAPI>();
        suggestionsManager = GetComponent<SuggestionsManager>();

        if (buttonTemplate != null) 
        {
            GenerateList();
        }
    }

    public void GetAudits() {
        GenerateList();
    }

    public Audit GetSelectedAudit()
    {
        return selectedAudit;
    }

    public void SetSelectedAudit(Audit audit)
    {
        selectedAudit = audit;
        Debug.Log("Selected audit " + audit);
        suggestionsManager.UpdateSuggestions();
    }

    void GenerateList() 
    {
        // Check if buttons have already been generated
        ClearButtonList();

        // Get list of audits from API
        Request request = api.GetAllAuditsRequest();

        if (request != null)
        {
            Debug.Log(request);
            audits = request.body.auditsFound;

            auditsFoundText.SetActive(false);

            int i = 0;
            foreach (Audit audit in audits)
            {
                // Create button and set it to active
                AuditListButton button = Instantiate(buttonTemplate, contentWindow);
                button.gameObject.SetActive(true);
                button.SetAudit(audit);
                button.transform.position += new Vector3(0, -75.524f * i, 0);
                i++;

                // Add button to list of buttons
                buttons.Add(button.gameObject);
            }
        }
        else
        {
            auditsFoundText.SetActive(true);
        }
    }

    public void buttonClicked(string prefab) {
        //objectManager.ChangeSpawnType(prefab);
    }

    private void ClearButtonList() {
        if (buttons.Count > 0) {
            // Destroy buttons in button list
            foreach (GameObject button in buttons) {
                Destroy(button.gameObject);
            }

            // Clear button list
            buttons.Clear();
        }
    }
}