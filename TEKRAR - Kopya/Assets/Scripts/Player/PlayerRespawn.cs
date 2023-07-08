using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public GameObject[] H;
    int life;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        life = H.Length;
    }

    // Update is called once per frame
    void CheckLifeHeart()
    {
        if (life < 1)
        {
            anim.SetTrigger("Hit");
            Destroy(H[0].gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (life < 2)
        {
            anim.SetTrigger("Hit");
            Destroy(H[1].gameObject);
        }
        if (life < 3)
        {
            anim.SetTrigger("Hit");
            Destroy(H[2].gameObject);
        }
    }

    public void PlayerDamage()
    {
        //anim.SetTrigger("Hit");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        life--;
        CheckLifeHeart();
    }
}
