using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceCamera : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float speed;
	Camera camera;
	void Start () 
	{
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targetPosition = target.transform.position;
		targetPosition.z = camera.transform.position.z;
		camera.transform.position = Vector3.Lerp(camera.transform.position, targetPosition, speed);
	
	}
}
