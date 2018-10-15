using UnityEngine;
using System.Collections;

public class SecondCamera : MonoBehaviour
{
	public float InitialZPos;
	public Camera MainCamera;
	void Update()
	{
		Vector3 currentPos = this.transform.position;
		this.transform.position = new Vector3 (currentPos.x, currentPos.y, InitialZPos / MainCamera.GetComponent<CameraMove> ().cameraInitial * MainCamera.orthographicSize);
	}
}
