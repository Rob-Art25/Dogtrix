using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    [SerializeField] public int Lifes, score;
    public int BestScore, level;
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] AudioSource coin;
 
    private int timer;

    private void Awake() // Singleton
    {
        int gameManagerCount = FindObjectsOfType<gameManager>().Length;
        if (gameManagerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameStart();
    }        

    private void FixedUpdate()
    {
        bestScore();
    }

    void clock()
    {        
        timer++;
        Invoke("clock", 1f);
        score += timer;        
    }

    public void procesDeath()
    {
        Lifes--;

        if(Lifes >= 0)
        {
            if (PlayerPrefab != null)
            {
                Instantiate(PlayerPrefab, new Vector2(-8.0f, -0f), Quaternion.identity);
            }
        }
        else
        {
            CancelInvoke("clock");
            SceneManager.LoadScene(2);
        }
    }
    
    public void bestScore()
    {
        if(score > BestScore)
        {
            BestScore = score;
        }        
    }

    public void gameStart()
    {
        score = 0000;
        Lifes = 3;
        level = 1;
        Invoke("clock", 1f);
    }

    public void coinSoundPlayer()
    {
        coin.Play();
    }

}
