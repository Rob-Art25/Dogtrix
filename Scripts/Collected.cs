using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    [SerializeField] gameManager gm;
    [SerializeField] int LocalScore;
    [SerializeField] Animator anim;

    private void Start()
    {
        gm = FindObjectOfType<gameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.CompareTag("Player"))
        {            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);            
            gm.coinSoundPlayer();
            gm.score += LocalScore;
            Destroy(gameObject, 0.5f);
        }        
    }   
}
