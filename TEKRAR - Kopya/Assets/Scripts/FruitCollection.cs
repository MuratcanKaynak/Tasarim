using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class FruitCollection : MonoBehaviour
{
    public AudioSource clip;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //FindObjectOfType<LevelManager>().LevelCleared();
            LevelManager.Instance.LevelCleared();
            Destroy(gameObject, 0.4f);
            clip.Play();
            
        }
    }
}
