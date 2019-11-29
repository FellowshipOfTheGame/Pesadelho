using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource musicWin;

    [SerializeField] private AudioSource musicLose;

    [SerializeField] private bool playing = false;
    public bool Playing { get => playing; set => playing = value; }
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject WinCanvas;
    [SerializeField] private Player _player;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        music.Play(0);
        _player.AddCarrots(50);
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
        musicWin.Play(0);
        //StartCoroutine(esperar(5));
        WinCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    
    //Função para parar o jogo e mostrar a tela de game over
    public void GameOver(){
        Playing = false;
        musicLose.Play(0);
        //StartCoroutine(esperar(3));
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
}
