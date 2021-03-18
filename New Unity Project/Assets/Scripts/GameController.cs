using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject modePanel;
    // Start is called before the first frame update
    void Awake()
    {
        modePanel.SetActive(false);
    }

    public void ChangeModePanelVisibility()
    {
        if (!modePanel.activeSelf)
        {
            modePanel.SetActive(true);
        } else if (modePanel.activeSelf)
        {
            modePanel.SetActive(false);
        }
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Onboarding");
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }
}
