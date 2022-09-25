using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour
{

    [SerializeField] public Text Score, Lifes, Level;
    [SerializeField] gameManager gm;
    [SerializeField] FixedJoystick joystick;


    // Update is called once per frame
    void Update()
    {
        updateScoreText();
        updateLifes();
        updateLevel();

        if(gm == null)
        {
            gm = FindObjectOfType<gameManager>();
        }

    }

    public void updateScoreText()
    {
        Score.text = "Score: " + gm.score.ToString();
    }

    public void updateLifes()
    {
        Lifes.text = "X "+ gm.Lifes.ToString();
    }
    
    public void updateLevel()
    {
        Level.text = "Level: " + gm.level.ToString();
    }

}
