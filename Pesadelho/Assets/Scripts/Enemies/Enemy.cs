using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

	public int health = 1;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Damage(){
        health--;

        if(health == 0)
            Die();
    }

    void Die(){

        Destroy(gameObject);
        
    }

}
