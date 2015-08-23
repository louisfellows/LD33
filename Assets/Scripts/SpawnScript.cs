using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject toSpawn;
	public GameObject gameStatus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Spawn() {
		GameObject newTank = (GameObject) Instantiate(toSpawn, transform.position, transform.rotation);
		newTank.GetComponent<TankBehavior>().target = (GameObject) GameObject.FindGameObjectWithTag("Player");
	}
}
