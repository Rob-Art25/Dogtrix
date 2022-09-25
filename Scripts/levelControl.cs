using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelControl : MonoBehaviour
{

    private int timer;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        Invoke("clock", 1f);
        Debug.Log("Nivel : 1");
        FindObjectOfType<gameManager>().level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 30f && timer < 120f)
        {
            
            if (gameObject.transform.GetChild(1).gameObject.activeSelf == false)
            {
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                Debug.Log("Nivel : 2");
                FindObjectOfType<gameManager>().level = 2;
            }
                
        }
        else if(timer >= 120f && timer < 240f)
        {
            
            if (gameObject.transform.GetChild(2).gameObject.activeSelf == false)
            {
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                Debug.Log("Nivel : 3");
                FindObjectOfType<gameManager>().level = 3;
            }
                
        }
    }

    void clock()
    {
        timer++;
        Invoke("clock", 1f);        
    }

}
