using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBirdAI : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private SpriteRenderer sR;
    public float speed = 2f;

    private float birdWaitTime;
    public Transform[] points;
    public float startWaitingTime = 3f;
    private int i;
    private Vector2 currentPos;
    void Start()
    {
        birdWaitTime = startWaitingTime;
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
            if (birdWaitTime <= 0)
            {
                if (points[i] != points[points.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                birdWaitTime = startWaitingTime;


            }
            else
            {
                birdWaitTime -= Time.deltaTime;
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
            
        }
        else if (transform.position.x < currentPos.x)
        {
            sR.flipX = false;
            
        }
        
    }
}
