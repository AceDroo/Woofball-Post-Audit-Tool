using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class JSONReader : MonoBehaviour {
    public string filename;
    private string json;

    // public string GetFilePath(string filename) {
    //     string filepath;
    //     #if UNITY_EDITOR
    //     filepath = Path.Combine(Application.streamingAssetsPath, filename + ".json");
    //     #elif UNITY_IOS
    //     filepath = Path.Combine(Application.streamingAssetsPath + "/Raw", filename + ".json");
    //     #elif UNITY_ANDROID
    //     filepath = Path.Combine(Application.streamingAssetsPath, filename + ".json");
    //     #endif

    //     return filepath;
    // }

    public string LoadJSON() {
        // Read in JSON data
        var jsonTextFile = Resources.Load<TextAsset>("Text/" + filename);
        json = jsonTextFile.text;

        // Return loaded JSON string
        return json;
    }
    // #if UNITY_ANDROID
    // IEnumerator AndroidLoadJSON(string jsonURL) {
    //     using (WWW reader = new WWW(jsonURL)) {
    //         yield return reader;
    //         json = reader.text;
    //     }
    // }
    // #endif
}