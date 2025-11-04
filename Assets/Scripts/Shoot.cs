using UnityEngine;

public class Shoot : MonoBehaviour
{

    private float _shootRange = 100f;
    private int _damage = 5;
    private float _Cadency = 0.25f;
    private Vector3 _forwardPlayer;
    private Vector3 _Hitloc;
    [SerializeField] public Transform _firepoint;
    [SerializeField] public GameObject _bullet;
    [SerializeField] public float _bulletForce = 20f;
    [SerializeField] private CameraFollow _CamRef;
    // Update is called once per frame
    void Update()
    {
        _forwardPlayer = transform.forward;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
       
        
    }

    private void Shooting()
    {
        FindObjectOfType<Audiomanager>().Play("PlayerShoot");
        GameObject bulletRef = Instantiate(_bullet, _firepoint.position, _firepoint.rotation);
        Rigidbody _rb = bulletRef.GetComponent<Rigidbody>();
        _rb.AddForce(-_firepoint.up * _bulletForce, ForceMode.Impulse);
        _CamRef.shakeDuration = 0.025f;
    }
}
