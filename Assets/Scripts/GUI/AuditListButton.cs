using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class AuditListButton : MonoBehaviour {
	private Audit myAudit;
	public Text myText;
	private AuditListManager auditListManager;

	void Awake()
	{
		auditListManager = FindObjectOfType<AuditListManager>();
	}

	public void SetAudit(Audit audit)
	{
		// Set audit
		myAudit = audit;
			
		// Set button text
		string auditText = "	Location: " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(audit.location.locale + ", " + audit.location.state + ", " + audit.location.country + "\n");
		auditText = auditText + "	Type: " + audit.auditType + "\n";
		auditText = auditText + "	Date: " + audit.date + "\n";
		auditText = auditText + "	Score: " + audit.score + "\n";

		myText.text = auditText;
	}

    public void OnClick() {
    	if (myAudit != null) {
    		auditListManager.SetSelectedAudit(myAudit);
    	}
    }
}
