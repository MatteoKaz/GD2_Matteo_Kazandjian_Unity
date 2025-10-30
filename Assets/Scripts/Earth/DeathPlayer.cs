using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    public PlayerMovement _Playermovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_Playermovement != null)
        {

        }
    }
}
