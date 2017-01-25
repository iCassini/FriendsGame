using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float Velocidade;
    public float AlturaPulo;

    private bool _ativarElevador = false;
    private GameObject _muroAmarelo;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Velocidade * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Velocidade * Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        var scene = SceneManager.GetActiveScene();
        var rb = GetComponent<Rigidbody2D>();
        var cena = gameObject.AddComponent<GameController>();
        
        //Controle de pulo
        if ( ( coll.gameObject.CompareTag("TagSolo") || coll.gameObject.name == "botao-porta-topo" || coll.gameObject.CompareTag("TagPlataforma") || coll.gameObject.name == "plataforma-movel" || coll.gameObject.name == "plataforma-switch") && (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow))  || (Input.GetKey(KeyCode.Space)) ) )
        {
            rb.AddForce(Vector3.up * AlturaPulo);
        }

        if (coll.gameObject.name == "objeto-desejado")
        {
            Destroy(coll.gameObject);

            //Após o objeto ser destruído, esta parte controla a cena que irá redirecionar
            if (scene.name == "Cena1") cena.CarregaCena("Cena2");
            if (scene.name == "Cena2") cena.CarregaCena("Cena4");
        }

        switch (scene.name)
        {
            case "Cena1":
                //Controle de colisão com o botão para a abertura de portas
                if (coll.gameObject.name == "botao-porta-topo")
                {
                    Destroy(GameObject.Find("muro-inferior"));
                }
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D colisor)
    {
        var scene = SceneManager.GetActiveScene();

        if (scene.name == "Cena4")
        {

            var elevador = gameObject.AddComponent<Elevador>();

            //Controla Movimentação do Elevador
            if (_ativarElevador == false) { 
                if (colisor.gameObject.name == "botao-porta-topo-elevador")
                {
                    elevador.MoverElevador(GameObject.Find("plataforma-movel"), -78.5f);
                    _ativarElevador = true;
                }
            }
            else
            {
                if (colisor.gameObject.name == "plataforma-switch") { 
                    elevador.MoverElevador(GameObject.Find("plataforma-movel"), 75);
                    _ativarElevador = false;
                }
            }

            //Colisão com power up
            if (colisor.gameObject.name == "PowerUpYellow")
            {
                Destroy(colisor.gameObject);
                elevador.MoverElevador(GameObject.Find("muro-movel"),60 );
                _muroAmarelo = GameObject.Find("muro-amarelo");
                _muroAmarelo.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
    }
}
