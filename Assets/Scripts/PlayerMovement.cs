using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Vector3 _movement;
    private Vector3 _grappinDirection;
    [SerializeField]  private float _speed = 5f;
    public Vector3 _pushDirection;
    public Vector3 _grappinHit;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        
    }

    void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        _movement = new Vector3(_horizontalMovement, 0f, _verticalMovement);
        GrappinUpdateDiraction(_movement); //Direction donné à la fonction grappin
        _movement.Normalize();
        _movement *= _speed;
        _movement.y = _rb.linearVelocity.y;
        _pushDirection = _movement;
        if ( _rb != null)
        {
            _rb.linearVelocity = _movement;
        }
        else
        {
            Debug.LogError("No RigidBody Attached !");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            TryThrowGrappin();
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            ThrowGrappin();
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


    private void  TryThrowGrappin()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,
            _grappinDirection,out hit,75f))
        {
            Debug.DrawRay(transform.position, transform.position + _grappinDirection * 100f, Color.red);
            _grappinHit = hit.point + hit.normal * 1.5f;
        }
    }

    private void ThrowGrappin()
    {
        transform.position = _grappinHit;
        _grappinDirection = Vector3.zero;
    }
}
