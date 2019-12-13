using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Button_Manager : MonoBehaviour
{
    public void NewGameButton(string newGame)
    {
        SceneManager.LoadScene(newGame);
    }
    public void EasyButton(string easyButton)
    {
        //SceneManager.LoadScene(easyButton);
        Debug.Log("Yhgyugi");
    }
}
