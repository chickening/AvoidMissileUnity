using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : GeneralMissile {

	// Use this for initialization
	GameObject target;
	void FixedUpdate()
	{
		missileRigidbody.MovePosition(missileRigidbody.position + speed * dir * Time.fixedDeltaTime);
		if(target.transform.position.y < missileRigidbody.position.y)
			dir = Vector2.Lerp(dir,(Vector2)target.transform.position - missileRigidbody.position, 0.2f * Time.fixedDeltaTime);
	}
	public override void Init(Vector2 _position, Vector2 _dir)
	{
		base.Init(_position,_dir);
		target = GameManager.instance.teemo;
	} 
}
