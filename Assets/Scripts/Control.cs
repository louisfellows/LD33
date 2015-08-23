using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float moveSpeed = 3f;
	public float turnSpeed = 50f;
	public bool disabled = false;

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!disabled) {
			float horiz = Input.GetAxis ("Horizontal");
			float verti = Input.GetAxis ("Vertical");
	
			verti = verti * moveSpeed;
			horiz = horiz * turnSpeed;
	
			transform.Translate(Vector3.right * verti * Time.deltaTime);
			transform.Rotate(Vector3.up, horiz * Time.deltaTime);
	
			animator.SetBool("Moving", (horiz + verti != 0));
	
			if (Input.GetButton("Punch")) {
				animator.SetTrigger("Punch");
			} else if (Input.GetButton ("Kick")) {
				animator.SetTrigger("Kick");
			} else if (Input.GetButton("Uppercut")) {
				animator.SetTrigger("Uppercut");
			}
		}
	}
}
