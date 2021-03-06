using UnityEngine;
using System.Collections;

public class GravityBehavior : MonoBehaviour {
	
	public float gravForce = 20;
	public float orbitVelocity = 10;
	
	//Random axis of rotation
	private Vector3 rotationAxis;
	//Random spin speed
	private float spinSpeed;
	
	// Use this for initialization
	void Start () {
		rotationAxis = new Vector3(Random.Range(-90.0f, 90.0f), Random.Range(-90.0f, 90.0f), Random.Range(-90.0f, 90.0f));
		spinSpeed = Random.Range(0.0f, 0.6f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.RotateAroundLocal((rotationAxis), spinSpeed * Time.fixedDeltaTime);
	}
	
	void OnTriggerStay(Collider col) {
		//Find the radius vector from the collider to the center of this object
		Vector3 radius = (col.transform.position - transform.position).normalized;
		col.attachedRigidbody.AddForce(-gravForce * radius);
		col.transform.root.RotateAround(transform.position, Vector3.forward, orbitVelocity*Time.fixedDeltaTime);
	}
}
