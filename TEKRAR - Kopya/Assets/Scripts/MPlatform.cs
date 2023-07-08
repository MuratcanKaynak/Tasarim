using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPlatform : MonoBehaviour
{
    public Transform[] movingPoints;
    public float speed;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = movingPoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, movingPoints[i].transform.position) < 0.2f)
        {
            i++;
            if(i == movingPoints.Length)
            {
                i = 0;
            }
           
           
        }
        transform.position = Vector2.MoveTowards(transform.position, movingPoints[i].transform.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
