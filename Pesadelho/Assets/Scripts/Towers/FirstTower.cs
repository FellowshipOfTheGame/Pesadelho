using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTower : MonoBehaviour{

	GameObject[] cannon = new GameObject[8];
	public GameObject bullet;
	public float fireRate;

    SpriteRenderer _sprite;
    [SerializeField] private Sprite[] rotation;

    [SerializeField] private AudioSource tiro;


    // Start is called before the first frame update
    void Start(){

        _sprite = GetComponent<SpriteRenderer>();

    	//Lê todos os canhões da torre
    	for(int i=0;i<8;i++)
    		cannon[i] = transform.Find("Cannon_"+i).gameObject;

    	//Chama o método "Attack" a cada x segundos
    	InvokeRepeating("Attack", fireRate, fireRate);
        
    }

    // Update is called once per frame
    void Update(){

        
    }

    public void Attack(){
	
		//Lê o alvo atual da torre
		Enemy target = transform.Find("Range").gameObject.GetComponent<Tower_Range>().Target();

        //Se existir um alvo
		if(target != null){

            //Calcula o ângulo do alvo em relação à torre e define o canhão a ser utilizado
            Vector3 targetDir = (target.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(new Vector3(1, 0, 0), targetDir);
            int shootingCannon = 0;

            //De preferencia encontre uma forma mais eficiente pq olha isso mano
            if(transform.position.y <= target.transform.position.y){

                if(angle >= 0 && angle < 22.5f)
                    shootingCannon = 2;
                else if(angle >= 22.5f && angle < 67.5f)
                    shootingCannon = 1;
                else if(angle >= 67.5f && angle < 112.5f)
                    shootingCannon = 0;
                else if(angle >= 112.5f && angle < 157.5f)
                    shootingCannon = 7;
                else if(angle >= 157.5f && angle < 180)
                    shootingCannon = 6;

            }
            else{

                if(angle >= 0 && angle < 22.5f)
                    shootingCannon = 2;
                else if(angle >= 22.5f && angle < 67.5f)
                    shootingCannon = 3;
                else if(angle >= 67.5f && angle < 112.5f)
                    shootingCannon = 4;
                else if(angle >= 112.5f && angle < 157.5f)
                    shootingCannon = 5;
                else if(angle >= 157.5f && angle < 180)
                    shootingCannon = 6;

            }
            _sprite.sprite = rotation[shootingCannon];

            //Cria um tiro e define o alvo dele
    		GameObject tmp = (GameObject) Instantiate(bullet, cannon[shootingCannon].transform.position, Quaternion.identity);
    		tmp.GetComponent<Bullet>().SetTarget(target.transform.position);
            tiro.Play(0);
		}

    }

}
