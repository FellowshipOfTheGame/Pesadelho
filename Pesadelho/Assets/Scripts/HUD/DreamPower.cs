using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DreamPower : MonoBehaviour
{

    public Slider dreampowerbar;

    // Start is called before the first frame update
    void Start()
    {

        dreampowerbar.value = PlayerPrefs.GetInt("DreamPower");
               
    }

    // Update is called once per frame
    void Update()
    {

        dreampowerbar.value = PlayerPrefs.GetInt("DreamPower");
        
    }
}
