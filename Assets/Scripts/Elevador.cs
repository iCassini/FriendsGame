using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{

    private readonly int _velocidade = 1;

    public void MoverElevador(GameObject game, float posicaoEixoY)
    {
        game.transform.position = Vector3.Lerp(game.transform.position, new Vector3(game.transform.position.x, posicaoEixoY, game.transform.position.y), Time.deltaTime * _velocidade );
    }

}
