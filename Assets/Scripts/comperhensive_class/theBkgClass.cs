using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public Vector2 Min;
	public Vector2 Max;
}

public class theBkgClass : MonoBehaviour
{
	public Boundary FoodSpawnBoundary;
	public GameObject[] foodPrefabArray;	//Food Prefab Array
	public Boundary PlayerSpawnBoundary;
	public GameObject thePlayer;		//the player initial
	public PlayersController myController;
	private long theFoodEaten = 0;
	public long FoodEaten {
		get { return this.theFoodEaten; }
		set { this.theFoodEaten = value; }
	}
	//Food Respawn Function,spawn foods during a while
	public void FoodSpawn(Vector2 min,Vector2 max,GameObject[] foodPrefabArray)
	{
		for (int k = 0; k < 50; k++) {
			Vector3 FoodPos = new Vector3 (Random.Range (min.x, max.x), Random.Range (min.y, max.y), 0f);
			GameObject Clone = Instantiate (foodPrefabArray [(int)Random.Range (0f, (float)foodPrefabArray.Length)], FoodPos, this.transform.rotation);
			Clone.SetActive (true);
		}
	}
	//the reload food spawn function without any virtual parameters
	public void FoodSpawn()
	{
		for (int k = 0; k < 50; k++) {
			Vector3 FoodPos = new Vector3 (Random.Range (FoodSpawnBoundary.Min.x, FoodSpawnBoundary.Max.x), Random.Range (FoodSpawnBoundary.Min.y, FoodSpawnBoundary.Max.y), 0f);
			GameObject Clone = Instantiate (this.foodPrefabArray [(int)Random.Range (0f, (float)this.foodPrefabArray.Length)], FoodPos, this.transform.rotation);
			Clone.SetActive (true);
		}
	}
	//spawn the player in a random position
	public void SpawnBall(Vector2 minPos,Vector2 maxPos,GameObject Player,PlayersController myController)
	{
		Vector3 pos = new Vector3 ((float)Random.Range (minPos.x, maxPos.x), (float)Random.Range (minPos.y, maxPos.y), 0f);
		GameObject ball = Instantiate (Player, pos, Player.transform.rotation);
		myController.AddBall (ball);
	}
	public void SpawnBall()
	{
		Vector3 pos = new Vector3 ((float)Random.Range (FoodSpawnBoundary.Min.x, FoodSpawnBoundary.Max.x), (float)Random.Range (FoodSpawnBoundary.Min.y, FoodSpawnBoundary.Max.y), 0f);
		GameObject ball = Instantiate (this.thePlayer, pos, this.thePlayer.transform.rotation);
		myController.AddBall (ball);
	}
}
