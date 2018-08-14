using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	public float speed = 5;
	Rigidbody2D playerRigidbody;
	void Start () 
	{
		playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		Vector2 dir = Vector2.zero;
		if(Input.GetKey(KeyCode.A))
			dir += Vector2.left;
		if(Input.GetKey(KeyCode.S))
			dir += Vector2.down;
		if(Input.GetKey(KeyCode.D))
			dir += Vector2.right;
		if(Input.GetKey(KeyCode.W))
			dir += Vector2.up;
		
		dir.Normalize();
		
		playerRigidbody.MovePosition(playerRigidbody.position + dir * speed * Time.fixedDeltaTime);
	}
}
