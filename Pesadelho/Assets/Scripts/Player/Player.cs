using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	Rigidbody2D _rb;
    SpriteRenderer _sprite;

	float _horizontalInput, _verticalInput;

	public float speed;
    public float blinkRate;

    private int health = 3;
    private int carrots = 0;
    private int direction = 0;
    private bool invencible = false;

	void Awake(){

		_rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        PlayerPrefs.SetInt("Health", this.health);
        PlayerPrefs.SetInt("Carrots", this.carrots);

	}

    // Start is called before the first frame update
    void Start(){

        
    }

    // Update is called once per frame
    void Update(){

    	//GetAxisRaw has no smoothing
    	_horizontalInput 	= Input.GetAxisRaw("Horizontal");
        _verticalInput 		= Input.GetAxisRaw("Vertical");

        _rb.velocity = new Vector2(_horizontalInput*speed, _verticalInput*speed);

        SetDirection(_horizontalInput, _verticalInput);

    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.tag == "Enemy"){
            Damage();
        }

    }

    void Damage(){

        if(!invencible){
            
            health--;
            PlayerPrefs.SetInt("Health", this.health);

            InvokeRepeating("Blink", 0, blinkRate);
            Invoke("StopBlinking", 2);

            invencible = true;

            if(health == 0)
                Die();

        }

    }

    void Blink(){

        _sprite.enabled = !_sprite.enabled;

    }

    void StopBlinking(){

        _sprite.enabled = true;
        invencible      = false;

        CancelInvoke("Blink");

    }

    void Die(){

        //Destroy(gameObject);

    }

    public void AddCarrots(int carrots){

        this.carrots += carrots;
        PlayerPrefs.SetInt("Carrots", this.carrots);

    }

    void SetDirection(float horizontal, float vertical){

        if(vertical > 0)
            this.direction = 0;
        if(horizontal > 0)
            this.direction = 1;
        if(vertical < 0)
            this.direction = 2;
        if(horizontal < 0)
            this.direction = 3;
            
    }

    public int GetDirection(){

        return this.direction;

    }

}
