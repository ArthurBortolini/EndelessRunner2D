using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private GameControler _gameController;

    private Rigidbody2D _moedasRB2D;

    public float destroyXPosition = -10f;


    // Start is called before the first frame update
    void Start()
    {  
        _gameController = FindObjectOfType(typeof(GameControler)) as GameControler;

        
        _moedasRB2D = GetComponent<Rigidbody2D>();
        _moedasRB2D.velocity = new Vector2(-6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
           if (transform.position.x < destroyXPosition)
        {
            Destroy(gameObject);
            Debug.Log("Moeda foi destruída!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _gameController._fxGame.PlayOneShot(_gameController._fxMoedaColetada);
            _gameController.Pontos(1);
            Debug.Log("Pegou a moeda");
            Destroy(this.gameObject);
        }
    } 
}
