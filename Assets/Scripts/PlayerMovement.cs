using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private float _ForwardMovement;
    private Vector3 _movement;
    private Vector3 _grappinDirection;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _Rotspeed = 100f;
    public Vector3 _pushDirection;
    public Vector3 _grappinHit;
    private Vector3 _rotator;
    [SerializeField] private float _maxSpeed = 15f;
    private Vector3 _CurrentSpeed;
    private float _brakeFactor = 0.1f;
    private Vector3 m_EulerAngleVelocity = new Vector3(0,65, 0);
    [SerializeField] private Animator Reactor;
    private bool ReactorSound = false;
    public float decreaseFactor = 1.0f;
    public float soundRocketDuration = 1;
    [SerializeField] private GameObject _Cam;
    private Camera _CamRef;
    static float t = 0.0f;
    private bool _ChangeFov = false;
    private bool _ResetFov = false;
    private float _TargetFov;
    private float _CurrentFov = 60f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _CamRef = _Cam.GetComponent<Camera>();
        t += 0.2f * Time.deltaTime;
        
        

      
        

    }

    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        
        _ForwardMovement = Mathf.Clamp(_verticalMovement, -0.45f, 1f);
        GrappinUpdateDiraction(_movement); 
        _pushDirection = _CurrentSpeed * 1.5f;
        
        _CurrentSpeed = (transform.forward * _ForwardMovement * _speed);
        

        if (Input.GetKey(KeyCode.Space))
            _rb.AddForce(-_rb.linearVelocity *4 * _brakeFactor, ForceMode.Force);

        if (_ChangeFov == true)
        {
            _CamRef.fieldOfView = Mathf.Lerp(_CamRef.fieldOfView, _TargetFov, Time.deltaTime * 4);
        }
        if (_ResetFov == true)
       
        {
            _CamRef.fieldOfView = Mathf.Lerp(_CamRef.fieldOfView, _CurrentFov, Time.deltaTime * 4);
            Debug.Log("Rapeticie");
        }

    }

    void FixedUpdate()
    {
        Reactor.SetFloat("Speed", _verticalMovement) ;
        Quaternion _Rotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        Quaternion _RotationRight = Quaternion.Euler(-m_EulerAngleVelocity * Time.fixedDeltaTime);
        if (_verticalMovement > 0.25f)
        {
            if (ReactorSound == false)
            {

                ReactorSound = true;
                FindObjectOfType<Audiomanager>().Play("Rocket");
                soundRocketDuration = 1;
            }
            else
            {
                soundRocketDuration -= Time.deltaTime * decreaseFactor;
                if (soundRocketDuration < 0)
                {
                    ReactorSound = false;
                }
            }
        }
        else
        {
            FindObjectOfType<Audiomanager>().Stop("Rocket");
            soundRocketDuration = 0;
        }
            if (_rb != null )
        {
            _rb.AddForce(_CurrentSpeed, ForceMode.Force);

        }
        else
        {
            Debug.LogError("No RigidBody Attached !");
        }
        //if (Input.GetKeyDown(KeyCode.G))
        //{
           // TryThrowGrappin();
        //}
       //// if (Input.GetKeyUp(KeyCode.G))
        //{
       //     ThrowGrappin();
       // }
        

        if (Input.GetKey(KeyCode.A))
        {
            _rb.MoveRotation(_rb.rotation * _RotationRight);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rb.MoveRotation(_rb.rotation * _Rotation);
        }
            
        
        float _CurrentVel = _rb.linearVelocity.magnitude;
        if (_CurrentVel > _maxSpeed)
        {
            _rb.linearVelocity = _rb.linearVelocity.normalized * _maxSpeed;
        }

        if (_CurrentVel < 5)
        {
            
            _ChangeFov = false;
            _ResetFov = true;
            _speed = 10f;
            _maxSpeed = 15f;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
           
        }

    }


    private void GrappinUpdateDiraction(Vector3 direction)
    {
        direction.Normalize();
        if(direction.sqrMagnitude > 0.1 )
        {
            _grappinDirection = direction;
        }
    }

    
    //private void  TryThrowGrappin()
   // {
       // RaycastHit hit;
      //  if (Physics.Raycast(transform.position,
          //  _grappinDirection,out hit,75f))
      //  {
         //   Debug.DrawRay(transform.position, transform.position + _grappinDirection * 100f, Color.red);
          //  _grappinHit = hit.point + hit.normal * 1.5f;
      //  }
   // }

   // private void ThrowGrappin()
   // {
     //   transform.position = _grappinHit;
     //   _grappinDirection = Vector3.zero;
   // }

    public void Accelarate()
    {
        _TargetFov = Mathf.Min(_CamRef.fieldOfView + 5f,85) ;
        
        _ResetFov = false ;
        _ChangeFov = true;
        _speed = Mathf.Clamp(_speed +3, 0, 30);
        _maxSpeed *=  +3;
        _maxSpeed =Mathf.Clamp(_maxSpeed, 0, 50);
    }

    public void DecreaseRotation()
    {
        _Rotspeed -= 10;


    }

    public void IncreaseRotation()
    {
        _Rotspeed += 10;
    }
}
