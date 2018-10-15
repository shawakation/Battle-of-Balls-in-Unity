using UnityEngine;
using System.Collections;

public class ChiBaoZi : MonoBehaviour
{
	public theBallClass myBallClass;
	IEnumerator increase()
	{
		for (int i = 0; i < 20; i++) {
			myBallClass.TheBallIncrease (this.GetComponentInParent<GameObject> ());
			yield return new WaitForSeconds (0.01f);
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "BaoZi") {
			Destroy (other.gameObject);
			StartCoroutine (increase ());
		}
	}
	void OnTriggerStay2D (Collider2D other)
	{
		OnTriggerEnter2D (other);
	}
}
