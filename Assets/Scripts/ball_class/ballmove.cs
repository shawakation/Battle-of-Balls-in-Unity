using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballmove : MonoBehaviour
{
	public Sprite[] Balls;
	public theBallClass myBallClass;	//this is the gameobject with the ball class
	private bool speedControl = true;	//true--the ball's speed is updated per frame,false--the ball's speed stops updating
	public bool IfSpeed {
		get { return this.speedControl; }
		set { this.speedControl = value; }
	}
	void Awake()
	{
		GetComponent<SpriteRenderer> ().sprite = Balls [(int)Random.Range (0f, (float)Balls.Length)];
	}
	void Update()
	{
		if (this.speedControl)
			GetComponent<Rigidbody2D> ().velocity = myBallClass.CalcSpeed ();
	}
}
