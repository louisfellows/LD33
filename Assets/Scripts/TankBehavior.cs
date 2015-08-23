using UnityEngine;
using System.Collections;

public class TankBehavior : MonoBehaviour {

	public GameObject target;
	public float fireRate = 0.1f;
	private float sinceLastShot = 0.1f;
	private NavMeshAgent agent;
	private FireProjectile tankGun;
	public GameObject wreckage;
	public int score = 50;

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

		//gameObject.transform.LookAt(target.transform.position);

		print ("SinceLast" + sinceLastShot);
		sinceLastShot -= Time.deltaTime;
		if (sinceLastShot < 0 && CanSeeTarget()) {
			tankGun.fireShell();
			sinceLastShot = fireRate;
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name.Equals("TheMonster")) {
			if (col.relativeVelocity.magnitude > 5) {
				Vector3 wreckSpawn = gameObject.transform.position;
				if (wreckSpawn.y < 0f) {
					print (wreckSpawn.y);
					wreckSpawn.y = 1f;
				}
				
				GameObject newWreck = (GameObject) Instantiate(wreckage, wreckSpawn, gameObject.transform.rotation);
				newWreck.GetComponent<Rigidbody>().AddExplosionForce(10, gameObject.transform.position, 10);
				GameStatus.getInstance().AddToScore(score);
				Destroy(gameObject);
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
