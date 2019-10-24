using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour{
    [SerializeField] List<Transform> hearts = new List<Transform>();
    private int length;

    void Awake(){

    }

    // Start is called before the first frame update
    void Start(){

        length = hearts.Count;

    }

    // Update is called once per frame
    void Update(){

    	int health = PlayerPrefs.GetInt("Health");

        if(health < length)
            while(health < length){
                hearts[length-1].gameObject.SetActive(false);
                length--;
            }
        if(health > length)
            while(health > length){
                hearts[length].gameObject.SetActive(true);
                length++;
            }

        if(length > hearts.Count) length = hearts.Count;
        
    }
}
