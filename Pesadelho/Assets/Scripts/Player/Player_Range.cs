using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Range : MonoBehaviour
{

    Player _player;
    private Tower target;
    private Queue<Tower> towers = new Queue<Tower>();
    [SerializeField] private AudioSource tirar;


    // Start is called before the first frame update
    void Start()
    {

        _player = transform.parent.gameObject.GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update(){

    	//Se não houver um alvo definido, mas houverem inimigos na lista:
    	if(target == null && towers.Count > 0){

    		//Essa função pega o primeiro inimigo da lista, atribui ao alvo e o remove da lista
    		target = towers.Dequeue();
            target.GetComponent<Tower>().SetRemoveVisibility(true);

    	}
        if(target != null && Input.GetKeyDown(KeyCode.R)){

            target.GetComponent<Tower>().SetRemoveVisibility(false);

            _player.DreamPower(target.GetComponent<Tower>().NecessaryPower());

            Destroy(target.gameObject);
            tirar.Play(0);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.tag == "Tower"){

        	//Adiciona o inimigo à fila de inimigos
        	towers.Enqueue(col.GetComponent<Tower>());

        }

    }

    //É chamada quando algum objeto sai no alcance da torre
    void OnTriggerExit2D(Collider2D col){

        if(col.tag == "Tower"){
            target.GetComponent<Tower>().SetRemoveVisibility(false);
        	target = null;
        }

    }

    //Retorna o alvo atual da torre
    public Tower Target(){

    	return target;

    }

}
