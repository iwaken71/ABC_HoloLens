using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCameraController : MonoBehaviour {
	public int Width = 320;
	public int Height = 240;
	public int FPS = 30;
	WebCamTexture webcamTexture;
	Texture2D texture;
	Color32[] color32;
	//public GameObject panel;

	//GameObject cube,textMesh;




	public static WebCameraController Instance = null;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(this.gameObject);
		}
	}


	void Start () {
		WebCamDevice[] devices = WebCamTexture.devices;
		// display all cameras
		for (var i = 0; i < devices.Length; i++) {
			Debug.Log (devices [i].name);
		}
		webcamTexture = new WebCamTexture(devices[0].name,Width,Height,FPS);
		webcamTexture.Play();

	}



	public Texture2D TakePicuture(){

		Color32[] color32 = webcamTexture.GetPixels32();
        texture = new Texture2D(webcamTexture.width, webcamTexture.height,TextureFormat.RGB24,false);
        texture.SetPixels32(color32);
        texture.Apply();
		//StartCoroutine(TakePicuture2());
		return texture;
//		color32 = webcamTexture.GetPixels32();
//        texture = new Texture2D(webcamTexture.width, webcamTexture.height);
//        texture.SetPixels32(color32);
//        texture.Apply();
//
//        FaceCube(FaceDetect.Instance.GetFaceRect(texture));
//		panel.GetComponent<Renderer> ().material.mainTexture = (Texture)texture;
	}

	public IEnumerator TakePicuture2(){
		color32 = webcamTexture.GetPixels32();
        texture = new Texture2D(webcamTexture.width, webcamTexture.height,TextureFormat.RGB24,false);
        texture.SetPixels32(color32);
        texture.Apply();
		yield break; 
	}

	/*
	void FaceCube (Vector2 input)
	{
		if (input.x > 0.1f) {
			textMesh.SetActive (true);
		} else {
			textMesh.SetActive (false);
		}
		if(cube == null)
			return;
		if (input == Vector2.zero) {
			cube.SetActive(false);
		}
		float x = input.x/320f;
		float y = 1-(input.y/240f);
		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (x, y, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 1000)) {
			cube.SetActive (true);
			cube.transform.position = hit.point;
			cube.transform.forward = Camera.main.transform.forward;
		} else {
			cube.SetActive (false);
		}
	}
	*/




}