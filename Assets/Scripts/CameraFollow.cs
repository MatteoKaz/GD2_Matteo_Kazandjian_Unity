using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 customRot;
    private Vector3 camPos;
    [SerializeField] private GameObject _player;
    [SerializeField] private float moveSpeed = 10f;
    private Vector3 _offset = new Vector3(0f, 0f, 9f);
    public Vector3 velocity;
    private float smoothtime = 0.1f;
    void Start()
    {
        customRot = new(90f, 0f, 0f);



    }
    // Update is called once per frame
    void Update()
    {
       camPos = _player.transform.position;
        //transform.position = new Vector3 ( camPos.x, 20f, camPos.z) + _offset;
       Vector3 targetPosition = new Vector3(camPos.x, 20f, camPos.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothtime);
        transform.rotation = Quaternion.Euler ( customRot);
        


    }
}
