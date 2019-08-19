using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
        
    }

    IEnumerator spawn(){
        for(int i = 0; i<5; i++){
            Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity).SetActive(true);
            yield return new WaitForSeconds(3);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
