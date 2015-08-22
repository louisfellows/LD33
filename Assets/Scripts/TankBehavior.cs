using UnityEngine;
using System.Collections;

public class TankBehavior : MonoBehaviour {

	public GameObject target;
	public int fireRate;
	private float sinceLastShot;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		print (Vector3.Distance(gameObject.transform.position, target.transform.position));
		if (Vector3.Distance(gameObject.transform.position, target.transform.position) > 1) {
			gameObject.transform.LookAt(target.transform.position);
			gameObject.transform.position += Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed);
		} else {
			sinceLastShot -= Time.deltaTime;
			if (sinceLastShot < 0) {
				//FIRE
				sinceLastShot = fireRate;
				print ("Fire");
			}
		}
	}
}
