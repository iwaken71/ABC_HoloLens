using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.EventSystems;


public class GameManager : SingletonMonoBehaviour<GameManager>,IInputClickHandler{

	Texture2D tex;


	void Start(){
		//InputManager.Instance.PushFallbackInputHandler (gameObject);

		InvokeRepeating ("Process", 3, 0.5f);
	}
	public void OnInputClicked(InputClickedEventData eventData) {
        Process();
    }
   // DecodeData data;

    void Process(){
		 tex =  WebCameraController.Instance.TakePicuture();
		// Debug.Log(tex.width+","+tex.height);
		 HTTPManager.Instance.UploadTexture(tex);
		//Debug.Log(data.class_names[0]);
    }

    public void CastRay (FaceData data)
	{
		if (data.isEmpty) {
			return;
		}

		float x = (data.x + data.x2 ) / 2.0f;

		float y = (data.y  + data.y2 ) / 2.0f;
		y = tex.height - y;
		Debug.Log("x:"+x+"y:"+y);

		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (x/tex.width, y/tex.height, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 50)) {
			Debug.Log(hit.point);
			NamePlateManager.Instance.AddNamePlate(data.name,hit.point);
		}


	}

//    public void SetData (DecodeData data)
//	{
//		this.data = data;
//
//	}

    void Update ()
	{
		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown (0)) {
			Process();
		}
		#endif
    }
	
}
