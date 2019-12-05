﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    public Player player;

	public int health = 1;
    public int carrots = 1;

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Damage(int damage){
        health -= damage;

        if(health <= 0)
            Die();
    }

    private void Die(){

        player.AddCarrots(carrots);
        Destroy(gameObject);
        
    }

}
