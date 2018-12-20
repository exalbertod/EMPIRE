using UnityEngine;
using System.Collections;

public class disparo3 : MonoBehaviour
{
	int SteinburgCount = 0;
	public Transform Player;
	public float throwForce = 10f;
	private Animator anim;


	//Drag in the Bullet Emitter from the Component Inspector.
	public GameObject Bullet_Emitter;

	//Drag in the Bullet Prefab from the Component Inspector.
	public GameObject Bullet;

	//Enter the Speed of the Bullet from the Component Inspector.
	public float Bullet_Forward_Force;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		anim.SetBool ("walk", false);
		anim.SetBool ("Attaking", false);
		if (Input.GetMouseButtonDown (0)) {
			ThrowSteinburg ();

		}
		if (Input.GetKey (KeyCode.W)) {
			anim.SetBool ("walk", true);
		}
		if (Input.GetKey (KeyCode.S)) {
			anim.SetBool ("walk", true);
		}
		if (Input.GetKey (KeyCode.D)) {
			anim.SetBool ("walk", true);
		}
		if (Input.GetKey (KeyCode.A)) {
			anim.SetBool ("walk", true);
		}
		}
	void ThrowSteinburg(){

		if (SteinburgCount > 0) {
			SteinburgCount--;
			anim.SetBool ("Attaking", true);
			GameObject green = Instantiate (Bullet, Player.position, Player.rotation) as GameObject;
			green.GetComponent <Rigidbody> ().AddForce (Player.forward * throwForce, ForceMode.Impulse);
		}
	}
	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Steinburg") {
			SteinburgCount++;
			DestroyObject (coll.gameObject);
		}
	}
}