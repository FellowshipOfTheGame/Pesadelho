using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Range : MonoBehaviour{

    //Esse script pega todos os inimigos que entram e saem do alcance da torre, adicionando eles a uma lista e definindo o alvo por ordem de chegada;
    //
    //

	//Armazena o alvo atual da torre
	private Enemy target;

	//Armazena uma 'fila' de inimigos para saber qual é o proximo que deve ser atacado
	private Queue<Enemy> enemies = new Queue<Enemy>();

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

    	//Se não houver um alvo definido, mas houverem inimigos na lista:
    	if(target == null && enemies.Count > 0){

    		//Essa função pega o primeiro inimigo da lista, atribui ao alvo e o remove da lista
    		target = enemies.Dequeue();

    	}
        
    }

    //É chamada quando algum objeto entra no alcance da torre
    void OnTriggerEnter2D(Collider2D col){

        if(col.tag == "Enemy"){

        	//Adiciona o inimigo à fila de inimigos
        	enemies.Enqueue(col.GetComponent<Enemy>());

        }

    }

    //É chamada quando algum objeto sai no alcance da torre
    void OnTriggerExit2D(Collider2D col){

        if(col.tag == "Enemy")
        	target = null;

    }

    //Retorna o alvo atual da torre
    public Enemy Target(){

    	return target;

    }

}
