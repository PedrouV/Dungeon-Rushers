using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

	Transform Player;
	NavMeshAgent navA;
	// Use this for initialization
	void Awake () {

		Player = GameObject.FindGameObjectWithTag ("Player").transform;
		navA = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {

		navA.SetDestination (Player.position);
		
	}
}
