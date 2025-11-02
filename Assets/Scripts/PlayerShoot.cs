using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    private float _shootRange = 100f;
    private int _damage = 5;
    private float _Cadency = 0.25f;
    private Vector3 _forwardPlayer;
    private Vector3 _Hitloc;
    [SerializeField] private CameraFollow _CamRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

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
         RaycastHit hit;
        if (Physics.Raycast(transform.position,
            _forwardPlayer, out hit, _shootRange)) 
        {
            Debug.DrawRay(transform.position, _forwardPlayer * 150f, Color.green);
            _Hitloc = hit.point + hit.normal* 1.5f;
        }
       }
}
