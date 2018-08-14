using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class ObjectPoolManager
{
    static Dictionary<string, ObjectPool> objectPoolList = new Dictionary<string, ObjectPool>();
    public static ObjectPool FindObejctPool(GameObject prefab)
	{
		ObjectPool pool = null;
		objectPoolList.TryGetValue(prefab.name, out pool);
		return pool;
	}
    public static ObjectPool CreateObjectPool(GameObject prefab)
    {
        ObjectPool pool = new ObjectPool(prefab);
        objectPoolList.Add(prefab.name, pool);
        return pool;
    }
	public static ObjectPool GetObjectPool(GameObject prefab)
	{
		ObjectPool pool = null;
		pool = FindObejctPool(prefab);
        if(pool == null)
        {
            pool = CreateObjectPool(prefab);
        }
        return pool;
	}
}