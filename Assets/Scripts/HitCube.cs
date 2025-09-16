using UnityEngine;

public class HitCube : MonoBehaviour
{
    private int _life = 3;
    [SerializeField] private int _targetValue = 1;
    private int loup = 2;
    private Rigidbody _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            if (_life > 1) 
            { 
                _life -= 1;
                
              
            }
            else
            {
                Destroy(gameObject);
                other.gameObject.GetComponent<PlayerCollect>().UpdateScore(_targetValue);
            }
        }
    }

   
}
