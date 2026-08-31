using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true); 
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}