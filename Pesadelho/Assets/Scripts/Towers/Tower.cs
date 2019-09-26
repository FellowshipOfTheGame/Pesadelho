using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    GameObject _remove;
    SpriteRenderer _sprite_remove;
    private bool remove_visibility;

    [SerializeField] private int necessarypower;

    // Start is called before the first frame update
    void Start()
    {
        
        _remove = transform.Find("RemoveTower").gameObject;
        _sprite_remove = _remove.GetComponent<SpriteRenderer>();

        remove_visibility = false;
        _sprite_remove.enabled = this.remove_visibility;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRemoveVisibility(bool visibility){

        if(visibility != this.remove_visibility){

            _sprite_remove.enabled = visibility;
            this.remove_visibility = visibility;

        }

    }

    public int NecessaryPower(){

        return this.necessarypower;

    }

}
