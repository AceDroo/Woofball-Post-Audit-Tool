using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuditManager : MonoBehaviour
{
	private ClientAPI api;
	private Audit[] auditList = null;

    void Awake()
    {
		api = GetComponent<ClientAPI>();
    }

    public Audit[] GetAudits()
    {
        if (auditList == null) {
            StartCoroutine(SendAuditsRequest());
        }

        return auditList;
    }
    private IEnumerator SendAuditsRequest()
    {
    	Request request = api.GetAllAuditsRequest();
    	yield return new WaitForSeconds(1.0f);
    	auditList = request.body.auditsFound;
    }
}