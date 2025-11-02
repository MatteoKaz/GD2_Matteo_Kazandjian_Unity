using UnityEngine;
using System.Collections.Generic;

public class DestroyAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject _Explosion;
    private Vector3 _RotationSprite = new Vector3(90, 0, 0);
    private Quaternion newQuat = new Quaternion();
    public GameObject _SoundDestroy;

    void Start()
    {

        newQuat.eulerAngles = _RotationSprite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Astroid"))
        {
            GameObject Asteroid = other.GetComponent<Rigidbody>().gameObject;
            
            Instantiate(_Explosion, other.transform.position, newQuat);
            Instantiate(_SoundDestroy, transform.position, transform.rotation);
            Destroy(Asteroid);
        }

    }


    
}



