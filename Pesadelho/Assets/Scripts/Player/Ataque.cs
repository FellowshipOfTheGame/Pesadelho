using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{

    Player _player;
    Place_Tower _pt;
    GameObject _hitbox;

    // Start is called before the first frame update
    void Start()
    {

        _player = gameObject.GetComponent<Player>();
        _pt     = gameObject.GetComponent<Place_Tower>();

        _hitbox = transform.Find("Ataque").gameObject;

        _hitbox.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        UpdateDirection();

        if(Input.GetKeyDown(KeyCode.Space) && !_pt.Visible() && !_hitbox.activeSelf){
            Atacar();
        }
        
    }
    void UpdateDirection(){

        int playerDirection = _player.GetDirection();
        float offset_x = 0, offset_y = 0;

        if(playerDirection == 0)
            offset_y = 0.2f;
        if(playerDirection == 1)
            offset_x = 0.3f;
        if(playerDirection == 2)
            offset_y = -0.5f;
        if(playerDirection == 3)
            offset_x = -0.3f;

        _hitbox.transform.position = new Vector3(_player.transform.position.x+offset_x, _player.transform.position.y+offset_y, _player.transform.position.z);

    }

    void Atacar(){

        if (!_hitbox.activeSelf){

            _hitbox.SetActive(true);
            Invoke("Atacar", .5f);

        }
        else{

            _hitbox.SetActive(false);

        }

    }

}
