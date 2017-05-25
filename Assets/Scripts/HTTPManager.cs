using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTTPManager : SingletonMonoBehaviour<HTTPManager> {

	private void Awake ()
	{
		if (this != Instance) {
			Destroy (this);
			return;
		}
		DontDestroyOnLoad (this.gameObject);
	}
	public bool inLab;
	string url = "http://192.168.0.28:5001";
	string jsonData;
	DecodeData _decodeData;

	// Use this for initialization
	void Start ()
	{
		if (inLab) {
			url = "http://192.168.0.28:5001";
		} else {
			url = "http://131.112.51.42:5001";
		}
	}

	public DecodeData UploadPicture (Texture2D tex)
	{
		//StartCoroutine(Upload(tex));
		//Debug.Log(_decodeData.class_names[0]);
		return _decodeData;

	}

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

	IEnumerator Upload (Texture2D tex)
	{
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
			//エラー内容 -> www.error
			Debug.Log ("Post Failure");          
			Debug.Log (www.error);
		} else {
			//通信結果 -> www.text
			Debug.Log ("Post Success");
			DecodeData decodeData = JsonToDecodeData(www.text);
			GameManager.Instance.CastRay(decodeData);
		}
	}
	public DecodeData JsonToDecodeData (string json)
	{	
		DecodeData decodeData2 = LitJson.JsonMapper.ToObject<DecodeData>(json);
		return decodeData2;
	}


}
