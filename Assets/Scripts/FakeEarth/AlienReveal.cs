using UnityEngine;

public class AlienReveal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _EarthRenderer;
    [SerializeField] private SpriteRenderer _Lumiere;
    [SerializeField] private Canvas _FakeScore;
    private Rigidbody _rb;
    private Vector3 spawnPos;
    private bool _Enter = false;
    private Vector3 _initialPose;
    [SerializeField] private float _Force = 8;


    void FixedUpdate()
    {
        if (_Enter== true)
        {
            Vector3 playerPos = GameObject.Find("===Player===").GetComponent<PlayerMovement>().transform.position;
            _rb = GetComponent<Rigidbody>();
            spawnPos = _rb.transform.position;
            float dist = Vector3.Distance(playerPos, spawnPos);
            Vector3 dir = (playerPos - spawnPos).normalized;
            Vector3 force = dir / dist * 650f;
            _rb.AddForce(force * _Force, ForceMode.Force);
        }
     
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<Audiomanager>().Play("AlienPlanet");
            _initialPose = transform.position;
         _FakeScore.enabled = false;
        _EarthRenderer.enabled = false;
        _Lumiere.enabled = false;
        Vector3 playerPos = GameObject.Find("===Player===").GetComponent<PlayerMovement>().transform.position;
        _rb = GetComponent<Rigidbody>();
        spawnPos = _rb.transform.position;
        float dist = Vector3.Distance(playerPos, spawnPos);
        Vector3 dir = (playerPos - spawnPos).normalized;
        Vector3 force = dir / dist * 650f;
        _rb.AddForce(force * 250, ForceMode.Force);
            _Enter = true;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _FakeScore.enabled = true;
            _EarthRenderer.enabled = true;
            _Lumiere.enabled = true;
            _Enter = false;
            _rb = GetComponent<Rigidbody>();
            spawnPos = _rb.transform.position;
            float dist = Vector3.Distance(_initialPose, spawnPos);
            Vector3 dir = (_initialPose - spawnPos).normalized;
            Vector3 force = dir / dist * 650f;
            _rb.AddForce(force * _Force, ForceMode.Force);

            // transform.position = _initialPose;
        }
            
    }
}