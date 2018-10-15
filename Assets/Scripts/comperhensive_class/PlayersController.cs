using UnityEngine;
using LinearList;

public class PlayersController : MonoBehaviour
{
	private SeqList<GameObject> AllTheBalls = new SeqList<GameObject> (16);
	public bool AddBall(GameObject TheBall)
	{
		return AllTheBalls.Add (TheBall);
	}
	public bool DestoryBall(int i)
	{
		return AllTheBalls.Delete (i);
	}
	public GameObject GetBall(int i)
	{
		return AllTheBalls [i - 1];
	}
	public bool JudgeEmpty()
	{
		return AllTheBalls.IsEmpty ();
	}
	public bool Insert(GameObject TheBall,int i)
	{
		return AllTheBalls.Insert (TheBall, i);
	}
	public bool JudgeFull()
	{
		return AllTheBalls.IsFull ();
	}
	public int GetLength()
	{
		return AllTheBalls.GetLength ();
	}
}
