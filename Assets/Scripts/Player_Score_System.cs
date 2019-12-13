using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score_System : MonoBehaviour
{
    // Time remaining for level
    private float timeRemaining = 120;
    public int score = 0;
    public GameObject timeRemainingUI;
    public GameObject scoreUI;

    // Start method
    private void Start()
    {
        Save_Load_Game.saveLoadGame.LoadOption();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        // This will get the time and score to then post it to the screen
        timeRemainingUI.gameObject.GetComponent<Text>().text = ("Time Remaining: " + (int)timeRemaining);
        scoreUI.gameObject.GetComponent<Text>().text = ("Your Score: " + score);

        if (timeRemaining < 0.1f)
        {
            // Restarts the user
            SceneManager.LoadScene("Main");
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        // This will trigger your overal score
        if (trig.gameObject.name == "End_Of_Level")
        {
            CalculateScore();
            Save_Load_Game.saveLoadGame.SaveOption();
        }
        // This will add one coin to your score
        if (trig.gameObject.tag == "coin")
        {
            score += 1;
            Destroy(trig.gameObject);
        }
    }

    void CalculateScore()
    {
        score = score + (int)(timeRemaining * 10);
        Save_Load_Game.saveLoadGame.totalScore = score + (int)(timeRemaining * 10);
        Save_Load_Game.saveLoadGame.SaveOption();
    }
}
