using UnityEngine;
using System;

public class BallDivision : MonoBehaviour
{
	public AudioClip FenLieSound;		//the sound of ball's division
	public float NewBallSpeed;		//the speed of the new ball
	public float SpeedDelay;		//how long does the ball's speed recover
	public PlayersController theBalls;		//the gameobject with the player controller class
	public theBallClass myBallClass;		//the gameobject with the ball class
	private ballmove myBall;
	private Rigidbody2D myRigidbody;
	void MakeSpeedAvaliable()
	{
		myBall.IfSpeed = true;
	}
	void BallHalfDecline()
	{
		myRigidbody.mass /= 2f;
	}
	void Awake()
	{
		myBall = GetComponent<ballmove> ();
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	void LateUpdate()
	{
		if (Input.GetButtonDown ("Fire2") && theBalls.GetLength() <= 16) {
			if (myRigidbody.mass >= myBallClass.initialMass * 2f) {
				BallHalfDecline ();
				GetComponent<AudioSource> ().PlayOneShot (FenLieSound);
				myBall.IfSpeed = false;
				GameObject NewBall = Instantiate (this.gameObject, this.transform.position, this.transform.rotation);
				NewBall.GetComponent<Rigidbody2D> ().velocity = myRigidbody.velocity.normalized * NewBallSpeed;
				Invoke ("MakeSpeedAvaliable", SpeedDelay);
			}
		}
	}
}
