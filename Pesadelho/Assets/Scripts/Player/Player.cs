﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	Rigidbody2D _rb;
    SpriteRenderer _sprite;

    [SerializeField] Sprite front;
    [SerializeField] Sprite back;
    [SerializeField] Sprite right;
    [SerializeField] Sprite left;

	float _horizontalInput, _verticalInput;

	public float speed;
    public float blinkRate;

    public int spawn_x;
    public int spawn_y;

    private int health = 3;
    private int carrots = 0;
    private int maxpower = 100;
    private int dreampower = 100;
    private int direction = 0;
    private bool invencible = false;
    private int respawn_counter = 0;

    private Animator animator;

	void Awake(){

		_rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        PlayerPrefs.SetInt("Health", this.health);
        PlayerPrefs.SetInt("Carrots", this.carrots);
        PlayerPrefs.SetInt("DreamPower", this.dreampower);
        PlayerPrefs.SetInt("Respawn_Counter", this.respawn_counter);

        _rb.position = new Vector2(spawn_x, spawn_y);

        animator = GetComponent<Animator>();

	}

    // Start is called before the first frame update
    void Start(){

        
    }

    // Update is called once per frame
    void Update(){

        if(health > 0){
              CheckIdle();


            if(_verticalInput == 0 && _horizontalInput == 0){
                animator.SetBool("Running", false);
            }
            else{
                animator.SetBool("Running", true);
            }
            if(_horizontalInput != 0)
                _verticalInput = 0;

            //GetAxisRaw has no smoothing
            _horizontalInput 	= Input.GetAxisRaw("Horizontal");
            _verticalInput 		= Input.GetAxisRaw("Vertical");

            _rb.velocity = new Vector2(_horizontalInput*speed, _verticalInput*speed);

            SetDirection(_horizontalInput, _verticalInput);

        }

        
    }

    void OnTriggerEnter2D(Collider2D col){

        if(col.tag == "Enemy"){
            Damage();
        }

    }

    void Damage(){

        if(!invencible && health > 0){
            
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

        if(health > 0)
            _sprite.enabled = !_sprite.enabled;

    }

    void StopBlinking(){

        if(health > 0){
            _sprite.enabled = true;
            invencible      = false;
        }

        CancelInvoke("Blink");

    }

    void Die(){

        this.gameObject.SetActive(false);
        respawn_counter = 10;

        PlayerPrefs.SetInt("Respawn_Counter", this.respawn_counter);

        //Atualiza o contador de respawn
        InvokeRepeating("RespawnCounter", 1, 1);
        //Revive após 10 segundos
        Invoke("Respawn", 10);

    }

    void Respawn(){

        this.gameObject.SetActive(true);
        _rb.position = new Vector2(spawn_x, spawn_y);

        this.respawn_counter= 0;
        this.invencible     = false;
        this.health         = 3;
        this.maxpower       -= 20;
        this.dreampower     = this.dreampower > this.maxpower ? this.maxpower : this.dreampower;

        PlayerPrefs.SetInt("Health", this.health);
        PlayerPrefs.SetInt("DreamPower", this.dreampower);
        PlayerPrefs.SetInt("Respawn_Counter", this.respawn_counter);
        CancelInvoke("RespawnCounter");

    }

    void RespawnCounter(){

        this.respawn_counter -= 1;
        PlayerPrefs.SetInt("Respawn_Counter", this.respawn_counter);

    }

    public void AddCarrots(int carrots){

        this.carrots += carrots;
        PlayerPrefs.SetInt("Carrots", this.carrots);

    }
    public void DreamPower(int power){

        this.dreampower += power;
        PlayerPrefs.SetInt("DreamPower", this.dreampower);

        if(this.dreampower > this.maxpower) this.dreampower = this.maxpower;
        if(this.dreampower < 0) this.dreampower = 0;

    }

    public int MaximumPower(){

        return this.maxpower;

    }

    public int CurrentDreamPower(){

        return this.dreampower;

    }

    void SetDirection(float horizontal, float vertical){

        if(vertical > 0) // Direita
            this.direction = 0;
        if(horizontal > 0) // Cima
            this.direction = 1;
        if(vertical < 0) // Esquerda
            this.direction = 2;
        if(horizontal < 0) // Baixo
            this.direction = 3;
            
    }

    public int GetDirection(){

        return this.direction;

    }

    public void CheckIdle(){
        int aux;
        aux = GetDirection();

        switch(aux){
            case 0: // Cima
                animator.SetBool("LastDown", false);
                animator.SetBool("LastUp", true);
                animator.SetBool("LastRight", false);
                animator.SetBool("LastLeft", false);
                _sprite.sprite = back;
                break;
            case 1: // Direita
                animator.SetBool("LastDown", false);
                animator.SetBool("LastUp", false);
                animator.SetBool("LastRight", true);
                animator.SetBool("LastLeft", false);
                _sprite.sprite = right;
                break;
            case 2: // Baixo
                animator.SetBool("LastDown", true);
                animator.SetBool("LastUp", false);
                animator.SetBool("LastRight", false);
                animator.SetBool("LastLeft", false);
                _sprite.sprite = front;                
                break;
            case 3: // Esquerda
                animator.SetBool("LastDown", false);
                animator.SetBool("LastUp", false);
                animator.SetBool("LastRight", false);
                animator.SetBool("LastLeft", true);
                _sprite.sprite = left;                
                break;
            default:
                break;
        }
    }

}
