using UnityEngine;
using System.Collections;

public class ExplodeOnPlayerImpact : MonoBehaviour {
	public GameObject explosion;
	public int score = 100;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.EndsWith ("TheMonster")) {
			Vector3 rubblePos = gameObject.transform.position;
			rubblePos.y += 0.2f;
			Instantiate (explosion, rubblePos, Quaternion.identity);
			Destroy (gameObject);
			GameObject.Find("GameStatus").GetComponent<GameStatus>().AddToScore(score);
		}
	}
}
