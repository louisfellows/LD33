using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

	private static GameStatus instance;
	
	public static GameStatus getInstance() {
		if (instance == null) {
			instance = GameObject.FindObjectOfType<GameStatus>();
		}
		return instance;
	}

	static int score;
	public GameObject text;
	public int growthFactor = 500;
	public int tanksPerIncrement = 1;
	public int scoreDifficultyIncrement = 5000;
	public float timeBetweenSpawns = 10.0f;
	private float sinceLastSpawn = 0;
	public int maxTanks = 50;
	
	// Use this for initialization
	void Start () {
		score = 0;
		sinceLastSpawn = timeBetweenSpawns;
	}
	
	// Update is called once per frame
	void Update () {
		sinceLastSpawn -= Time.deltaTime;
		if (sinceLastSpawn < 0) {
			manageSpawners();
			sinceLastSpawn = timeBetweenSpawns;
		}
	}
	
	public void AddToScore(int addScore) {
		score += addScore;
		text.GetComponent<GUIText>().text = score.ToString();
		//float scaleAmount = score / growthFactor;
		//if (scaleAmount < 1){ scaleAmount = 1; }
		//GameObject.Find("TheMonster").GetComponent<Transform>().localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
	}
	
	public void manageSpawners() {
		int numberTanksExpected = Mathf.Min(Mathf.Abs(score / scoreDifficultyIncrement) * tanksPerIncrement, maxTanks);
		int numberTanks = GameObject.FindGameObjectsWithTag("Tank").Length;
		GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
		if (numberTanks < numberTanksExpected) {
			for (int i = 0; i < numberTanksExpected - numberTanks; i++) {
				spawners[Random.Range(0, spawners.Length)].GetComponent<SpawnScript>().Spawn();
			}
		}
		
	}
}
