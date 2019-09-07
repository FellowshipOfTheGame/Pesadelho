using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    // Variaves para decidir o número de inimigos de cada wave
    [SerializeField] private int[] Wave;
    int rand;
    int special;

    // Start is called before the first frame update
    void Start()
    {   
        // Criar e iniciar uma rotina para usar tempo entre as waves
        StartCoroutine(spawn());
    }   

    /* IEnumerator spawnEnemy(int i, int speed, float time){
        for(int j = 0; j < Wave[i-1]; j++){
            GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            aux.SetActive(true);
            special = Random.Range(1, 30/i);
            if(special == 1)
                aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 6;
            else
                aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = speed;
            yield return new WaitForSeconds(time);
        }
    }*/

    IEnumerator spawn(){
        for(int i = 1; i<=5; i++){
            rand = Random.Range(1, 5);
            Debug.Log(rand+" "+i);
            switch(rand){
                case 1:
                    //StartCoroutine(spawnEnemy(i, 1, 2));
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 30/i);
                        if(special == 1)
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 6;
                        else
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 1;
                        yield return new WaitForSeconds(2);
                    }
                    break;
                case 2:
                    //StartCoroutine(spawnEnemy(i, 2, 1.5f));                
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 30/i);
                        if(special == 1)
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 6;
                        else
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 2;
                        yield return new WaitForSeconds(1.5f);
                    }
                    break;
                case 3:
                    //StartCoroutine(spawnEnemy(i, 3, 1.5f));
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 30/i);
                        if(special == 1)
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 6;
                        else
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 3;
                        yield return new WaitForSeconds(1.5f);
                    }
                    break;
                case 4:
                    //StartCoroutine(spawnEnemy(i, 4, 1));
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 30/i);
                        if(special == 1)
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 6;
                        else
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 4;
                        yield return new WaitForSeconds(1);
                    }
                    break;
                case 5:
                    //StartCoroutine(spawnEnemy(i, 5, 1));
                    for(int j = 0; j < Wave[i-1]; j++){
                        GameObject aux = Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        aux.SetActive(true);
                        special = Random.Range(1, 5);
                        if(special == 1)
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 6;
                        else
                            aux.gameObject.GetComponent<Enemy_Control>().MoveSpeed = 5;
                        yield return new WaitForSeconds(1);
                    }
                    break;
            }
            yield return new WaitForSeconds(10);
        }
        GameManager.instance.Win();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
