using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameControler : MonoBehaviour
{

    // Propriedades do Chão
    [Header("Configuração do chão")]

    public float            _chaoDestruido;
    public float            _chaoTamanho;
    public float            _chaoVelocidade;
    public GameObject       _chaoPrefab;
   

    [Header("Configuração do Obstáculo")]
    public float            _obstaculoTempo;
    public GameObject       _obstaculoPrefab;
    public float            _obstaculoVelocidade;

    [Header("Configuração do Coin")]
    public float            _coinTempo;
    public GameObject       _coinPrefab;
    public float            _distanciaOffSet;

    [Header("Configuração do UI")]
    public int              _pontosPlayer;
    public Text             _txtPontos;
    public int              _vidasPlayer;
    public Text             _txtVidas;
    public Text             _txtMetros;
    public Text             _txtHighScore;
    public GameObject       _screenGameOver;
    public GameObject       _buttonRetry;
    public GameObject       _buttonQuit;


    [Header("Controle de Disctância")]
    public int              _metrosPercorridos = 0;

    [Header("Controle de Sons e efeitos")]
    public AudioSource        _fxGame;
    public AudioClip          _fxGameOver;
    public AudioClip          _fxMoedaColetada;
    public AudioClip          _fxJump;


    // Start is called before the first frame update
    void Start()
    {   

        StartCoroutine("SpawnObstaculo");
        InvokeRepeating("DistanciaPercorrida", 0f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        GameObject[] CoinsInTheMap = GameObject.FindGameObjectsWithTag("Coin");

        if (CoinsInTheMap.Length == 0)
        {
           SpawnCoin();
        }

        if(_vidasPlayer == 0){

            int highScore = PlayerPrefs.GetInt("HighScore");
            _txtHighScore.text = "High Score: " + highScore.ToString();
            
            Time.timeScale = 0;
            _screenGameOver.SetActive(true);
            _buttonRetry.SetActive(true);
            _buttonQuit.SetActive(true);
            
        }

    }

    IEnumerator SpawnObstaculo()
    {
        yield return new WaitForSeconds(_obstaculoTempo);

        GameObject ObjetoObstaculoTemp = Instantiate(_obstaculoPrefab);
        StartCoroutine("SpawnObstaculo");
    }

   void SpawnCoin()
    {

        // int moedasAleatorias = UnityEngine.Random.Range(1, 5);

        // for (int contagem = 1; contagem <= moedasAleatorias; contagem++)
        // {

            GameObject _objetoSpawn = Instantiate(_coinPrefab);

            // Usa a posição original do _coinPrefab como referência
            // float deslocamentoX = espacamentoX * contagem;
            _objetoSpawn.transform.position = new UnityEngine.Vector3(_distanciaOffSet, _objetoSpawn.transform.position.y, 0);

            _objetoSpawn.transform.localScale = _coinPrefab.transform.localScale;
            _objetoSpawn.transform.rotation = _coinPrefab.transform.rotation;
        
    }

    

    public void Pontos(int _qtdPontos)
    {
        _pontosPlayer += _qtdPontos;
        _txtPontos.text = _pontosPlayer.ToString();
    }

    void DistanciaPercorrida()
    {
        _metrosPercorridos++;
        _txtMetros.text = _metrosPercorridos.ToString() + " m";

        if((_metrosPercorridos % 50) == 0)
        {
            _chaoVelocidade +=  0.5f;
            _obstaculoTempo -=  0.5f;
            _obstaculoVelocidade += 0.5f;
        }
    }

} 
