using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.EventSystems;

public class AirTapManager: MonoBehaviour, IInputClickHandler{

	void Start(){
		InputManager.Instance.PushFallbackInputHandler (gameObject);
	}
	public void OnInputClicked(InputClickedEventData eventData) {
        WebCameraController.Instance.TakePicuture();
    }

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			WebCameraController.Instance.TakePicuture();
		}
	}
}

