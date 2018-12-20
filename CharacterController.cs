using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
	private Animator anim;
	public float speed = 10.0f;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		anim = GetComponent<Animator> ();
		anim.SetBool ("walk", false);
		anim.SetBool ("Attaking", false);
	}
	
	// Update is called once per frame
	void Update () {
		
		float translation = Input.GetAxis ("Vertical") * speed;
		float straffe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		straffe *= Time.deltaTime;

		transform.Translate (straffe, 0, translation);
		Debug.Log(anim.GetBool("walk"));
		Debug.Log (anim.GetBool ("Attaking"));

		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;
	}
}
