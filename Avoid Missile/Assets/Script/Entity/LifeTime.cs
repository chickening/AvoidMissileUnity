using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {

	// Use this for initialization
	public float lifeTime;
	float remainTime;
	void OnEnable()
	{
		remainTime = lifeTime;
	}
	void Update ()
	{
		remainTime -= Time.deltaTime;
		if(remainTime < 0)
			ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
	}
}
