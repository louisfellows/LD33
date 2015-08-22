using UnityEngine;
using System.Collections;

public class BuildingCollision : MonoBehaviour {

	public GameObject explosion;
	public GameObject smoke;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "Plane") {
			print (col.relativeVelocity.magnitude);
			if (col.relativeVelocity.magnitude > 3f) {
				Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
				Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
		}
	}
}
