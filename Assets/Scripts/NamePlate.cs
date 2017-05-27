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
	Image plane,image;
	float defaultNameAlpha,defaultNumberAlpha,defaultPlaneAlpha,defaultImageAlpha;



	public bool IsSmooth = true;

	float timer = 0;
	float limit = 4;

//d	string name;

	void Awake(){
		//this.name = new StringReactiveProperty("");
	//	Debug.Log(this.name);
		distination = Vector3.zero;
		cameraTransform = Camera.main.transform;
		defaultNameAlpha = nameLabel.color.a;
		defaultNumberAlpha = numberLabel.color.a;
		defaultPlaneAlpha = plane.color.a;
		defaultImageAlpha = image.color.a;
	}

	// Use this for initialization
	void Start () {
		
		Time.fixedDeltaTime = 0.05f;
	}

	public void ResetAlpha(){
//		nameLabel.color = PlusAlpha (nameLabel.color,defaultNameAlpha);
//		numberLabel.color = PlusAlpha(numberLabel.color,defaultNumberAlpha);
//		plane.color = PlusAlpha (plane.color,defaultPlaneAlpha);
//		image.color = PlusAlpha(image.color,defaultImageAlpha);
		timer = 0;

	}

	Color PlusAlpha (Color c, float a)
	{
		return new Color(c.r,c.g,c.b,a);
	}

	void Update ()
	{
		SetUIColor ();
		if (timer <= limit) {
			timer += Time.deltaTime;

		}

	}

	void SetUIColor ()
	{
		nameLabel.color = Color.Lerp(PlusAlpha(nameLabel.color,defaultNameAlpha),PlusAlpha(nameLabel.color,0),timer/limit);
		numberLabel.color = Color.Lerp(PlusAlpha(numberLabel.color,defaultNumberAlpha),PlusAlpha(numberLabel.color,0),timer/limit);
		plane.color = Color.Lerp(PlusAlpha(plane.color,defaultPlaneAlpha),PlusAlpha(plane.color,0),timer/limit);
		image.color = Color.Lerp(PlusAlpha(image.color,defaultImageAlpha),PlusAlpha(image.color,0),timer/limit);
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
		ResetAlpha();
	}

	public void SetDistination(Vector3 input){
		distination = input;
		ResetAlpha();
	}

	public void SetNumber(float number){
		numberLabel.text = (number).ToString ("f1")+"%";
	}
}
