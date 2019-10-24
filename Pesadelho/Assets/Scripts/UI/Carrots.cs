using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carrots : MonoBehaviour{

	private Player player;

    // Start is called before the first frame update
    void Start(){

        
    }

    // Update is called once per frame
    void Update(){

        GetComponent<Text>().text = PlayerPrefs.GetInt("Carrots")+"";
        
    }
}
