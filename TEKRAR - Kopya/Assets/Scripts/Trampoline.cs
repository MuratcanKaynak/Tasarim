using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // çalýþmýyor public float jumpForce = 30f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up*5f);
            anim.Play("jumpp");
           
        }
    

    }
}
