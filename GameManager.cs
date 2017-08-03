using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private BoardManager boardScript;
	private StageManager stageInfo;

	void Awake()
	{
		if (instance == null)//이미 인스턴스(copy)가 존재하는지 확인
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		boardScript = GetComponent<BoardManager>();
		stageInfo = GetComponent<StageManager> ();

		InitGame();
	}

	void InitGame()
	{
		boardScript.SetupScene(stageInfo.map1);
	}

	//Update is called every frame.
	void Update()
	{

	}
}
