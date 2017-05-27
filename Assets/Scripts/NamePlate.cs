using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UniRx;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour {

	[SerializeField]
	Text nameLabel,numberLabel;

	public float smooth = 5;

	Vector3 distination;
	Transform cameraTransform;

	[SerializeField] 

	public bool IsSmooth = true;

//d	string name;

	void Awake(){
		//this.name = new StringReactiveProperty("");
	//	Debug.Log(this.name);
		distination = Vector3.zero;
		cameraTransform = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		
		Time.fixedDeltaTime = 0.05f;
	}



	void FixedUpdate ()
	{
		if (IsSmooth) {
			transform.forward = Vector3.Slerp(transform.forward, transform.position - cameraTransform.position ,Time.fixedDeltaTime*smooth);
			transform.position = Vector3.Slerp( transform.position, distination,Time.fixedDeltaTime*smooth) ;
		} else {
			transform.forward = transform.position - cameraTransform.position;
			transform.position = distination;
		}
	}

	public void SetName(string input){
		//this.name = input;
		nameLabel.text = input;
		distination = transform.position;
	}

	public void SetDistination(Vector3 input){
		distination = input;
	}

	public void SetNumber(float number){
		numberLabel.text = (number).ToString ("f1")+"%";
	}
}
