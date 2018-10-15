using UnityEngine;
using System.Collections;

public class Foods : MonoBehaviour
{
	public theBallClass myBallClass;
	public theBkgClass myBkgClass;
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
			myBallClass.TheBallIncrease (this.gameObject);
			myBkgClass.FoodEaten++;
			if (myBkgClass.FoodEaten >= 50) {
				myBkgClass.FoodSpawn ();
				myBkgClass.FoodEaten = 0;
			}
		}
	}
	void OnTriggerStay2D (Collider2D other)
	{
		OnTriggerEnter2D (other);
	}
}
