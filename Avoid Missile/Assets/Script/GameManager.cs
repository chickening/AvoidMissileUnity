using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public static GameManager _instance;
	public static GameManager instance
	{
		private set;
		get;
	}
	public GameObject teemo;
	public UI ui;
	public bool isGameOver{get;private set;}
	public float score{get;set;}
	int _remainLife;
	public int remainLife
	{
		get{return _remainLife;}
		set
		{
			if(!isInvinsible)
			{ 
				if(value - _remainLife< 0)
				{
					isInvinsible = true;
				}
				_remainLife = value;

				if(value == 0)
					isGameOver = true;
				
			}
		}
	}
	bool _isInvinsible;
	bool isInvinsible
	{
		get{return _isInvinsible;}
		set
		{
			if(value == true)
			{
				invinsibleElapsedTime = 0;
			}
			_isInvinsible = value;
		}
	}

	public int level{get;set;}
	public float teemoInvinsibleTime = 1f;
	float invinsibleElapsedTime = 0;
	void Awake()
	{
		instance = this;
	}
	void Start()
	{
		remainLife = 3;

		Physics2D.IgnoreLayerCollision(9,9);	// 8 : Missile 0 : background
		Physics2D.IgnoreLayerCollision(9,8);
	}
	void Update()
	{
		if(!isGameOver)
			score += Time.deltaTime * 100;
		else
			isInvinsible = true;

		if(isInvinsible)	// 무적 시간 체크
		{
			invinsibleElapsedTime += Time.deltaTime;
			if(teemoInvinsibleTime <= invinsibleElapsedTime)
				isInvinsible = false;
		}

		level = (int)(score / 300) + 1;
	}
}
