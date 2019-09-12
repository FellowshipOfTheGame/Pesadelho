using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health { get => health; set => health = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
        // Se a vida for menor que 0 chamar a instancia
        // do game manager e dar game over
        if(health <= 0){
            GameManager.instance.GameOver();
        }
    }
}
