using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaLayer : MonoBehaviour
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

        if(col.tag == "Player"){

            col.GetComponent<SpriteRenderer>().sortingLayerName  = "PlayerFundo";

        }

    }
    
    void OnTriggerExit2D(Collider2D col){

        if(col.tag == "Player"){

            col.GetComponent<SpriteRenderer>().sortingLayerName = "Player";

        }

    }
}
