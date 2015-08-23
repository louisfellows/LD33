using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	public GameObject shell;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void fireShell() {
		GetComponent<AudioSource>().Play();
		Instantiate (shell, transform.position, transform.rotation);
	}
}
