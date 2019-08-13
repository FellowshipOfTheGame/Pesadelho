using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health { get => health; set => health = value; }
    [SerializeField]private GameObject GameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Enemy"){
            TakeDamage();
            Destroy(col.gameObject);
        }
    }

    private void GameOver(){
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);
    }
    public void TakeDamage(){
        health--;
        if(health <= 0){
            GameOver();
        }
    }
}
