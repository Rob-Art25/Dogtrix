using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temBubblesGenerator : MonoBehaviour
{

    [SerializeField]
    GameObject[] bubbleItem;
    [SerializeField]
    Transform AsteroidBox;


    public float timeSpawn, repeatSpawnRate;    
    
    [SerializeField]
    Transform yRangeDown;
    [SerializeField]
    Transform yRangeUp;

    void Start()
    {
        InvokeRepeating("generateBubble", timeSpawn, repeatSpawnRate);
        InvokeRepeating("dynamicDificult", 3, 120f);
    }


    public void generateBubble()
    {
        Vector2 spawnPosition = new Vector2(0, 0);

        spawnPosition = new Vector2(transform.position.x, Random.Range(yRangeDown.position.y, yRangeUp.position.y));
        GameObject bubble = Instantiate(bubbleItem[Random.Range(0, bubbleItem.Length)], spawnPosition, gameObject.transform.rotation);

        bubble.transform.SetParent(AsteroidBox);        
    }

    public void dynamicDificult()
    {
        if (repeatSpawnRate > 0.25)
        {
            repeatSpawnRate -= 0.25f;            
        }            
        else if (repeatSpawnRate == 0.25f)
        {            
            FindObjectOfType<backGroundScrolling>().baseSpeed++;            
        }            
        else if (repeatSpawnRate == 0.025f)
        {            
            FindObjectOfType<backGroundScrolling>().baseSpeed++;            
        }

    }

}
