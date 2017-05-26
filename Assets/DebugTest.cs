using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTest : SingletonMonoBehaviour<DebugTest> {

	public  bool isDebug = false;

	public Text Label;

	void Start(){
		Label.text = "";
	}

	public void Log(string s){
		if (isDebug) {
			Label.text = s;
		} else {
			Label.text = "";
		}
	}
}
