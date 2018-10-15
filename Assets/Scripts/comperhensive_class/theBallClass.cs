using UnityEngine;
using System.Collections;

public class theBallClass : MonoBehaviour
{
	public float speedScale = 1.7f;		//the scale number of ball's speed
	public float speedLimit = 20f;		//the limit of ball's speed
	public float massAdded = 1f;		//how much mass to add when the ball eat a food
	public float scaleNum = 0.01f;		//how much scale to add when the ball's mass increase
	public float initialScale = 1f;		//equal to the ball's initial scale
	public float initialMass = 10f;		//equal to the ball's initial mass
	//Ball Increase Function,increase the localscale and mass of the ball
	public void TheBallIncrease(GameObject Ball)
	{
		Ball.GetComponent<Rigidbody2D> ().mass += this.massAdded;
	}
	//Decline the ball
	public void TheBallDecline(GameObject Ball)
	{
		Ball.GetComponent<Rigidbody2D> ().mass -= this.massAdded;
	}
	public Vector2 CalcSpeed()
	{
		Vector3 WorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 NewWorldPosition = new Vector2 (WorldPosition.x, WorldPosition.y);
		Vector2 BallPosition = new Vector2 (transform.position.x, transform.position.y);
		Vector2 Limited = Vector2.ClampMagnitude ((NewWorldPosition - BallPosition), this.speedLimit);
		return (Limited * this.speedScale / transform.localScale.x);
	}
}
