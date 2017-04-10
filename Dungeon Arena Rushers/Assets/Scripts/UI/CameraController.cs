using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float smth = 5f;

	Vector3 offset;

	void Start(){

		target = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - target.position;

	}

	void FixedUpdate(){
	
		Vector3 targetCamPos = target.position+offset;
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smth*Time.deltaTime);
	
	}
}
