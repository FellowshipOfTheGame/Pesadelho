using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	Rigidbody2D _rb;
	float _horizontalInput, _verticalInput;

	public float speed;
    private int health = 3;

	void Awake(){

		_rb = GetComponent<Rigidbody2D>();

	}

    // Start is called before the first frame update
    void Start(){

        
    }

    // Update is called once per frame
    void Update(){

    	//GetAxisRaw has no smoothing
    	_horizontalInput 	= Input.GetAxisRaw("Horizontal");
        _verticalInput 		= Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(_horizontalInput*speed, _verticalInput*speed);

    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag == "Enemy"){
            //Repelir o player

            Damage();
        }

    }

    void Damage(){
        health--;

        if(health == 0)
            Die();
    }

    void Die(){
        Destroy(gameObject);
    }

}
