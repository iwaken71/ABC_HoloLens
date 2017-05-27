using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UniRx;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour {

	[SerializeField]
	Text nameLabel;

	public float smooth = 5;

	Vector3 distination;
	Transform cameraTransform;

//d	string name;

	void Awake(){
		//this.name = new StringReactiveProperty("");
	//	Debug.Log(this.name);
		distination = Vector3.zero;
		cameraTransform = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		
		Time.fixedDeltaTime = 0.1f;
	}



	void FixedUpdate(){
		transform.forward = transform.position - cameraTransform.position;
		transform.position = distination;
	}

	public void SetName(string input){
		//this.name = input;
		nameLabel.text = input;
		distination = transform.position;
	}

	public void SetDistination(Vector3 input){
		distination = input;
	}
}
