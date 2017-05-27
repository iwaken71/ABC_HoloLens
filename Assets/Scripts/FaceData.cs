using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceData{

	public string name;
	public int x,y; // 左上の座標
	public int x2,y2; //右下の座標
	public bool isEmpty;
	//public float Power=0;
	public float Probability = 0;

	public FaceData(string name,int x,int y,int x2,int y2){
		this.name = name;
		this.x = x;
		this.y = y;
		this.x2 = x2;
		this.y2 = y2;
		isEmpty = false;
		this.Probability = 100.0f;
	}

	public FaceData(string name,int x,int y,int x2,int y2,float Probability){
		this.name = name;
		this.x = x;
		this.y = y;
		this.x2 = x2;
		this.y2 = y2;
		isEmpty = false;
		this.Probability = Probability;
	}

	public FaceData(){
		this.name = "";
		this.x = 0;
		this.y=0;
		this.x2 = 0;
		this.y = 0;
		isEmpty = true;
		this.Probability = 0;
	}

	public void SetPower (float input)
	{
		Probability = input;
	}


}
