using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstaculoController : MonoBehaviour
{
    private Rigidbody2D ObstaculoRB;
    public float destroyXPosition = -10f; // Defina a posição X na qual o objeto será destruído.

    private GameControler _gameController;
    //private GameController _gameController;

    private CameraShaker _cameraShaker;

    // Start is called before the first frame update
    void Start()
    {
        ObstaculoRB = GetComponent<Rigidbody2D>();

        _gameController = FindObjectOfType(typeof(GameControler)) as GameControler;

        _cameraShaker = FindObjectOfType(typeof(CameraShaker)) as CameraShaker;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        MoveObjeto();
    }

    void MoveObjeto()
    {
        transform.Translate(Vector2.left * _gameController._obstaculoVelocidade * Time.smoothDeltaTime);
      //transform.Translate(Vector2.left * _gameController.ObstaculoVelocidade * Time.smoothDeltaTime);

        // Verifique a posição X do objeto e destrua-o se estiver além da posição especificada.
        if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
            UnityEngine.Debug.Log("Pedra foi destruída!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _gameController._vidasPlayer--;

            if (_gameController._vidasPlayer <= 0)
            {
                UnityEngine.Debug.Log("Fim do Jogo!");
                _gameController._vidasPlayer = 0;  // Certifique-se de que as vidas não são negativas
                _gameController._txtVidas.text = "0";
            }
            else
            {
                _gameController._txtVidas.text = _gameController._vidasPlayer.ToString();
                UnityEngine.Debug.Log("Tocou no obstáculo!");
                _cameraShaker.ShakeIt();
            }
        }
    }
}
