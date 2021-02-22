using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class WebRequest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] int marginStart;
    [SerializeField] int marginEnd;

    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("http://ec2-35-158-150-126.eu-central-1.compute.amazonaws.com/next_bike_distance"));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split(char.Parse(":"));
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                textMesh.text =/*  (pages[page] + ":\nReceived: " + */webRequest.downloadHandler.text.Substring(marginStart, marginEnd) + "Km";
            }
        }
    }
}