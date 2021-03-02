using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
