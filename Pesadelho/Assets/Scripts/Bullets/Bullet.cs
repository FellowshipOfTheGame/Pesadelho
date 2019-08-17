using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    Rigidbody2D _rb;

	private Vector3 target = Vector3.zero;
	[SerializeField] float speed = 0;
	[SerializeField] float damage = 0;


    void Awake(){

        _rb = GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.tag == "Enemy"){

            col.GetComponent<Enemy>().Damage();
            Destroy(gameObject);
            
        }

    }

    public void SetTarget(Vector3 target){

    	this.target = target;

    }

    public Vector3 Target(){

    	return target;

    }

    public float Speed(){

    	return speed;

    }

    public float Damage(){

    	return damage;

    }
}
