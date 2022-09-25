using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed;
    public Animator anim;
    public AudioSource dieClip;
    public gameManager gm;
    public FixedJoystick joystick;

    private void Start()
    {
        gm = FindObjectOfType<gameManager>();
    }

    void FixedUpdate()
    {
        move();
    }

    // Movimiento Player
    private void move()
    {
        if (joystick != null)
        {

            // Movimiento Horizontal
           if (joystick.Horizontal != 0)
            {                
                float newPosXjoystick = Mathf.Clamp(transform.position.x + ((joystick.Horizontal * moveSpeed) * Time.deltaTime),-8,8);                
                transform.position = new Vector2(newPosXjoystick, transform.position.y);
                anim.SetBool("Walk", true);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y);
                anim.SetBool("Walk", false);
            }

            if (joystick.Vertical != 0)
            {
                float newPosYjoystick = Mathf.Clamp(transform.position.y + ((joystick.Vertical * moveSpeed) * Time.deltaTime), -4, 4);
                transform.position = new Vector2(transform.position.x, newPosYjoystick);
                anim.SetBool("Walk", true);
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y);
                anim.SetBool("Walk", false);
            }
        }
        else
        {
            joystick = FindObjectOfType<FixedJoystick>();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            anim.SetBool("Die", true);
            dieClip.Play();
            gm.procesDeath();
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            anim.SetBool("Die", true);
            dieClip.Play();
            gm.procesDeath();
            Destroy(gameObject, 0.5f);
        }
    }
}
