using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Colliders : MonoBehaviour {

    GameObject muroVerticalAzul;
    private GameObject agoravai;

    void Start() {
        //Essa parte do muro esta ligado na cena
        muroVerticalAzul = GameObject.Find("muro-azul-vertical");
        muroVerticalAzul.SetActive(false);

        
    }

    void OnCollisionEnter2D (Collision2D col)
	{
        //retorna a cena atual
        Scene scene = SceneManager.GetActiveScene();

        //Logs
        Debug.Log("collision name= " + col.gameObject.name + " - scene name= " + scene.name);

        if (col.gameObject.name == "objeto-desejado")
        {
            Destroy(col.gameObject);
        }

        switch (scene.name)
        {
            case "Cena1":
                if (col.gameObject.name == "botao-porta-topo") {
                    Destroy(GameObject.Find("muro-inferior"));
                }
                break;

            case "Cena3":
                if (col.gameObject.name == "botao-porta-topo")
                {
                    Destroy(GameObject.Find("plataforma-azul"));
                    muroVerticalAzul.SetActive(true);
                }
                break;
            /*
            case "Cena4":
                if (col.gameObject.name == "botao-porta-topo-elevador")
                {
                    Debug.Log("inicia elevador");
                    Elevador elevador = new Elevador();
                    agoravai = GameObject.Find("plataforma-movel");
                    elevador.MoverElevador(agoravai);
                    Debug.Log("para elevador");
                }
                break;
             */
        }

    }

}
