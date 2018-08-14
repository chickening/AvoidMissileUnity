using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralMissile : MonoBehaviour {

	// Use this for initialization\
	public float speed;
	public Vector2 m_dir;
	public Vector2 dir
	{
		get{return m_dir;}
		set
		{
			if(missileRigidbody == null)
				missileRigidbody = GetComponent<Rigidbody2D>();
			value.Normalize();
			missileRigidbody.rotation = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg - 180;
			m_dir = value;
		}
	}
	public GameObject collisionEffect;
	protected Rigidbody2D missileRigidbody = null;
	void Start()
	{
		if(missileRigidbody == null)
			missileRigidbody = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		missileRigidbody.MovePosition(missileRigidbody.position + speed * dir * Time.fixedDeltaTime);
	}
	public virtual void Init(Vector2 _position, Vector2 _dir)
	{
		gameObject.transform.position = _position;
		dir = _dir;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.layer == 10)	// Player
		{
			GameManager.instance.remainLife -= 1;
			ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
			ObjectPoolManager.GetObjectPool(collisionEffect).PopItem().transform.position = other.transform.position;
		}
	}
}
