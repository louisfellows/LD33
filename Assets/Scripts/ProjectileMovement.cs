using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {
	
	public float speed = 20.0f;
	public float time = 0.0f;
	public float timeout = 5.0f;
	public float explosionForce = 10;
	public float explosionRadius = 1;
	public GameObject collisionEffect;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
		time += Time.deltaTime;
		if (time > timeout) {
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		Instantiate(collisionEffect, transform.position, Quaternion.identity);
		col.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
		GetComponent<AudioSource>().Play();
		Destroy (gameObject);
	}
}
