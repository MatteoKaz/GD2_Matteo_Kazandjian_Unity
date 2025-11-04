using Unity.VisualScripting;
using UnityEngine;

public class CheckPos : MonoBehaviour
{
    [SerializeField] private GameObject IA;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            IA.GetComponent<EnemyAI>()._Close = false;
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            IA.GetComponent<EnemyAI>()._Close = true;
            
        }
            
    }

}
