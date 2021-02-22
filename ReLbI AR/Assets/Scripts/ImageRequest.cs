using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ImageRequest : MonoBehaviour
{
    [SerializeField] MeshRenderer renderer;
    Material mat;
    [SerializeField] string imageLink;
    void Start()
    {
        StartCoroutine(GetRequest("http://ec2-35-158-150-126.eu-central-1.compute.amazonaws.com/next_bike_picture"));
        mat = renderer.material;
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
                imageLink =/*  (pages[page] + ":\nReceived: " + */webRequest.downloadHandler.text;
                imageLink = imageLink.Substring(14, imageLink.Length - 16);
                StartCoroutine(GetTexture());
            }
        }
    }

    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageLink);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            mat.mainTexture = myTexture;
        }
    }
}