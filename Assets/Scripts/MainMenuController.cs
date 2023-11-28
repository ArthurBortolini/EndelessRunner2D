using System.Diagnostics;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string         Game = "Game";
    [SerializeField ]private GameObject     _painelMenuInicial;
    [SerializeField] private GameObject      _painelRanking;
    [SerializeField] private GameObject      _painelSobre;

    public void Jogar()
    {
        SceneManager.LoadScene(Game);
    }

    public void Sobre()
    {
        UnityEngine.Debug.Log("Abriu, mas não funcionou");
        _painelMenuInicial.SetActive(false);
        _painelSobre.SetActive(true);
    }

    public void SairSobre()
    {
        _painelSobre.SetActive(false);
        _painelMenuInicial.SetActive(true);
    }

    public void Ranking()
    {
        _painelMenuInicial.SetActive(false);
        _painelRanking.SetActive(true);

    }

    public void SairRanking()
    {
        _painelRanking.SetActive(false);
        _painelMenuInicial.SetActive(true);
    }

    public void Sair()
    {   
        UnityEngine.Debug.Log("Saiu do Jogo");

        Application.Quit();
    }


}
