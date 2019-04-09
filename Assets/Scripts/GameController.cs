using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerController _PlayerController;
    
    [Header("Configuração das Plataformas")]
    public float velocidadePlataforma;
    public float distanciaDestruir, tamanhoPlataforma;
    public GameObject[] plataformaPrefab;
    public GameObject plataformaFim;
    public int contadorPlataformasLevel;

    [Header("Configuração Globais")]
    public int score;
    public Text txtScore;
    public int numVidas;
    public GameObject[] vidas;

    [Header("Configuração do FX Sound")]
    public AudioSource fxSource;
    public AudioClip fxPontos;
    public AudioClip fxOvo;
    public AudioClip fxDanos;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerController = FindObjectOfType(typeof(PlayerController)) as PlayerController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DanoPontuar(int qtdPontos)
    {
        if((score - qtdPontos) < 0)
        {
            score = 0;
        }
        else
        {
            score -= qtdPontos;
        }
       
        txtScore.text = "Score: " + score.ToString();
        fxSource.PlayOneShot(fxDanos);

        if (numVidas > 1)
        {
            vidas[numVidas - 1].gameObject.SetActive(false);
            numVidas--;
        }
        else if(numVidas == 1)
        {
            MudarCena("03_GameOver");
        }
        

    }

    public void Pontuar(int qtdPontos, int m)
    {
        score += qtdPontos;
        txtScore.text = "Score: " + score.ToString();
        if (m == 0)
        {
            fxSource.PlayOneShot(fxPontos);
        }
        else if (m == 1)
        {
            fxSource.PlayOneShot(fxOvo);
        }
        
    }

    public void MudarCena(string cenaDestino)
    {
        SceneManager.LoadScene(cenaDestino);
    }

}
