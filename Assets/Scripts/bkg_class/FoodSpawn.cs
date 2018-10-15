using UnityEngine;
using System.Collections;

public class FoodSpawn : MonoBehaviour
{
	public theBkgClass myBkgClass;
	public int SpawnX50 = 100;
	void FirstSpawn()
	{
		if (SpawnX50 <= 0 && IsInvoking ("FirstSpawn"))
			CancelInvoke ("FirstSpawn");
		else {
			myBkgClass.FoodSpawn ();
			SpawnX50--;
		}
	}
	void Start()
	{
		InvokeRepeating ("FirstSpawn", 0.5f, 0.02f);
	}
}
