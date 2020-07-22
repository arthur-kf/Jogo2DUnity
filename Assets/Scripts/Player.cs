using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anime;
    
    public float Speed; 
    public float JumpForce;

    public bool isJumping;
    public bool dobleJump;

    bool isBlowing;

    // Start is called before the first frame update    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move() 
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f , 0f);
        //move personagem em uma posição nao usa fisica//
        //transform.position += movement * Time.deltaTime * Speed;
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
        
        if(movement > 0f) // virar direira
        {
            anime.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f); // esse codigo permite rotacionar o objeto //
        }
        if(movement < 0f) // virar esquerda
        {
            anime.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(movement == 0f)// parado
        {
            anime.SetBool("walk", false);
        }

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isBlowing)
        {
            if (!isJumping)// ! = trasnforma o valor em falso //
            {
                rig.AddForce(new Vector3(0f, JumpForce),ForceMode2D.Impulse);
                dobleJump = true;
                anime.SetBool("jump", true);
            }
            else
            {
                if (dobleJump)
                {
                    rig.AddForce(new Vector3(0f, JumpForce),ForceMode2D.Impulse);
                    dobleJump = false;
                }    
            }
            
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            anime.SetBool("jump", false);
        }
        if(collision.gameObject.tag == "Spikes")
        {
            GameController.istance.ShowGameOver();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "cerra")
        {
            GameController.istance.ShowGameOver();
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;    
        }
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
           isBlowing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 11)
        {
            isBlowing = false;
        }
    }
}
