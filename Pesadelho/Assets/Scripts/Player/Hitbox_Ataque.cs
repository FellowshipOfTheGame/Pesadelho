﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_Ataque : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.tag == "Enemy"){

            Debug.Log("nice");
            col.GetComponent<Enemy>().Damage(1);

        }

    }
    
}
