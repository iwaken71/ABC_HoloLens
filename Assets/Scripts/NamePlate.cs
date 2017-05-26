using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UniRx;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour {

	[SerializeField]
	Text nameLabel;

//d	string name;

	void Awake(){
		//this.name = new StringReactiveProperty("");
	//	Debug.Log(this.name);
	}

	// Use this for initialization
	void Start () {
		
		
	}

	public void SetName(string input){
		//this.name = input;
		nameLabel.text = input;
	}
}
