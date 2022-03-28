using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadFunction : MonoBehaviour
{
    public void DownloadSprite(string url, Action<Sprite> callback)
    {

    }

    private IEnumerator SetSprite(GameObject obj, string uri)
    {
        if (uri.Contains("https://") || uri.Contains("http://"))
        {
            using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri))
            {
                yield return uwr.SendWebRequest();

                if (uwr.isNetworkError || uwr.isHttpError)
                {
                    //spawnObjImg.color = errorColor;
                    //spawnObjImg.sprite = errorSprite;
                    ReturnError(false, uwr.error);
                }
                else
                {
                    // TODO Set image
                    var texture = DownloadHandlerTexture.GetContent(uwr);
                    //if (obj != null)
                    //{
                    //    spawnObjImg.color = normalColor;
                    //    spawnObjImg.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    //    if (!isNormalColor) SetGrayScale(spawnObjImg);
                    //}
                }
            }
        }
        else
            ReturnError(true);

        void ReturnError(bool isWrongUri, string errorLog = "")
        {
            //spawnObjImg.color = errorColor;
            //spawnObjImg.sprite = errorSprite;
            Debug.Log($"{(isWrongUri ? "wrong" : "invalid")} link : {uri}\n{errorLog}");
        }
    }
}
