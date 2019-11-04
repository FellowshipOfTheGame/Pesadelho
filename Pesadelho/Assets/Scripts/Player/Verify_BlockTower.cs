using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verify_BlockTower : MonoBehaviour
{

    private bool blocked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col){
 
        if(col.tag != "Range")
            this.blocked = true;

    }
    void OnTriggerExit2D(Collider2D col){
 
        this.blocked = false;

    }

    public bool Blocked(){

        return this.blocked;

    }

}
