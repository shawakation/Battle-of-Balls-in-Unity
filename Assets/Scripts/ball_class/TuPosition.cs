using UnityEngine;
using System.Collections;

public class TuPosition : MonoBehaviour
{
	public GameObject TuPos;
	public CircleCollider2D BallCollider;
	public GameObject BaoZi;
	public float InstanceAdded;
	void Update()
	{
		BallCollider.radius = GetComponent<CircleCollider2D> ().radius - BaoZi.GetComponent<CircleCollider2D> ().radius * BaoZi.transform.localScale.x * 2f / transform.localScale.x;
		Vector2 BallPos = new Vector2 (transform.position.x, transform.position.y) + GetComponent<CircleCollider2D> ().offset;
		Vector2 Position = GetComponent<Rigidbody2D> ().velocity.normalized * (BallCollider.radius * transform.localScale.x + BaoZi.GetComponent<CircleCollider2D> ().radius * BaoZi.transform.localScale.x + InstanceAdded) + BallPos;
		Vector2 NewPosition = Position - BaoZi.GetComponent<CircleCollider2D> ().offset;
		TuPos.transform.position = new Vector3 (NewPosition.x, NewPosition.y, 0f);
	}
}
