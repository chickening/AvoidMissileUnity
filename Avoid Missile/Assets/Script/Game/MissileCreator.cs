using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCreator : MonoBehaviour {

	// Use this for initialization
	public GameObject generalMissile;
	public GameObject fastMissile;
	public GameObject explosionMissile;
	public GameObject guidedMissile;
	public GameObject fragmentsMissile;
	List<GameObject> usableMissile = new List<GameObject>();
	float nextMissileDelay;
	float elapsedTime = 0; 
	BoxCollider2D createPlace;
	Vector2 createPlaceMin;
	Vector2 createPlaceMax;
	// Update is called once per frame
	void Start()
	{
		createPlace = GetComponent<BoxCollider2D>();
		createPlaceMin = new Vector2(createPlace.transform.position.x - createPlace.size.x / 2 + createPlace.offset.x, 
			createPlace.transform.position.y - createPlace.size.y / 2 + createPlace.offset.y);
		createPlaceMax = new Vector2(createPlace.transform.position.x + createPlace.size.x / 2 + createPlace.offset.x, 
			createPlace.transform.position.y + createPlace.size.y / 2 + createPlace.offset.y);
	}
	void Update () 
	{
		if(GameManager.instance.isGameOver)
			return;
		int level = GameManager.instance.level;
		if(level >= 1)
			usableMissile.Add(generalMissile);
		if(level >= 5)
			usableMissile.Add(fastMissile);
		if(level >= 10)
			usableMissile.Add(explosionMissile);
		if(level >= 15)
			usableMissile.Add(guidedMissile);
		if(level >= 20)
			usableMissile.Add(fragmentsMissile);	
		//추가 레벨 5 10 15 20

		nextMissileDelay = 3f / (level / 5f + 1f);
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= nextMissileDelay)
		{
			CreateRandomMissile();
			elapsedTime = 0;
		}
	}
	void CreateRandomMissile()
	{
		int select = Random.Range(0, usableMissile.Count - 1);
		GameObject missile = ObjectPoolManager.GetObjectPool(usableMissile[select]).PopItem();
		GeneralMissile script = missile.GetComponent<GeneralMissile>();

		Vector2 createPosition = new Vector2(Random.Range(createPlaceMin.x, createPlaceMax.x), (createPlaceMin.y + createPlaceMax.y) / 2);
		script.Init(createPosition, Vector2.down);
	}
}
