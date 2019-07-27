using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBullet : MonoBehaviour{

	Rigidbody2D _rb;
    private Vector3 movementVector = Vector3.zero;

	void Awake(){

		_rb = GetComponent<Rigidbody2D>();

	}

    // Start is called before the first frame update
    void Start(){

        Bullet bullet = transform.GetComponent<Bullet>();
        movementVector = (bullet.Target() - transform.position).normalized * bullet.Speed();
        
    }

    // Update is called once per frame
    void Update(){

        Move();
        
    }

    void Move(){

        transform.position += movementVector * Time.deltaTime;

    }

}
