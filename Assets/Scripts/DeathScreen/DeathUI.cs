using UnityEngine;
using System.Collections;

public class DeathUI : MonoBehaviour
{
    private Canvas CanvasObject;
    [SerializeField] Canvas CanvasChild;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CanvasObject = GetComponent<Canvas>();
        
    }

    public void ShowUIDeath()
    {
        CanvasObject.enabled = true;
        if (CanvasChild != null)
        {

            CanvasChild.enabled = true;
        }

    }
}
    
    



