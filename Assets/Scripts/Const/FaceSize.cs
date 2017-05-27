using UnityEngine;
using System.Collections;

public class FaceSize {

	public const float Width = 0.16f;
	public const float Height = 0.23f;
	public const float Depth = 0.18f;


	public static Vector3 UpperHeadPos (Vector3 faceTopPos)
	{
		return faceTopPos + Vector3.up * Height + (faceTopPos-Camera.main.transform.position).normalized*Depth/2.0f;
		
	}
}
