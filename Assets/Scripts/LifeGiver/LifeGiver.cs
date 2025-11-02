using UnityEngine;

public class LifeGiver : MonoBehaviour
{
    private int _LifeAmount = 1;
    private bool _HasDamage = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if (_HasDamage == false)
            {

                _HasDamage = true;
                FindObjectOfType<Audiomanager>().Play("Heal"); 
                other.gameObject.GetComponent<DeathPlayer>().GiveLife(_LifeAmount);
                Destroy(gameObject);
            }
        }

    }
  
}


