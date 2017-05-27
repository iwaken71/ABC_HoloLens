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

//d	string name;

	void Awake(){
		//this.name = new StringReactiveProperty("");
	//	Debug.Log(this.name);
		distination = Vector3.zero;
	}

	// Use this for initialization
	void Start () {
		
		
	}

	void Update(){
		transform.forward = Vector3.Slerp(transform.forward, (transform.position - Camera.main.transform.position),Time.deltaTime*smooth);
		transform.position = Vector3.Lerp(transform.position,distination,Time.deltaTime*smooth);
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
