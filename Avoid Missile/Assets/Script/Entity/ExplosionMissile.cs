using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionMissile : GeneralMissile 
{

	// Update is called once per frame
	public float explosionTime;
	public float radius = 3;
	public GameObject explosion;
	float elaspedTime = 0;
	void FixedUpdate()
	{
		missileRigidbody.MovePosition(missileRigidbody.position + speed * dir * Time.fixedDeltaTime);
		elaspedTime += Time.deltaTime;
		if(elaspedTime >= explosionTime)
		{
			elaspedTime = 0;
			GameObject explosionEffect = ObjectPoolManager.GetObjectPool(explosion).PopItem();
			Explosion explosionScript = explosionEffect.GetComponent<Explosion>();
			explosionScript.Init(gameObject.transform.position, radius);
			ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
		}
	}
	public override void Init(Vector2 _position, Vector2 _dir)
	{
		base.Init(_position,_dir);
		elaspedTime = 0;
		explosionTime = Random.Range(3f,5f);
	}
}
