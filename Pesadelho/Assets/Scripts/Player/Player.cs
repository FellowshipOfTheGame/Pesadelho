using System.Collections;
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

    private int health = 3;
    private int carrots = 0;
    private int direction = 0;
    private bool invencible = false;

    private Animator animator;

	void Awake(){

		_rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();

        PlayerPrefs.SetInt("Health", this.health);
        PlayerPrefs.SetInt("Carrots", this.carrots);

        animator = GetComponent<Animator>();

	}

    // Start is called before the first frame update
    void Start(){

        
    }

    // Update is called once per frame
    void Update(){

        CheckIdle();

    	//GetAxisRaw has no smoothing
    	_horizontalInput 	= Input.GetAxisRaw("Horizontal");
        _verticalInput 		= Input.GetAxisRaw("Vertical");

        if(_verticalInput == 0 && _horizontalInput == 0){
            animator.SetBool("Running", false);
        }
        else{
            animator.SetBool("Running", true);
        }
        if(_horizontalInput != 0)
            _verticalInput = 0;

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
