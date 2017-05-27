using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePlateManager : SingletonMonoBehaviour<NamePlateManager> {

	Dictionary<string,NamePlate> plateDic;
	GameObject namePlatePrefab;

	GameObject OneNamePlateObject;


	void Awake ()
	{	
		namePlatePrefab = Resources.Load("NamePlate2") as GameObject;
		plateDic = new Dictionary<string,NamePlate>();
		OneNamePlateObject = null;
	}
	public void AddNamePlate (string input,Vector3 faceTopPos)
	{
		Vector3 upperHeadPos = FaceSize.UpperHeadPos(faceTopPos);
		if (OneNamePlateObject != null) {
			
			UpdatePlateData(input,upperHeadPos);
		}else{
			GenerateNewPlate(input,upperHeadPos);
		}


	}

	void GenerateNewPlate (string name, Vector3 pos)
	{
		OneNamePlateObject = Instantiate(namePlatePrefab,pos,Quaternion.identity) as GameObject;
		NamePlate script =  OneNamePlateObject.GetComponent<NamePlate>();
		script.SetName(name);
		script.SetDistination(pos);
		//plateDic.Add(name,script);

	}

	void UpdatePlateData(string name,Vector3 pos){
		if(OneNamePlateObject == null)return;

		NamePlate script =  OneNamePlateObject.GetComponent<NamePlate>();
		script.SetName(name);
		script.SetDistination(pos);

	}


}
