using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyPrefab2;
    [SerializeField] private int Wave1;
    [SerializeField] private int Wave2;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
        
    }   

    IEnumerator spawn(){
        for(int i = 0; i<5; i++){
            if(i%2 == 0){
                for(int j = 0; j <= Wave1; j++){
                    Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity).SetActive(true);
                    yield return new WaitForSeconds(2);
                }
            }
            else{
                for(int j = 0; j <= Wave2; j++){
                    Instantiate(enemyPrefab2, new Vector3(0, 0, 0), Quaternion.identity).SetActive(true);
                    yield return new WaitForSeconds(2);
                }
            }
            yield return new WaitForSeconds(10);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
