using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Settings()
    {
        panel.GetComponent<Animator>().SetTrigger("Pop");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
