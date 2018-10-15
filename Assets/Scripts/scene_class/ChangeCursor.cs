using UnityEngine;
using System.Collections;

public class ChangeCursor : MonoBehaviour
{
	public Texture MouseTexture;		//the texture of the mouse
	public float RectWidth;		//the width of the rect
	void Start()
	{
		Cursor.visible = false;
	}
	void OnGUI()
	{
		Vector3 MousePos = Input.mousePosition;
		GUI.DrawTexture (new Rect (MousePos.x, Screen.height - MousePos.y, RectWidth, RectWidth), MouseTexture);
	}
}
