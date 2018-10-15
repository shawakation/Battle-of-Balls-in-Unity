using UnityEngine;
using System.Collections;

public class TuBaoZi : MonoBehaviour
{
	public float Delay;		//the delay time of tu bao zi
	public GameObject BaoZiPrefab;		//prefabs of bao zi
	public float BaoZiSpeed;		//the speed of new bao zi
	public GameObject TuPosition;		//tu bao zi's position
	public AudioClip TuBaoZiSound;		//tu bao zi's sound
	public theBallClass myBallClass;	//the gameobject with the ball class
	private bool Activated = true;
	IEnumerator decline()
	{
		for (int i = 0; i < 20; i++) {
			myBallClass.TheBallDecline (this.gameObject);
			yield return new WaitForSeconds (0.01f);
		}
	}
	GameObject tu(GameObject BaoZiPrefab,GameObject TuPosition,Rigidbody2D ballRigidbody)
	{
		GameObject BaoZiClone = Instantiate (BaoZiPrefab, TuPosition.transform.position, BaoZiPrefab.transform.rotation);
		BaoZiClone.SetActive (true);
		BaoZiClone.GetComponent<Rigidbody2D> ().velocity = ballRigidbody.velocity.normalized * BaoZiSpeed;
		return BaoZiClone;
	}
	GameObject tu()
	{
		GameObject BaoZiClone = Instantiate (this.BaoZiPrefab, TuPosition.transform.position, this.BaoZiPrefab.transform.rotation);
		BaoZiClone.SetActive (true);
		BaoZiClone.GetComponent<Rigidbody2D> ().velocity = this.GetComponent<Rigidbody2D> ().velocity.normalized * BaoZiSpeed;
		return BaoZiClone;
	}
	void LateUpdate()
	{
		if (Input.GetButton ("Fire1") && Activated) {
			Rigidbody2D ballRigidbody = GetComponent<Rigidbody2D> ();
			if (ballRigidbody.mass >= myBallClass.initialMass + 20f * myBallClass.massAdded) {
				tu ();
				StartCoroutine (decline ());
				Activated = false;
				Invoke ("ActivateBaoZi", Delay);
			}
		}
	}
	void ActivateBaoZi()
	{
		Activated = true;
	}
}
