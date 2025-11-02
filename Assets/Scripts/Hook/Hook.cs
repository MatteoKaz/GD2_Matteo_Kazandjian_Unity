using UnityEngine;
using System.Collections.Generic;
public class Hook : MonoBehaviour
{

    private float _HookCapacity = 3f;
    public float _HookRadius = 12f;
    public float _attachDistance = 5f;
    public Transform attachRoot;
    public Rigidbody _rb;
    private List <Rigidbody> attachedRocks = new List<Rigidbody>();
    [SerializeField] public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.F))
        {
            if (attachedRocks.Count != 0)
            {
                Rigidbody last = attachedRocks[attachedRocks.Count - 1];
                attachedRocks.RemoveAt(attachedRocks.Count - 1);
                last.mass = 2.5f;
                last.linearDamping = 0.8f;
                last.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY; ;
                Destroy(last.GetComponent<Joint>());
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        {
            if (other.CompareTag("AsteroidHook"))
            {

                if (attachedRocks.Count <= _HookCapacity) ;
                {
                    Rigidbody _rockRb = other.attachedRigidbody;
                    if (_rockRb != null) ;
                    {
                        float dist = Vector3.Distance(attachRoot.transform.position, other.transform.position);


                        //  Attraction douce
                        if (dist < _HookRadius && !attachedRocks.Contains(_rockRb) && other.CompareTag("AsteroidHook") && (Input.GetKey(KeyCode.E)) )
                        {
                            Vector3 dir = (attachRoot.position - _rockRb.position).normalized;
                            float force = Mathf.Lerp(20f, 0f, 1f - dist / _HookRadius);
                            _rockRb.AddForce(dir * force*15 , ForceMode.Acceleration);
                            Debug.Log("J'attire");
                        }
                        
                          //Attache si assez proche
                        if (dist <= _attachDistance)
                        {

                          AttachRock(_rockRb);
                        }
                    }
                }
            }
        }
    }
   
    void AttachRock(Rigidbody _rock)
    {
        if (attachedRocks.Count <= _HookCapacity)
        {



            if (!attachedRocks.Contains(_rock) && (Input.GetKey(KeyCode.E)))
            {



                var joint = _rock.gameObject.AddComponent<FixedJoint>();
                Debug.Log("J'attache");
                if (attachedRocks.Count > 0)
                {
                    joint.connectedBody = attachedRocks[attachedRocks.Count - 1];
                    joint.breakForce = 125f;

                    _rock.isKinematic = false;
                    _rock.useGravity = false;
                    _rock.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                    _rock.mass = 0.05f;
                    _rock.linearDamping = 0.1f;
                    _rock.angularDamping = 0.2f;


                    _rock.constraints = RigidbodyConstraints.None;
                    _rock.constraints = RigidbodyConstraints.FreezePositionY;
                    joint.breakForce = 350f;
                    joint.breakTorque = 350f;
                    attachedRocks.Add(_rock);
                }
                else
                {
                    joint.connectedBody = _rb;

                    joint.breakForce = 125f;

                    _rock.isKinematic = false;
                    _rock.useGravity = false;
                    _rock.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                    _rock.mass = 0.01f;
                    _rock.linearDamping = 0.5f;
                    _rock.angularDamping = 0.1f;


                    _rock.constraints = RigidbodyConstraints.None;
                    _rock.constraints = RigidbodyConstraints.FreezePositionY;
                    joint.breakForce = 350f;
                    joint.breakTorque = 350f;
                    attachedRocks.Add(_rock);
                }
            }
        }
        
    }
       
    
   

}
