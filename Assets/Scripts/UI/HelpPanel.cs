using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    
    private void Start()
    {
        _panel.SetActive(false);   
    }
    
    public void Open()
    {
        _panel.SetActive(true);
    }
    
    public void Close()
    {
        _panel.SetActive(false);
    }
}
