using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentsMissile : GeneralMissile {

	// Use this for initialization
	public GameObject fragmentsPrefab;
	public float explosionTime;
	float elaspedTime = 0;
	public int numFragments;
	void FixedUpdate()
	{
		elaspedTime += Time.fixedDeltaTime;
		if(elaspedTime >= explosionTime)
		{
			elaspedTime = 0;
			GameManager.instance.StartCoroutine(CreateFragmentsCoroutine());	//Disable되도 작동되게
			ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
		}
		missileRigidbody.MovePosition(missileRigidbody.position + speed * dir * Time.fixedDeltaTime);
	}
	IEnumerator CreateFragmentsCoroutine()
	{
		Vector2 position = missileRigidbody.position;
		for(int i = 0; i < numFragments; i++)
		{
			GameObject fragments = ObjectPoolManager.GetObjectPool(fragmentsPrefab).PopItem();
			GeneralMissile scriptMissile = fragments.GetComponent<GeneralMissile>();
			scriptMissile.Init(position, new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
			yield return new WaitForSeconds(0.1f);
		}
	}
	public override void Init(Vector2 _position, Vector2 _dir)
	{
		base.Init(_position,_dir);
		elaspedTime = 0;
		explosionTime = Random.Range(3f,5f);
	}
	// Update is called once per frame
}
