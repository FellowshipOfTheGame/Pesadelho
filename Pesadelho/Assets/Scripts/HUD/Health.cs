using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour{
    [SerializeField] List<Transform> hearts = new List<Transform>();

    void Awake(){

    }

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){

    	int health = PlayerPrefs.GetInt("Health");

        while(health < hearts.Count && hearts.Count > 0){

            Destroy(hearts[hearts.Count-1].gameObject);
            hearts.RemoveAt(hearts.Count-1);

        }
        
    }
}
