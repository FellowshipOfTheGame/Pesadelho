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

    //Quando algum objeto entra em colisão com o cérebro
    void OnCollisionEnter2D(Collision2D col){
        //Se a tag desse objeto for Enemy chamar a função de tomar dano
        // e destruir o inimigo que estiver atacando
        if(col.gameObject.tag == "Enemy"){
            TakeDamage();
            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy"){
            TakeDamage();
            Destroy(other.gameObject);
        }    
    }

    //Função para parar o jogo e mostrar a tela de game over
    private void GameOver(){
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);
    }
    
    //Função para subtrair vida do cérebro
    public void TakeDamage(){
        health--;
        if(health <= 0){
            GameOver();
        }
    }
}
