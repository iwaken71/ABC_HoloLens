using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	[SerializeField]
	RawImage rawImage;

	public void SetPicture(Texture input){
		rawImage.texture = input;
	}


}
