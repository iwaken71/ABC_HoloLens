using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.EventSystems;


public class GameManager : SingletonMonoBehaviour<GameManager>,IInputClickHandler{

	GameObject namePlatePrefab;
	Texture2D tex;

	void Awake ()
	{
		
	}
	void Start(){
		InputManager.Instance.PushFallbackInputHandler (gameObject);
		namePlatePrefab = Resources.Load("NamePlate") as GameObject;
		Debug.Log(namePlatePrefab);
	}
	public void OnInputClicked(InputClickedEventData eventData) {
        Process();
    }
    DecodeData data;

    void Process(){
		 tex =  WebCameraController.Instance.TakePicuture();
		 HTTPManager.Instance.UploadTexture(tex);
		//Debug.Log(data.class_names[0]);
    }

    public void CastRay (DecodeData data)
	{
		if (data.class_names.Length == 0) {
			return;
		}

		float x = (data.face_points [0] [0] + data.face_points [0] [2]) / 2.0f;

		float y = (data.face_points [0] [1] + data.face_points [0] [3]) / 2.0f;
		y = tex.height - y;
		Debug.Log("x:"+x+"y:"+y);

		Ray ray = Camera.main.ScreenPointToRay (new Vector3 (x, y, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 50)) {
			Debug.Log(hit.point);
			GameObject obj =  Instantiate(namePlatePrefab,hit.point,Quaternion.identity);
			obj.GetComponent<NamePlate>().SetName(data.class_names[0]);
		}


	}

    public void SetData (DecodeData data)
	{
		this.data = data;

	}

    void Update ()
	{
		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown (0)) {
			Process();
		}
		#endif
    }
	
}
