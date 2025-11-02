using UnityEngine;

public class DamageFakePlanet : MonoBehaviour
{
    private int _Damage = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
           


                other.gameObject.GetComponent<DeathPlayer>().UpdateLife(_Damage);
                Debug.Log("kk");
            
        }

    }
}
