using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamePlateManager : SingletonMonoBehaviour<NamePlateManager> {

	Dictionary<string,NamePlate> plateDic;
	GameObject namePlatePrefab;

	GameObject OneNamePlateObject;
	bool OnPlate = false;


	void Awake ()
	{	
		namePlatePrefab = Resources.Load("NamePlate2") as GameObject;
		plateDic = new Dictionary<string,NamePlate>();
		OneNamePlateObject = null;
	}
	public void AddNamePlate (FaceData data, Vector3 faceTopPos)
	{
		Vector3 upperHeadPos = FaceSize.UpperHeadPos (faceTopPos);
		if (OnPlate) {
			if (OneNamePlateObject != null) {
			
				UpdatePlateData (data, upperHeadPos);
				//SetNumber (data.Power);
			} else {
				GenerateNewPlate (data, upperHeadPos);
				//SetNumber (data.Power);
			}
		} else {
			if (plateDic.ContainsKey (data.name)) {
				UpdatePlateData (data, upperHeadPos);
			} else {
				GenerateNewPlate (data, upperHeadPos);
			}
		}
	}

	void GenerateNewPlate (FaceData data, Vector3 pos)
	{
		if (OnPlate) {
			OneNamePlateObject = Instantiate (namePlatePrefab, pos, Quaternion.identity) as GameObject;
			NamePlate script = OneNamePlateObject.GetComponent<NamePlate> ();
			script.SetName (data.name);
			script.SetDistination (pos);
		} else {
			GameObject obj = Instantiate (namePlatePrefab, pos, Quaternion.identity) as GameObject;
			NamePlate script = obj.GetComponent<NamePlate> ();
			script.SetName (data.name);
			script.SetDistination (pos);
			script.SetNumber(data.Probability);
			//script.SetNumber(RandomNumber(530000));
			plateDic.Add(data.name,script);


		}
		//plateDic.Add(name,script);

	}

	void UpdatePlateData (FaceData data, Vector3 pos)
	{
		if (OnPlate) {
			if (OneNamePlateObject == null)
				return;

			NamePlate script = OneNamePlateObject.GetComponent<NamePlate> ();
			script.SetName (data.name);
			script.SetDistination (pos);
		} else {
			NamePlate script =  plateDic[data.name];
			script.SetDistination(pos);
			script.SetNumber(data.Probability);
		}

	}

	void SetNumber (string name,float power)
	{
		if (OneNamePlateObject != null) {
			OneNamePlateObject.GetComponent<NamePlate>().SetNumber(power);
		}
	}

	float RandomNumber (int max)
	{	
		float sum = 0;
		float N = 5;
		for (int i = 0; i < N; i++) {
			sum += Random.Range(0,max+1);
		}
		return sum/N;
	}

}
