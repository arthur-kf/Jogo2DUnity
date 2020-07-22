using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chave : MonoBehaviour

{
public GameObject checkpoint;
void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            checkpoint.SetActive(true);

            Destroy(gameObject, 0.1f);
        }
    }   
}