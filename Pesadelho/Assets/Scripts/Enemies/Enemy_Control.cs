using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Control : MonoBehaviour{

	//SerializeField permite que variáveis privadas apareçam na GUI
	[SerializeField] Transform[] waypoints = null;
	[SerializeField] float moveSpeed = 2f;
	private float _moveSpeed;

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

			if(waypoints[waypointIndex].transform.position.x > transform.position.x){
				transform.localScale = new Vector3(-1, 1, 1);
			}
			else
			{
				transform.localScale = new Vector3(1, 1, 1);
			}

	    	if(transform.position == waypoints[waypointIndex].transform.position)
	    		waypointIndex++;
    	}

    }

	public void SlowDown(){

        this.moveSpeed /= 1.4f;
        Invoke("NormalizeSpeed", 5);

    }

	private void NormalizeSpeed(){

		this.moveSpeed *= 1.4f;

	}

}
