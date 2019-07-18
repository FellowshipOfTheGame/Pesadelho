﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Control : MonoBehaviour{

	//SerializeField permite que variáveis privadas apareçam na GUI
	[SerializeField]
	Transform[] waypoints;

	[SerializeField]
	float moveSpeed = 2f;

	int waypointIndex = 0;

    // Start is called before the first frame update
    void Start(){

    	transform.position = waypoints[waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update(){

    	Move();
        
    }

    void Move(){

    	if(waypointIndex < waypoints.Length){
	    	transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed*Time.deltaTime);

	    	if(transform.position == waypoints[waypointIndex].transform.position)
	    		waypointIndex++;
    	}

    }
}
