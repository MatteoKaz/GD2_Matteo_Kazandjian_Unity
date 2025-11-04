using System;
using System.Collections;
using System.Globalization;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private float impulseValue = 2;
    private Rigidbody _rbPlayer;
    private Vector3 playerLoc;
    private Rigidbody _rb;
    private float _attractionForce = 2.5f;
    public bool _Close = true;
    private bool TimerAttack = false;
    [SerializeField] public Transform _firepoint;
    [SerializeField] private GameObject _Explosion;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public float _bulletForce = 20f;
    public float _TimeToShoot = 1f;
    private Vector3 _playerVectorForward;
    private int _life = 3;
    private Vector3 _DeathLocation;
    public GameObject _SoundDestroy;
    private Vector3 _RotationSprite = new Vector3(90, 0, 0);
    private Quaternion newQuat = new Quaternion();
    private Vector3 DirectionToPlayer;
    private Vector3 _mouvement;
    private bool Dead = false;
    [SerializeField] PlayerCollect PlayerCollect;

    
    // Start is called once before te first execution of Update after the MonoBehaviour is created
    void Start()
    {
        newQuat.eulerAngles = _RotationSprite;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        playerLoc = _player.transform.position;
        playerLoc = _player.transform.position;

        // if (_Close == false)
        //{
        transform.LookAt(playerLoc);

        if (_Close != true)

        {
            float dist = Vector3.Distance(transform.position, playerLoc);
            Vector3 dir = (playerLoc - _rb.position).normalized;

            Vector3 force = dir * _attractionForce;
            _rb.AddForce(force, ForceMode.Force);

        }
        
             
                 
             
            

        // }DirectionToPlayer = dir;
       //DirectionToPlayer = new Vector3(Random.RandomRange(DirectionToPlayer.x - 0.25f, DirectionToPlayer.x + 0.25f), DirectionToPlayer.y, (Random.RandomRange(DirectionToPlayer.z - 0.25f, DirectionToPlayer.z + 0.25f)));
       // DirectionToPlayer = DirectionToPlayer.normalized;



    }
   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            FindObjectOfType<Audiomanager>().Play("AlienShip");
            _attractionForce = 1f;
            _Close = false;




        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            FindObjectOfType<Audiomanager>().Stop("AlienShip");
            _attractionForce = 2.5f;


        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            if (TimerAttack == false)
            {
                FindObjectOfType<Audiomanager>().Play("PlayerShoot");
                TimerAttack = true;
                GameObject bulletRef = Instantiate(_bullet, _firepoint.position, _firepoint.rotation);
                Rigidbody _rb = bulletRef.GetComponent<Rigidbody>();
                Vector3 dir = (playerLoc - _rb.position).normalized;
               
                _rb.AddForce(-_firepoint.up * _bulletForce, ForceMode.Impulse);
                StartCoroutine(TimeToShootAgain());
            } 
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        _playerVectorForward = GameObject.Find("===Player===").GetComponent<PlayerMovement>()._pushDirection;
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            if (_life > 1)
            {
                _life -= 1;
                if (other.gameObject.GetComponent<PlayerCollect>() != null)
                    PushCube(750);
                Instantiate(_SoundDestroy, _DeathLocation, newQuat);
                Instantiate(_Explosion, transform.position, newQuat);
                FindObjectOfType<Audiomanager>().Play("Impact");
                




            }
            else
            {
                
                _DeathLocation = transform.position;
                //OnAsteroidDestroy?.Invoke(_DeathLocation);
                
                FindObjectOfType<Audiomanager>().Stop("AlienShip");
                Instantiate(_SoundDestroy, _DeathLocation, newQuat);
                Instantiate(_Explosion, transform.position, newQuat);
                
                if (Dead == false)
                {
                    Dead = true;
                    PlayerCollect.UpdateScore(5);
                }
                Destroy(gameObject);
               
                



            }
        }


    }
    private IEnumerator TimeToShootAgain()
    //vous pouvez mettre un delay dans une fonction, 
    {

        yield return new WaitForSeconds(_TimeToShoot);
        TimerAttack = false;
    }
    private void PushCube(float impulse)
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(_playerVectorForward * impulseValue * 10, ForceMode.Impulse);
    }
}

