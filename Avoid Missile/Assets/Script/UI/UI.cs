using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour 
{

	public GameObject heartPrefab;
	public GameObject textPrefab;
	int m_numHeart;
	public int numHeart
	{
		set
		{
			if(value < m_numHeart)
				for(int i = 0; i < m_numHeart - value; i++)
				{
					ObjectPoolManager.GetObjectPool(heartPrefab).PushItem(heartList[0]);
					heartList.RemoveAt(0);
				}
			else
				for(int i = 0; i < value - m_numHeart; i++)
					heartList.Add(ObjectPoolManager.GetObjectPool(heartPrefab).PopItem());
			m_numHeart = value;
		}
		get{ return m_numHeart; }
	}
	public float score{ get;set; }
	List<GameObject> heartList = new List<GameObject>();
	GameObject textScore;
	GameObject textGameOver;
	Camera camera;
	void Start () 
	{
		textScore = ObjectPoolManager.GetObjectPool(textPrefab).PopItem();
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		if(GameManager.instance.isGameOver)
		{
			UpdateGameOver();
		}

		score = GameManager.instance.score;
		numHeart = GameManager.instance.remainLife;
		UpdateHeart();
		UpdateScore();
	}
	void UpdateHeart()
	{
		float screenMinX = camera.transform.position.x - camera.orthographicSize / Screen.height * Screen.width;
		float screenMaxY = camera.transform.position.y + camera.orthographicSize;
		Vector2 startHeartPosition = new Vector2(screenMinX + 2, screenMaxY - 1);

		Sprite heartSpirte = heartPrefab.GetComponent<SpriteRenderer>().sprite;
		float heartWidth =  heartSpirte.rect.width / heartSpirte.pixelsPerUnit * heartPrefab.transform.localScale.x;
		for(int i = 0; i < numHeart; i++)
			heartList[i].transform.position = startHeartPosition + new Vector2(i * heartWidth * 1.2f, 0);
	}
	void UpdateScore()
	{
		float screenMaxX = camera.transform.position.x + camera.orthographicSize / Screen.height * Screen.width;
		float screenMaxY = camera.transform.position.y + camera.orthographicSize;
		Vector2 textPosition = new Vector2(screenMaxX - 5, screenMaxY - 1);
		textScore.transform.position = textPosition;
		textScore.GetComponent<TextMesh>().text = "점수 :  " + (int)score;
	}

	void UpdateGameOver()
	{
		if(textGameOver == null)
		{
			textGameOver = ObjectPoolManager.GetObjectPool(textPrefab).PopItem();
			TextMesh gameOverText = textGameOver.GetComponent<TextMesh>();
			gameOverText.text = "Game Over";	
			gameOverText.fontSize = 200;
		}
		float screenMidX = camera.transform.position.x;
		float screenMidY = camera.transform.position.y;
		textGameOver.transform.position = new Vector2(screenMidX, screenMidY + 2);
	}
}
