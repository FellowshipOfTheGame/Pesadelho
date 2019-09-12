using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private bool playing = false;
    public bool Playing { get => playing; set => playing = value; }
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject WinCanvas;
    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        // Tirar da tela os canvas e criar a instancia do game manager
        instance = this;
        GameOverCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        Playing = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Função para ganhar o jogo
    public void Win(){
        Playing = false;
        Time.timeScale = 0;
        WinCanvas.SetActive(true);
    }
    
    //Função para parar o jogo e mostrar a tela de game over
    public void GameOver(){
        Playing = false;
        Time.timeScale = 0;
        GameOverCanvas.SetActive(true);
    }
}
