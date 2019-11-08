using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Tower : MonoBehaviour{

    Player _player;
    GameObject _placeholder;
    SpriteRenderer _placeholder_sprite;

    [SerializeField] GameObject[] towers = null;

    private bool visible;
    private int tower;

    // Start is called before the first frame update
    void Start(){

        _player = gameObject.GetComponent<Player>();
        _placeholder = transform.Find("Placeholder").gameObject;
        _placeholder_sprite = _placeholder.GetComponent<SpriteRenderer>();

        visible = false;
        _placeholder_sprite.enabled = this.visible;

    }

    // Update is called once per frame
    void Update(){

        ReadKeys();
        UpdateDirection();
        
    }

    void ReadKeys(){

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            this.SetTower(0);
            this.SetVisibility(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape) && this.visible){
            this.SetVisibility(false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && this.visible){
            PlaceTower(this.tower);
        }

    }

    void UpdateDirection(){

        int playerDirection = _player.GetDirection();
        float offset_x = 0, offset_y = 0;

        if(playerDirection == 0)
            offset_y = 0.6f;
        if(playerDirection == 1)
            offset_x = 0.6f;
        if(playerDirection == 2)
            offset_y = -0.6f;
        if(playerDirection == 3)
            offset_x = -0.6f;

        _placeholder.transform.position = new Vector3(_player.transform.position.x+offset_x, _player.transform.position.y+offset_y, _player.transform.position.z);

    }

    void PlaceTower(int tower){

        bool blocked = transform.Find("Placeholder").gameObject.GetComponent<Verify_BlockTower>().Blocked();

        if(!blocked && _player.CurrentDreamPower() >= towers[tower].GetComponent<Tower>().NecessaryPower() && PlayerPrefs.GetInt("Carrots") >= 10){
            Instantiate(towers[tower], _placeholder.transform.position, Quaternion.identity);
            this.SetVisibility(false);

            _player.DreamPower(-(towers[tower].GetComponent<Tower>().NecessaryPower()));
            _player.AddCarrots(-10);

        }

    }

    public void SetTower(int tower){

        this.tower = tower;

    }

    public void SetVisibility(bool visible){

        if(visible != this.visible){

            _player.speed = visible ? _player.speed/2 : _player.speed*2;
            _placeholder_sprite.enabled = visible;

            this.visible = visible;

        }

    }

}
