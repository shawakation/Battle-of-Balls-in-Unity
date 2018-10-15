using UnityEngine;
using System.Collections;
//this script attachs to the gameobject that persevers the min circle's central and position,max radius
public class surrondAllBalls : MonoBehaviour
{
	public theMinCircle myMinCircle;	//the gameobject with the min circle class
	public Sprite ballSprite;
	private float circleRadius;
	private float maxRadius;
	public float theRadius {
		get { return this.circleRadius + this.maxRadius; }
	}
	void Update()
	{
		myMinCircle.calculate ();
		Vector2 central = myMinCircle.circleCentral;
		this.transform.position = new Vector3 (central.x, central.y, 0f);
		circleRadius = (float)myMinCircle.circleRadius;
		maxRadius = (float)myMinCircle.maxRadius;
	}
}
