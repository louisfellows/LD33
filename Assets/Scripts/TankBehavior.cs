using UnityEngine;
using System.Collections;

public class TankBehavior : MonoBehaviour {

	public GameObject target;
	public float fireRate = 0.1f;
	private float sinceLastShot = 0.1f;
	public float speed = 0.1f;
	public float stayDistance = 1;
	private NavMeshAgent agent;
	private FireProjectile tankGun;
	public GameObject wreckage;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		print(target.name);
		tankGun = gameObject.GetComponentInChildren<FireProjectile>();
		sinceLastShot += Random.Range(0, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		
		agent.destination = target.transform.position;
		print ("Goal" + target.transform.position);

		//if (Vector3.Distance(gameObject.transform.position, target.transform.position) > stayDistance) {
			gameObject.transform.LookAt(target.transform.position);

		//} else {
			print ("SinceLast" + sinceLastShot);
			sinceLastShot -= Time.deltaTime;
			if (sinceLastShot < 0 && CanSeeTarget()) {
				tankGun.fireShell();
				sinceLastShot = fireRate;
				print ("Fire");
			}
		//}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals("TheMonster")) {
			if (col.relativeVelocity.magnitude > 5) {
				Destroy(gameObject);
				GameObject newWreck = (GameObject) Instantiate(wreckage, gameObject.transform.position, gameObject.transform.rotation);
				Vector3 point = col.contacts[0].point;
				point.y = 0;
				newWreck.GetComponent<Rigidbody>().AddExplosionForce(100, point, 1);
			}
		}
	}
	
	private bool CanSeeTarget() {
		if (Physics.Linecast(transform.position, target.transform.position)) { 
			return true; 
		} 
		return false; 
	}
}
