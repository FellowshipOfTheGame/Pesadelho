using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox_Player : MonoBehaviour
{

    Player _player;

    // Start is called before the first frame update
    void Start()
    {

        _player = transform.parent.GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        
        if(col.tag == "Enemy"){
            Debug.Log("Machuchou");
            _player.Damage();
        }

    }

}
