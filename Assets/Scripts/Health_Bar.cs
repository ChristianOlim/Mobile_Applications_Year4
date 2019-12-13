using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health_Bar : MonoBehaviour

{
    /*
    public bool playerDead;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        playerDead = false;
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        // Here are the parameters of how the player can die
        // If the players falls below y = -6 then they have died
        if (gameObject.transform.position.y < -6)
        {
            Death();
        }
        

    }
    void Death()
    {
        /*
        // This will return a message on the console to say the player has fallen
        Debug.Log("Player Has Slipt");
        // This will wait one second before return the following message
        yield return new WaitForSeconds(1);
        // This will return a message on the console to say the player has died
        Debug.Log("Player Has Died");
        */
        // Restarts level
        SceneManager.LoadScene("Main");
    }
}
