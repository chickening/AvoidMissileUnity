using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerMoveCamera : MonoBehaviour 
{

	// Use this for initialization
	public int paddingPixel;
	public Rect limitRect;
	public float speed;
	Camera camera = null;

	void Start () 
	{
		camera = gameObject.GetComponent<Camera>();
	}
	
	void Update () 
	{
		Vector2 dir = Vector2.zero;
		Vector2 mousePosition = Input.mousePosition;

		int screenWidth = Screen.width;
		int screenHeight = Screen.height;
 

		Vector2 cameraHalfScale = new Vector2(camera.orthographicSize *  screenWidth / screenHeight,  camera.orthographicSize);

		Vector3 cameraPosition = camera.transform.position;

		if(mousePosition.x < paddingPixel)
			dir += Vector2.left;
		if(screenWidth - mousePosition.x < paddingPixel)
			dir += Vector2.right;
		if(mousePosition.y < paddingPixel)
			dir += Vector2.down;
		if(screenHeight - mousePosition.y < paddingPixel)
			dir += Vector2.up;

		dir.Normalize();
		Vector3 cameraNewPosition = cameraPosition + (Vector3)(dir * Time.deltaTime * speed);
		cameraNewPosition.x = Mathf.Clamp(cameraNewPosition.x, limitRect.xMin + cameraHalfScale.x, limitRect.xMax - cameraHalfScale.x);
		cameraNewPosition.y = Mathf.Clamp(cameraNewPosition.y, limitRect.yMin + cameraHalfScale.y, limitRect.yMax - cameraHalfScale.y); 

		camera.transform.position = cameraNewPosition;
	}
}
