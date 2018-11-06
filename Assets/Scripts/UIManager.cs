using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text scoreText;
    int score;
    bool isGameOver;
    // array of all buttons for activation/dectivation
    public Button[] buttons;
	// Use this for initialization
	void Start () {
        isGameOver = false;
        score = 0;


        //calls another function and specifiec whento rpeart
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
	}

    public void Pause() {
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
        }
        else if (Time.timeScale ==0) {
            Time.timeScale = 1;
        }
     }

    public void Play() {
        // loads in a scene
        //Application.LoadLevel("level1");
        SceneManager.LoadScene("level1");
    }



    public void Menu() {

        SceneManager.LoadScene("MenuScene");
    }


    public void Quit()
    {

        Application.Quit();
    }

    //
    void scoreUpdate() {
        if (!isGameOver) {
            score += 1;
        }
    
    }

    public void gameOver() {
        isGameOver = true;
        foreach (Button b in buttons) {
            b.gameObject.SetActive(true);
        }
       // SceneManager.LoadScene("GameOverScene");

    }
}
