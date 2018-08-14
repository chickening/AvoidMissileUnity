using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
	CircleCollider2D explosionCollider;
	Sprite sprite;
	float lifeTime = 1;
	float elaspedTime = 0;
			
	void OnEnable()
	{
		if(explosionCollider == null)
			explosionCollider = GetComponent<CircleCollider2D>();
		if(sprite == null)
			sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	void Update()
	{
		elaspedTime += Time.deltaTime;
		if(lifeTime <= elaspedTime)
		{
			ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
		}
	}
	public void Init(Vector2 position, float radius)
	{
		elaspedTime = 0;
		gameObject.transform.position = position;
		float effectSize = sprite.pixelsPerUnit / sprite.rect.width * radius * 2;
		gameObject.transform.localScale = new Vector2(effectSize, effectSize);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.layer == 10)	// Player
		{
			GameManager.instance.remainLife -= 1;
		}
	}
}
