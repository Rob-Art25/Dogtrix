using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundScrolling : MonoBehaviour
{

    [SerializeField] [Range (0,5)] public float baseSpeed;
    [SerializeField] BackgroundLayer[] layers;
 
    // Update is called once per frame
    void Update()
    {
        foreach(BackgroundLayer layer in layers)
        {
            float deltaX = layer.scrollingSpeed * baseSpeed * Time.deltaTime;
            float newPsitionX = layer.transform.position.x - deltaX;
            if (newPsitionX < layer.boundary)
                newPsitionX += layer.distance;
            layer.transform.position = new Vector2(newPsitionX, layer.transform.position.y);
        }
    }


    [Serializable]
    private class BackgroundLayer
    {
        public Transform transform;
        public float scrollingSpeed, boundary, distance;
    }
}
