using UnityEngine;
using System.Collections;
using System.Globalization;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] public GameObject _AsteroidExplosion;
    private Vector3 _RotationSprite = new Vector3(90, 0, 0);
    private Quaternion newQuat = new Quaternion();
    private float _TimeToDie= 3f;

    void Start()
    {
        newQuat.eulerAngles = _RotationSprite;
        StartCoroutine(TimeBeforeDestruction());
    }
    void OnCollisionEnter(Collision collision)
    {
        Instantiate(_AsteroidExplosion, transform.position, newQuat);
        Destroy(gameObject);
        if (collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            collision.gameObject.GetComponent<DeathPlayer>().UpdateLife(1);
        }
    }

    private IEnumerator TimeBeforeDestruction()
    //vous pouvez mettre un delay dans une fonction, 
    {

        yield return new WaitForSeconds(_TimeToDie);
        Destroy(gameObject);
    }

}
