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
	public void AddNamePlate (FaceData data,Vector3 faceTopPos)
	{
		Vector3 upperHeadPos = FaceSize.UpperHeadPos(faceTopPos);
		if (OneNamePlateObject != null) {
			
			UpdatePlateData(data.name,upperHeadPos);
			SetNumber(data.Power);
		}else{
			GenerateNewPlate(data.name,upperHeadPos);
			SetNumber(data.Power);
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

	void SetNumber (float power)
	{
		if (OneNamePlateObject != null) {
			OneNamePlateObject.GetComponent<NamePlate>().SetNumber(power);
		}
	}

}
