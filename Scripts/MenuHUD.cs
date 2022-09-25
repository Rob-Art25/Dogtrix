using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHUD : MonoBehaviour
{
    [SerializeField]
    public Text bestSocreTxt;


    private void Update()
    {
        showBestScore();
    }

    public void startGame()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().name == "Menú")
        {
            if (FindObjectOfType<gameManager>() != null)
            {
                FindObjectOfType<gameManager>().gameStart();
            }
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().name == "Game Over")
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void showBestScore()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            bestSocreTxt.text = "Best Score: " + FindObjectOfType<gameManager>().BestScore.ToString();
        }
    }

}
