using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_plataforma : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;

    private TargetJoint2D target;
    private BoxCollider2D BoxColl;
    
    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        BoxColl = GetComponent<BoxCollider2D>();    
    }
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        Invoke("Falling", time); // "Invoke" faz o papel de chamar o tempo imposto
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        target.enabled = false;
        BoxColl.isTrigger = true;
    }
}
