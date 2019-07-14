using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	Rigidbody2D _rb;
	float _horizontalInput, _verticalInput;

	public float speed;

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

}
