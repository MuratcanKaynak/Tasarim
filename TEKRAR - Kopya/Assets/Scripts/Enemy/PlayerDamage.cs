using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D coll;
    private Animator anim;

    private SpriteRenderer sR;
    public GameObject deathEffect;
    public int life = 2;
    public float jumpForce = 2f;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            GiveDamage();
            EnemyDead();
        }
    }
    public void GiveDamage()
    {
        life--;
        anim.Play("Hit");

    }
    public void EnemyDead()
    {
        if (life <= 0)
        {
            
            //efekt yapmak için sR.enabled = false;
            Destroy(gameObject, 0.1f);
        }
    }
}
