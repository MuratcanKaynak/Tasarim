using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sR;
    public float speed = 2f;

    private float waitTime;
    public Transform[] points;
    public float startWaitingTime=3f;
    private int i;
    private Vector2 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitingTime;
        sR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckWaitingTime());
        transform.position = Vector2.MoveTowards(transform.position, points[i].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, points[i].transform.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                if (points[i] != points[points.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitingTime;


            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckWaitingTime()
    {
        currentPos = transform.position;
        yield return new WaitForSecondsRealtime(0.2f);
        
        if (transform.position.x > currentPos.x)
        {
            sR.flipX = true;
            anim.SetBool("Idle", false);
        }
        else if (transform.position.x < currentPos.x)
        {
            sR.flipX = false;
            anim.SetBool("Idle", false);
        }
        if (transform.position.x == currentPos.x)
        {
            anim.SetBool("Idle", true);
        }
    }
    
}
