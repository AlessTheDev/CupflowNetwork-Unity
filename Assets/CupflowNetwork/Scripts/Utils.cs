using System;
using System.IO;
using UnityEngine.Networking;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CupflowNetwork
{
    public class Utils
    {
        public static int GetActivePort()
        {
            try
            {
                string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string fileContent = File.ReadAllText(Path.Combine(appDataDirectory, "CupflowNetwork", "port.txt"));
                return int.Parse(fileContent);
            }
            catch (IOException)
            {
                throw new CupflowNetworkNotOpenException("You must install/open the CupflowNetwork application");
            }
        }

        public static IEnumerator AssignUrlToImage(Image image, string mediaUrl)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                image.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            }

        }

    }


}

