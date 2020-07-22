using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intem_apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    private AudioSource sound;

    public GameObject Collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        sound = GetComponent<AudioSource>();
        

    }

   
    void OnTriggerEnter2D(Collider2D collider)

    {
        
        if(collider.gameObject.tag == "Player")
        {
            
            sound.Play();
            sr.enabled = false;
            circle.enabled = false;
            Collected.SetActive(true);
            
            GameController.istance.ScoreTotal += Score;
             GameController.istance.UpdateSocoreText();

            Destroy(gameObject, 0.4f); // o "f" na frente do número indica que ele é um valor flutuante //
        }
        
    }

}
