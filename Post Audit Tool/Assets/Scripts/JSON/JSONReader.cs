using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONReader : MonoBehaviour {
    public string filename;

    private string filepath;
    private string json;

    #if UNITY_ANDROID
    private WWW reader;
    #endif

    public string LoadJSON() {
        // Get JSON file path
        #if UNITY_EDITOR
        filepath = Path.Combine(Application.streamingAssetsPath, filename + ".json");
        #elif UNITY_IOS
        filepath = Path.Combine(Application.streamingAssetsPath + "/Raw", filename + ".json");
        #elif UNITY_ANDROID
        filepath = Path.Combine(Application.streamingAssetsPath, filename + ".json");
        #endif

        // Read in JSON data
        #if UNITY_EDITOR || UNITY_IOS
        if (File.Exists(filepath)) {
            json = File.ReadAllText(filepath);
        }
        #elif UNITY_ANDROID
        if (filepath.Contains("://") || filepath.Contains(":///")) {
            StartCoroutine(AndroidLoadJSON(filepath));
            json = reader.text;
        }
        #endif

        Debug.Log(json);

        // Return loaded JSON string
        return json;
    }
    IEnumerator AndroidLoadJSON(string jsonURL) {
        reader = new WWW(jsonURL);

        yield return reader;
    }
}