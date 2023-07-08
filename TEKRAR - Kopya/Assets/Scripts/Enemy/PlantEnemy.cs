using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float waitTime;
    public float waitTimeToAttack = 2f;
    private Animator anim;

    public GameObject bulletPref;
    public Transform startPoint;
    void Start()
    {
        anim = GetComponent<Animator>();
        waitTime = waitTimeToAttack;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            waitTime = waitTimeToAttack;
            anim.Play("Attack");
            Invoke("MakeBullet", 0.3f);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
    public void MakeBullet()
    {
        Instantiate(bulletPref, startPoint.position, startPoint.rotation);
    }
}
