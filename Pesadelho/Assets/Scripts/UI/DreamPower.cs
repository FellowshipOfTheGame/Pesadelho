using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamPower : MonoBehaviour
{

    private GameObject dreambar;
    private float current_value;

    // Start is called before the first frame update
    void Start()
    {

        dreambar        = gameObject.transform.Find("dreambar").gameObject;
        current_value   = PlayerPrefs.GetInt("DreamPower");
               
    }

    // Update is called once per frame
    void Update()
    {

        if(current_value != PlayerPrefs.GetInt("DreamPower"))
            current_value += current_value > PlayerPrefs.GetInt("DreamPower") ? -2 : 2;

        dreambar.GetComponent<Image>().fillAmount = ((float)current_value)/100;
        
    }
}
