﻿using UnityEngine;
using System.Collections;

public class BuildingCollision : MonoBehaviour
{

		public GameObject explosion;
		public GameObject rubble;
		public int score = 1000;
		public float damageToBreak = 4f;
	
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{ 
	
		}

		void OnCollisionEnter (Collision col)
		{
		if (col.relativeVelocity.magnitude > damageToBreak) {
						Vector3 rubblePos = gameObject.transform.position;
						rubblePos.y += 0.2f;
						Instantiate (explosion, rubblePos, Quaternion.identity);
						Instantiate (rubble, rubblePos, Quaternion.identity);
						Destroy (gameObject);
						
				GameStatus.getInstance().AddToScore(score);
				} else if (col.gameObject.name.EndsWith ("TheMonster")) {
						gameObject.rigidbody.AddForce (Vector3.MoveTowards (gameObject.transform.position, 
			                                                  col.gameObject.transform.position, 
			                                                  -1f));
				}
		}
}
