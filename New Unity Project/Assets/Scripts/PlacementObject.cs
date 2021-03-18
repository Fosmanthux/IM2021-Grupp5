using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacementObject : MonoBehaviour
{
    [SerializeField]
    public bool IsSelected; 

    public bool Selected
    {
        get
        {
            return this.IsSelected;
        }
        set
        {
            IsSelected = value;
        }
    }

    [SerializeField]
    private TextMeshPro OverlayText;

    [SerializeField]
    private TextMeshPro InfoText;

    [SerializeField]
    private GameObject infoPanel;

    private void Awake()
    {
        OverlayText = GetComponentInChildren<TextMeshPro>();
        if(OverlayText != null)
        {
            OverlayText.gameObject.SetActive(false);
        }
    }

    public void ToggleOverlay() 
    {
        OverlayText.gameObject.SetActive(IsSelected);

        InfoText.gameObject.SetActive(IsSelected);
    }

    public void ToggleInfoPanel()
    {
        infoPanel.SetActive(IsSelected);
    }
}
