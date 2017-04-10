using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;

	Rigidbody PlayerRB;

	// Use this for initialization
	void Start () {

		PlayerRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (VirtualJoystick.Instance.GetValue () != Vector3.zero) {
		
			MovePlayer ();
			RotatePlayer ();
		}
		
	}

	void MovePlayer(){
	
		PlayerRB.MovePosition(PlayerRB.position + VirtualJoystick.Instance.GetValue()*speed*Time.deltaTime);
	
	}

	void RotatePlayer (){
	
		PlayerRB.MoveRotation (Quaternion.LookRotation(VirtualJoystick.Instance.GetValue()));
	
	}
}

