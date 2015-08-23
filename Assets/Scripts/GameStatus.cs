using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

	static int score;
	public GameObject text;
	public int growthFactor = 500;
	public int tanksPerIncrement = 1;
	public int scoreDifficultyIncrement = 1000;
	
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void AddToScore(int addScore) {
		score += addScore;
		text.GetComponent<GUIText>().text = score.ToString();
		//float scaleAmount = score / growthFactor;
		//if (scaleAmount < 1){ scaleAmount = 1; }
		//GameObject.Find("TheMonster").GetComponent<Transform>().localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
	}
	
	public void manageSpawners() {
		int numberTanksExpected = Mathf.Abs(score / scoreDifficultyIncrement) * tanksPerIncrement;
		int numberTanks = GameObject.FindGameObjectsWithTag("Tank").GetLength();
		GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
		if (numberTanks < numberTanksExpected) {
			for (int i = 0; i < numberTanksExpected - numberTanks; i++) {
				spawners[Random.Range(0, spawners.GetLength())].GetComponent<SpawnScript>().Spawn();
			}
		}
		
	}
}
