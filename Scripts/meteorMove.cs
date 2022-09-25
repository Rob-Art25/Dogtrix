using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorMove : MonoBehaviour
{
    [SerializeField] public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 8f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(CompareTag("Enemies"))
            {
                Destroy(gameObject);
            }
            
        }
    }
}
