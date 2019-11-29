using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab = null;

    // Variaves para decidir o número de inimigos de cada wave e quantas waves
    private int tamWave = 5;
    [SerializeField] private int[] Wave;

    // Variaveis para os valores rand para spawnar inimigos
    private int rand;
    private int special;

    [SerializeField] private Text n_waves;

    // Start is called before the first frame update
    void Start()
    {   
        n_waves.text = "1 / " + tamWave;
        // Colocar o tempo rodando
        Time.timeScale = 1;
        // Criar e iniciar uma rotina para usar tempo entre as waves
        StartCoroutine(spawn());
    }   

    // Rotina para spawnar os inimigos
    IEnumerator spawn(){
        
        // Um for para spawnar o ninho de inimigos em cada wave
        // O número de cases no switch deve ser igual ao número max de waves
        for(int i = 1; i<=tamWave; i++){
            // Randomiza um numero entre 1 e 5 para decidir que tipo de inimigo vai spawnar
            // O numero de inimigos que irão spawnar é definido pelo numero da wave e fica 
            // armazenado na array Wave
            rand = Random.Range(1, 5);
            Debug.Log(rand+" "+i);
            n_waves.text = i + " / " + tamWave;
            // Dependendo do número randomizado a velocidade do inimigo irá mudar
            switch(rand){
                // Cada caso instanceia um inimigo novo, deixa ele visivel e muda sua velocidade
                // Cada spawn tem uma chance de dar um spawn de um inimigo especial que tem a velocidade
                // maior que qualuer outro inimigo.
                // Depois de cada spawn a rotina espera um tempo para spawnar outro inimigo
                case 1:
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 30/i);
                        if(special == 1){
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 2f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 10;
                        }
                        else{
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 0.5f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 5;
                        }
                        yield return new WaitForSeconds(5);
                    }
                    break;
                case 2:
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 30/i);
                        if(special == 1){
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 2f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 10;
                        }
                        else{
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 0.7f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 5;
                        }
                        yield return new WaitForSeconds(5);
                    }
                    break;
                case 3:
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 30/i);
                        if(special == 1){
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 2f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 10;
                        }
                        else{
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 0.9f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 5;
                        }
                        yield return new WaitForSeconds(5);
                    }
                    break;
                case 4:
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 30/i);
                        if(special == 1){
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 2f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 10;
                        }
                        else{
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 1.2f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 5;
                        }
                        yield return new WaitForSeconds(5);
                    }
                    break;
                case 5:
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 5);
                        if(special == 1){
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 2f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 10;
                        }
                        else{
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 1.5f;
                            aux.gameObject.GetComponent<Enemy>().carrots = 5;
                        }
                        yield return new WaitForSeconds(5);
                    }
                    break;
            }
            // Tempo de espera entre waves
            yield return new WaitForSeconds(10);
        }
        // Se o player conseguir sobreviver a todas as waves ele ganha a fase
        GameManager.instance.Win();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
