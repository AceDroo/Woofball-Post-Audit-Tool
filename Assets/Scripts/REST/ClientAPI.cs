using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ClientAPI : MonoBehaviour {
	public string url;

    private Request request;

    // JSON form
    public class AuditQuery {
        public string token;
    }

	void Start() {
		GetAllAuditsRequest();
	}

    public Request GetAllAuditsRequest() {
        // Perform post co-routine
        if (request == null) {
            StartCoroutine(Post(url));
        }
        return request;
    }

    public IEnumerator Post(string url) {
        // Create audit query
        AuditQuery query = new AuditQuery();
        query.token = "mNV18ZeIzzN26LLGKxahDw";

        // Convert query into json to send
        string json = JsonUtility.ToJson(query);
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);

        // Send POST request
    	using (UnityWebRequest www = new UnityWebRequest(url, "POST")) {
            www.uploadHandler = (UploadHandler) new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

    		yield return www.SendWebRequest();

    		if (www.isNetworkError || www.isHttpError) {
    			Debug.Log("Error occured: " + www.error);
                Debug.Log(System.Text.Encoding.UTF8.GetString(www.downloadHandler.data));
    		} else {
    			if (www.isDone) {
    				// Handle the result
    				string result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    request = JsonUtility.FromJson<Request>(result);
                } else {
    				Debug.Log("Error! Data was unsuccessfully obtained");
    			}
    		}
    	}
    }
}