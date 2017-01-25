using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public void CarregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

}
