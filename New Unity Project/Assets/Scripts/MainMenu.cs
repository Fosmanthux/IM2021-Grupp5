using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void start()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quit()
    {
        Debug.Log("Quit!");
        Application.Quit(); 
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options"); 
    }
}
