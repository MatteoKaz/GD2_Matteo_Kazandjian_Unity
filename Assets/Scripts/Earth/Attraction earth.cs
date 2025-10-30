using UnityEngine;

public class Attractionearth : MonoBehaviour
{
    public float _HookRadius = 2f;
    

    public Transform attachRoot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {


        Rigidbody _rockRb = other.attachedRigidbody;
        if (_rockRb != null) ;
        {
            float dist = Vector3.Distance(transform.position, other.transform.position);


            //  Attraction douce
            if (dist < _HookRadius )
            {
                Vector3 dir = (attachRoot.position - _rockRb.position).normalized;
                Vector3 force = dir / dist * 25f;
                _rockRb.AddForce(force, ForceMode.Force);
                Debug.Log("J'attire");
            }
        }



    }
}