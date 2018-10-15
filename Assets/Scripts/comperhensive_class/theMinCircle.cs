using UnityEngine;
using System;
using System.Collections;
using System.Linq;

public class theMinCircle : MonoBehaviour
{
	public PlayersController myController;
	private const double eps = 1e-8;
	private double R;							//stands for the radius of min circle
	private Vector2[] p = new Vector2[16];		//stands for per ball's x and y position
	private float[] radius = new float[16];		//stands for per ball's radius of circle collider 2d * its localscale
	private Vector2 central;					//stands for the min circle's central position
	private double maxR;						//stands for the max radius in all balls
	public double maxRadius {
		get { return this.maxR; }
	}
	public Vector2 circleCentral {
		get { return this.central; }
	}
	public double circleRadius {
		get { return this.R; }
	}
	//calculate the distance between two points
	private double dist(Vector2 a,Vector2 b)
	{
		return Math.Pow ((Math.Pow ((a.x - b.x), 2f) + Math.Pow ((a.y - b.y), 2f)), 0.5f);
	}
	private Vector2 circumcenter(Vector2 a,Vector2 b,Vector2 c)
	{
		Vector2 tmp;
		float a1 = b.x - a.x, b1 = b.y - a.y, c1 = (a1 * a1 + b1 * b1) / 2f;
		float a2 = c.x - a.x, b2 = c.y - a.y, c2 = (a2 * a2 + b2 * b2) / 2f;
		float d = a1 * b2 - a2 * b1;
		tmp.x = a.x + (c1 * b2 - c2 * b1) / d;
		tmp.y = a.y + (a1 * c2 - a2 * c1) / d;
		return tmp;
	}
	private void min_cover_circle(int n)
	{
		p = p.OrderBy (c => Guid.NewGuid ()).ToArray<Vector2> ();
		central = p [0];
		R = 0f;
		for (int i = 1; i < n; i++) {
			if (dist (central, p [i]) + eps > R) {
				central = p [i];
				R = 0f;
				for (int j = 0; j < i; j++) {
					if (dist (central, p [j]) + eps > R) {
						central.x = (p [i].x + p [j].x) / 2f;
						central.y = (p [i].y + p [j].y) / 2f;
						R = dist (central, p [j]);
						for (int k = 0; k < j; k++) {
							if (dist (central, p [k]) + eps > R) {
								central = circumcenter (p [i], p [j], p [k]);
								R = dist (central, p [k]);
							}
						}
					}
				}
			}
		}
	}
	private void ballPos_to_vector2(Vector2[] i,float[] j)		//transmit the ball's position to the vectors' points
	{
		for (int k = 1; k <= myController.GetLength (); k++) {
			GameObject myBall = myController.GetBall (k);
			Vector3 ball_pos = myBall.transform.position;
			float myRadius = myBall.GetComponent<CircleCollider2D> ().radius * myBall.transform.localScale.x;
			i [k - 1] = new Vector2 (ball_pos.x, ball_pos.y);
			j [k - 1] = myRadius;
		}
	}
	private void ballPos_to_vector2()		//transmit the ball's position to the vectors' points
	{
		for (int k = 1; k <= myController.GetLength (); k++) {
			GameObject myBall = myController.GetBall (k);
			Vector3 ball_pos = myBall.transform.position;
			float myRadius = myBall.GetComponent<CircleCollider2D> ().radius * myBall.transform.localScale.x;
			p [k - 1] = new Vector2 (ball_pos.x, ball_pos.y);
			radius [k - 1] = myRadius;
		}
	}
	private void calcMaxR(float[] i)
	{
		maxR = i.Max<float> ();
	}
	private void calcMaxR()
	{
		maxR = radius.Max<float> ();
	}
	public void calculate()
	{
		ballPos_to_vector2 ();
		min_cover_circle (myController.GetLength ());
		calcMaxR ();
	}
}
