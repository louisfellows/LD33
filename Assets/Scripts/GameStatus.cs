using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

	static int score;
	public GameObject text;
	public int growthFactor = 500;

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
		float scaleAmount = score / growthFactor;
		//if (scaleAmount < 1){ scaleAmount = 1; }
		//GameObject.Find("TheMonster").GetComponent<Transform>().localScale = new Vector3(scaleAmount, scaleAmount, scaleAmount);
	}
}
