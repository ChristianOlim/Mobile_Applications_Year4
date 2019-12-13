using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class New_Game_Button : MonoBehaviour
{
    public void EasyButton(string easyButton)
    {
        SceneManager.LoadScene(easyButton);
    }
    /*public void MediumButton(string Main)
    {
        SceneManager.LoadScene(Main);
    }
    public void HardButton(string Main)
    {
        SceneManager.LoadScene(Main);
    }*/
}

