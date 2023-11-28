using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public Transform _pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_pauseMenu.gameObject.activeSelf)
            {
                _pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                _pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeGame()
    {
        _pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void RestartGameOver()
{
    // Certifique-se de desativar o menu de pausa antes de reiniciar
    _pauseMenu.gameObject.SetActive(false);

    // Reinicie a cena
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    // Configure o Time.timeScale após reiniciar a cena
    StartCoroutine(WaitForSceneReload());
}

private IEnumerator WaitForSceneReload()
{
    // Aguarde um pequeno intervalo antes de configurar o Time.timeScale
    yield return null;

    // Certifique-se de configurar o Time.timeScale após reiniciar a cena
    Time.timeScale = 1;
}
}
