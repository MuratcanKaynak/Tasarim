using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    public GameObject levelTrans;
    public static LevelManager Instance;

    public Text totalFruits;
    public Text remainFruits;




    LevelSelect selection;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        selection=GetComponent<LevelSelect>();
        totalFruits.text = transform.childCount.ToString();
    }
    private void Update()
    {
        remainFruits.text = transform.childCount.ToString();
    }
    public void LevelCleared()
    {
        if (transform.childCount == 1)
        {
            levelTrans.SetActive(true);
            StartCoroutine(Waiting());
            selection.GetLevelIndex();
        }
    }
     
    public IEnumerator Waiting()
    {
        yield return new WaitForSecondsRealtime(1.2f);
        SceneManager.LoadScene("LevelSelection");
    }
}
