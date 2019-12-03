using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health { get => health; set => health = value; }
    [SerializeField] private Sprite[] healthBar; 
    [SerializeField] private AudioSource dano;


    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        //healthBar = Resources.LoadAll<Sprite>("Art/Brain/Vida");
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 10){
            sr.sprite = healthBar[0];
        }
        else if(health == 9){
            sr.sprite = healthBar[1];
        }
        else if(health == 8){
            sr.sprite = healthBar[2];
        }
        else if(health == 7){
            sr.sprite = healthBar[3];
        }
        else if(health == 6){
            sr.sprite = healthBar[4];
        }
        else if(health == 5){
            sr.sprite = healthBar[5];
        }
        else if(health == 4){
            sr.sprite = healthBar[6];
        }
        else if(health == 3){
            sr.sprite = healthBar[7];
        }
        else if(health == 2){
            sr.sprite = healthBar[8];
        }
        else if(health == 1){
            sr.sprite = healthBar[9];
        }
        else if(health == 0){
            sr.sprite = healthBar[10];
        }
    }

    // Quando algum objeto entra em colisão com o cérebro
    void OnCollisionEnter2D(Collision2D col){
        // Se a tag desse objeto for Enemy chamar a função de tomar dano
        // e destruir o inimigo que estiver atacando
        if(col.gameObject.tag == "Enemy"){
            TakeDamage();
            Destroy(col.gameObject);
        }
    }

    // Quando algum objeto entra em colisão trigger com o cérebro
    void OnTriggerEnter2D(Collider2D other) {
        // Se a tag desse objeto for Enemy chamar a função de tomar dano
        // e destruir o inimigo que estiver atacando
        if(other.gameObject.tag == "Enemy"){
            TakeDamage();
            Destroy(other.gameObject);
        }    
    }
    
    // Função para subtrair vida do cérebro
    void TakeDamage(){
        health--;
        dano.Play(0);
        // Se a vida for menor que 0 chamar a instancia
        // do game manager e dar game over
        if(health <= 0){
            GameManager.instance.GameOver();
        }
    }
}
