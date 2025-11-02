using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _Damage = 1 ;
    private bool _HasDamage = false ;
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
       
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if (_HasDamage==false)
            {

                _HasDamage = true;
                other.gameObject.GetComponent<DeathPlayer>().UpdateLife(_Damage);
                
            }
        }

    }
    private void OnCollisionExit(Collision other)
    {
        _HasDamage = false;
    }
}
