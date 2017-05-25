using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
//using LitJson;

public class HTTPTest : MonoBehaviour
{

	public Texture2D texture;

	void Start ()
	{
		// IEnumeratorインターフェースを継承したメソッドは、StartCoroutineでコールする
		// StartCoroutine(Get("http://www.google.co.jp"));
		Post ("http://192.168.0.28:5001");  // 今回は失敗します // 外部の場合131.112.51.42
	}

	void Update ()
	{

	}

	//    IEnumerator Get (string url) {
	//        // HEADERはHashtableで記述
	//        Hashtable header = new Hashtable ();
	//        header.Add ("Accept-Language", "ja");
	//
	//        // 送信開始
	//        WWW www = new WWW (url, null, header);
	//        yield return www;
	//
	//        // 成功
	//        if (www.error == null) {
	//            Debug.Log("Get Success");
	//
	//            // 本来はサーバからのレスポンスとしてjsonを戻し、www.textを使用するが
	//            // 今回は便宜上、下記のjsonを使用する
	//            string txt = "{\"name\": \"okude\", \"level\": 99, \"friend_names\": [\"ichiro\", \"jiro\", \"saburo\"]}";
	//            // 自作したTestResponseクラスにレスポンスを格納する
	//            TestResponse response = JsonMapper.ToObject<TestResponse> (txt);
	//            Debug.Log("name: " + response.name);
	//            Debug.Log("level: " + response.level);
	//            Debug.Log("friend_names[0]: " + response.friend_names[0]);
	//            Debug.Log("friend_names[1]: " + response.friend_names[1]);
	//            Debug.Log("friend_names[2]: " + response.friend_names[2]);
	//        }
	//        // 失敗
	//        else{
	//            Debug.Log("Get Failure");
	//        }
	//    }

	void Post (string URL)
	{
		// HEADERはHashtableで記述
		Dictionary<string,string> header = new Dictionary<string,string> ();
		// jsonでリクエストを送るのへッダ例
		header.Add ("Content-Type", "charset=UTF-8");

		// LitJsonを使いJSONデータを生成
		// JsonData data = new JsonData();
		// data["hogehoge"] = 1;
		// シリアライズする(LitJson.JsonData→JSONテキスト)
		// string postJsonStr = data.ToJson();

		Color32[] a = texture.GetPixels32 ();
//			Texture2D a = new Texture2D(texture.width,texture.height,TextureFormat.RGB24,false);
//			a.SetPixels(texture.GetPixels());
//			//texture. = TextureFormat.RGB24;
//			byte[] bytes = a.EncodeToPNG();
		Debug.Log (a.Length);
		// 0~255
		byte[] bytes = new byte[a.Length * 3];
		Debug.Log (bytes.Length);
		int k = 0;
		for (int i = 0; i < a.Length; i++) {
			Color32 color32 = a [i];
			bytes [3 * i] = color32.b;
			bytes [3 * i + 1] = color32.g;
			bytes [3 * i + 2] = color32.r;
			//bytes [3 * i + 3] = color32.a;
			//Debug.Log(color32);
		}

		//byte[] postBytes = Encoding.Default.GetBytes (postJsonStr);
		WWWForm form = new WWWForm ();
		form.AddField ("pass", "abcde");
		form.AddBinaryData ("file", bytes, "sample.png,", "image/png");
		// 送信開始
		string url = URL;
		WWW www = new WWW (url,form);
		StartCoroutine(WaitForRequest(www));
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
			Debug.Log ("Post Success");
			Debug.Log (www.text);
		}
	}

}