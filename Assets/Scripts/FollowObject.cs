using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {


	public Transform parent;
	Vector3 relativePosition;

	// Use this for initialization
	void Start () {
		relativePosition = transform.position - parent.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 distination = parent.position;
		transform.position = Vector3.Lerp (transform.position,distination,Time.deltaTime*3);
		transform.forward = Camera.main.transform.forward;
		
	}
}
