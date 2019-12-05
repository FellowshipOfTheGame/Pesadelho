using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Change(string scene){

        SceneManager.LoadScene(scene);

        //Application.LoadLevel(scene);

    }

    public void Exit(){

        Application.Quit();

    }

}
