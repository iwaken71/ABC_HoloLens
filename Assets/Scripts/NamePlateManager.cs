using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePlateManager : SingletonMonoBehaviour<NamePlateManager> {

	Dictionary<string,NamePlate> plateDic;
	GameObject namePlatePrefab;


	void Awake ()
	{	
		namePlatePrefab = Resources.Load("NamePlate2") as GameObject;
		plateDic = new Dictionary<string,NamePlate>();
	}
	public void AddNamePlate (string input,Vector3 faceTopPos)
	{
		Vector3 upperHeadPos = FaceSize.UpperHeadPos(faceTopPos);
		if (plateDic.ContainsKey (input)) {
			plateDic[input].SetDistination( upperHeadPos);
		}else{
			GenerateNewPlate(input,upperHeadPos);
		}


	}

	void GenerateNewPlate (string name, Vector3 pos)
	{
		GameObject obj =  Instantiate(namePlatePrefab,pos,Quaternion.identity);
		NamePlate script =  obj.GetComponent<NamePlate>();
		script.SetName(name);
		script.SetDistination(pos);
		plateDic.Add(name,script);

	}


}
