using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPManager : SingletonMonoBehaviour<HTTPManager> {
	/*
	private void Awake ()
	{
		if (this != Instance) {
			Destroy (this);
			return;
		}
		DontDestroyOnLoad (this.gameObject);
	}*/
	public bool inLab;
	public string url = "http://192.168.0.28:5001";
	string jsonData;
	//DecodeData _decodeData;

	// Use this for initialization
	void Start ()
	{
		SetURL ();
	}
	/*
	public DecodeData UploadPicture (Texture2D tex)
	{
		//StartCoroutine(Upload(tex));
		//Debug.Log(_decodeData.class_names[0]);
		return _decodeData;

	}*/

	public void UploadTexture (Texture2D tex)
	{

		StartCoroutine(Upload(tex));
//		WWWForm form = new WWWForm();
//        form.AddField("myField", "myData");
//		byte[] bytes = tex.EncodeToPNG();
//		form.AddBinaryData ("file", bytes);
//		string s = "";
//		ObservableWWW.Post(url,form).Subscribe(resultText => {
//			Debug.Log(resultText);
//			DecodeData decodeData = JsonToDecodeData(resultText);
//			GameManager.Instance.CastRay(decodeData);
//		},error =>{
//			string s1 = "{ \"class_names\" : [\"iwasaki\"],\"face_points\": [[124,124,320,320]] } ";
//			DecodeData decodeData = JsonToDecodeData(s1);
//			GameManager.Instance.CastRay(decodeData);
//			//Debug.LogError("www Error:" + error);
//		});
	}

	IEnumerator Post (Texture2D tex)
	{
		UnityWebRequest request = new UnityWebRequest(url,"POST");
		byte[] bytes = tex.EncodeToPNG();
		//request.uploadedBytes = new UploadHandlerRaw(bytes
		request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bytes);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

		yield return request.Send();
 
		if (request.isError)
        {
			//エラー内容 -> www.error
			DebugTest.Instance.Log ("Post Failure");          
			Debug.Log (request.error);
			ChangeURL ();
        }
        else
        {
			//通信結果 -> www.text
			DebugTest.Instance.Log ("Post Success");
			FaceData decodeData = JsonToDecodeData(request.downloadHandler.text);
			GameManager.Instance.CastRay(decodeData);
        }
	}

	IEnumerator Upload (Texture2D tex)
	{
	//	UnityWebRequest request = new UnityWebRequest(url,"POST");
		WWWForm form = new WWWForm();
       	form.AddField("myField", "myData");

		byte[] bytes = tex.EncodeToPNG();
		//Object.Destroy(tex);

		form.AddBinaryData ("file", bytes);
		// 送信開始

		WWW www = new WWW(url,form);
		yield return www;
		//通信結果をLogで出す
		if (www.error != null) {
			
		} else {
			//通信結果 -> www.text
			DebugTest.Instance.Log ("Post Success");
			FaceData decodeData = JsonToDecodeData(www.text);
			GameManager.Instance.CastRay(decodeData);
		}
	}
	public FaceData JsonToDecodeData (string text)
	{	
		
		JSONObject json = new JSONObject (text);

		List<JSONObject> className = json.GetField ("class_names").list;
		if (className.Count == 0) {
			return new FaceData ();
		} else if (className [0].str == "") {
			return new FaceData ();
		} else {
			string name = className[0].str;
			DebugTest.Instance.Log(name);
			JSONObject face_points = json.GetField ("face_points")[0];
			Debug.Log(face_points);
			int x = (int)(face_points[0].n);
			int y = (int)(face_points[1].n);
			int x2 = (int)(face_points[2].n);
			int y2 = (int)(face_points[3].n);
			return new FaceData (name,x,y,x2,y2);

		}
	}

	void SetURL(){
		if (inLab) {
			url = "http://192.168.0.28:5001";
		} else {
			url = "http://131.112.51.42:5001";
		}
	}

	void ChangeURL(){
		inLab = !inLab;
		SetURL ();
	}


}
