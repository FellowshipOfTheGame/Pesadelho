using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Control : MonoBehaviour{

	//SerializeField permite que variáveis privadas apareçam na GUI
	[SerializeField] Transform[] waypoints = null;
	[SerializeField] float moveSpeed = 2f;

	int waypointIndex = 0;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
	private Animator animator;


    // Start is called before the first frame update
    void Start(){
		
        animator = GetComponent<Animator>();
    	transform.position = waypoints[waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update(){

    	Move();
        
    }

    void Move(){

    	if(waypointIndex < waypoints.Length){
	    	transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, MoveSpeed*Time.deltaTime);

			if(waypoints[waypointIndex+1].transform.position.x > transform.position.x){
				animator.SetBool("Right", true);
				animator.SetBool("Left", false);
			}
			else
			{
				animator.SetBool("Right", false);
				animator.SetBool("Left", true);
			}

	    	if(transform.position == waypoints[waypointIndex].transform.position)
	    		waypointIndex++;
    	}

    }
}
