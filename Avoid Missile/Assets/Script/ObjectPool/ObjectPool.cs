using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
 {

	List<GameObject> pool = new List<GameObject>();
	GameObject prefab;
	public int capacity{get;set;}
	public int size{get; private set;}
	public ObjectPool(GameObject _prefab, int _capacity = 10)
	{
		prefab = _prefab;

		capacity = _capacity;
		size = 0;
	}
	public void CreateItem()
	{
		GameObject obj = Object.Instantiate(prefab);
		obj.name = prefab.name;
		PushItem(obj);
	}
	public void PushItem(GameObject obj)
	{
		obj.SetActive(false);
		if(size < capacity)
		{
			++size;
			pool.Add(obj);
		}
		else
			Object.Destroy(obj);
	}
	public GameObject PopItem()
	{
		if(size == 0)
			CreateItem();
		GameObject obj = pool[0];
		pool.RemoveAt(0);
		obj.SetActive(true);
		--size;
		return obj;
	}
}
