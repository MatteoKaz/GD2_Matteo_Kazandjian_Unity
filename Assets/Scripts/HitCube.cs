using System;
using System.Xml.Linq;
using UnityEngine;

public class HitCube : MonoBehaviour
{
    private int _life = 3;
    [SerializeField] private int _targetValue = 1;
    private int loup = 2;
    private Rigidbody _rb;
    private float impulseValue = 2;
    private Vector3 _playerVectorForward;
    private Vector3 _DeathLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Action<Vector3> OnAsteroidDestroy;


    private void OnCollisionEnter(Collision other)
    {
        _playerVectorForward = GameObject.Find("===Player===").GetComponent<PlayerMovement>()._pushDirection;
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            if (_life > 1) 
            { 
                _life -= 1;
                if(other.gameObject.GetComponent<PlayerCollect>() != null)
                PushCube(150);
                Debug.Log("Touché");



            }
            else
            {
                _DeathLocation = transform.position;
                OnAsteroidDestroy?.Invoke(_DeathLocation);
                Destroy(gameObject);
                if (other.gameObject.GetComponent<PlayerCollect>() != null)
                    other.gameObject.GetComponent<PlayerCollect>().UpdateScore(_targetValue);
            }
        }
    }

    private void PushCube(float impulse)
    {
            _rb =GetComponent<Rigidbody>();
            _rb.AddForce(_playerVectorForward * impulseValue,ForceMode.Impulse);
    }
}
