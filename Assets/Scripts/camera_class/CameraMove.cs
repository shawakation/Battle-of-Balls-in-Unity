using System.Collections;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public GameObject Target;		//the target is the gameobject which persevers the min circle
	public float cameraInitial = 20f;		//camera initial figure
	public float cameraScale = 0.005f;
	public PlayersController myController;
	public theBallClass myBallClass;
	void Update ()
	{
		if (!(myController.JudgeEmpty())) {
			this.transform.position = new Vector3 (Target.transform.position.x, Target.transform.position.y, -10f);
			Camera myCamera = GetComponent<Camera> ();
			float theMaxRadius = Target.GetComponent<surrondAllBalls> ().theRadius;
			if (myCamera.orthographicSize < theMaxRadius)
				myCamera.orthographicSize = theMaxRadius;
			else
				myCamera.orthographicSize = (theMaxRadius - myBallClass.initialScale) / myBallClass.scaleNum * this.cameraScale + this.cameraInitial;
		}
	}
}
