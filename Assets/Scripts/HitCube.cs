
using System.Xml.Linq;
using UnityEngine;
using System.Collections;
using System.Globalization;

public class HitCube : MonoBehaviour
{
    private int _life = 3;
    [SerializeField] private int _targetValue = 1;
    private int loup = 2;
    private Rigidbody _rb;
    private float impulseValue = 2;
    private Vector3 _playerVectorForward;
    private Vector3 _DeathLocation;
    private Vector3 spawnPos;
     [SerializeField] private GameObject _Explosion;
    [SerializeField] private GameObject _player;
    [SerializeField] public int n_numbertoSpawn = 3;
    private float _shadowDuration = 0.05f;
    [SerializeField] public GameObject _AsteroidChild;
    [SerializeField] public GameObject _Life;
    private Vector3 _RotationSprite = new Vector3(90, 0, 0);
    private Quaternion newQuat = new Quaternion();
    public GameObject _SoundDestroy;
    public float _Force = 10f;
    private bool _isDestroyed = false;
    private bool Dead = false;

    void Start()
    {
        
        newQuat.eulerAngles = _RotationSprite;
        Vector3 playerPos = GameObject.Find("===Player===").GetComponent<PlayerMovement>().transform.position;
         playerPos = new Vector3(
    playerPos.x + Random.Range(-25f, 25f),
    playerPos.y,
    playerPos.z + Random.Range(-25f, 25f)
         );
        _rb = GetComponent<Rigidbody>();
         spawnPos =  _rb.transform.position;
        float dist = Vector3.Distance(playerPos, spawnPos);
        Vector3 dir = (playerPos - spawnPos).normalized;
        Vector3 force = dir * dist ;
        _rb.AddForce(force * _Force, ForceMode.Force);

    }

    
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
                FindObjectOfType<Audiomanager>().Play("Impact");
                Debug.Log("Touché");
                



            }
            else
            {
                 
                if (Dead == false)
                {
                    Dead = true;
                    _DeathLocation = transform.position;
                    //OnAsteroidDestroy?.Invoke(_DeathLocation);
                    Instantiate(_SoundDestroy, _DeathLocation, newQuat);
                    Instantiate(_Explosion, transform.position, newQuat);
                    SpawnNewWall(_DeathLocation);
                }
                
                
                
                
            }
        }
        
            
    }
    private void SpawnNewWall(Vector3 _DeathLocation)
    {
        
       

            StartCoroutine(ShadowTimerControl());
            n_numbertoSpawn--;

           
        
        
        
    }
    private IEnumerator ShadowTimerControl()
    //vous pouvez mettre un delay dans une fonction, 
    {
        for (int i = 3; i > 0; i--)
        {
            if (n_numbertoSpawn >= 0)
            {
                GameObject _Asteroidmini = Instantiate(_AsteroidChild, transform.position, Quaternion.identity);
                Rigidbody _rb = _Asteroidmini.GetComponent<Rigidbody>();

                var position = new Vector3(Random.Range(-45.0f, 45.0f), transform.position.y, Random.Range(-75.0f, 75.0f));
                _rb.AddForce(position * 0.05f, ForceMode.Impulse);
                n_numbertoSpawn--;
            }
            
            Debug.Log("Spawn");
            
               
 
            yield return new WaitForSeconds(_shadowDuration);
        }
        int _Random = Random.Range(0, 4);

        if (_Random == 0)
        {
            Instantiate(_Life, transform.position, newQuat);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }






    private void PushCube(float impulse)
    {
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(_playerVectorForward * impulseValue,ForceMode.Impulse);
    }
}
