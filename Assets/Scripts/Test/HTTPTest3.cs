using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPTest3 : MonoBehaviour {
	public Texture2D texture;
	string url = "http://192.168.0.28:5001";
	void Start() {
      
    }

    void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			WebCameraController.Instance.TakePicuture();
			//texture = WebCameraController.Instance.texture;
			StartCoroutine(Upload());
		}

    }
 
    IEnumerator Upload() {
        WWWForm form = new WWWForm();
        form.AddField("myField", "myData");

        	//int width = texture.width;
        	//int height = texture.height;
        	//Texture2D tex = new Texture2D(width,height,TextureFormat.RGB24,false);
        	//tex = texture;
        	//tex.Apply();



		//Color32[] a = texture.GetPixels32 ();
//			Texture2D a = new Texture2D(texture.width,texture.height,TextureFormat.RGB24,false);
//			a.SetPixels(texture.GetPixels());
//			//texture. = TextureFormat.RGB24;
//			byte[] bytes = a.EncodeToPNG();
		byte[] bytes = new byte[1];
	//	Debug.Log(bytes.Length);
		//Object.Destroy(tex);
		form.AddBinaryData ("file", bytes);
		// 送信開始

		WWW www = new WWW(url,form);
		yield return www;
		//通信結果をLogで出す
		if (www.error != null) {
			//エラー内容 -> www.error
			Debug.Log ("Post Failure");          
			Debug.Log (www.error);
		} else {
			//通信結果 -> www.text
			Debug.Log ("Post Success");
			Debug.Log (www.text);
		}
    }

	//通信の処理待ち
	private IEnumerator WaitForRequest (WWW www)
	{
		yield return www;
		connectionEnd (www);
	}

	//通信終了後の処理
	private void connectionEnd (WWW www)
	{
		//通信結果をLogで出す
		if (www.error != null) {
			//エラー内容 -> www.error
			Debug.Log ("Post Failure");          
			Debug.Log (www.error);
		} else {
			//通信結果 -> www.text
//			Debug.Log ("Post Success");
//			Debug.Log (www.text);
//			LitJson.JsonData jsonData =  LitJson.JsonMapper.ToObject(www.text);
//			string message = (string)jsonData["class_names"][0];
//   			Debug.Log(message);
//			DecodeData decodeData = LitJson.JsonMapper.ToObject<DecodeData>(www.text);
//			Debug.Log(decodeData.face_points[0]);
		}
	}
}
