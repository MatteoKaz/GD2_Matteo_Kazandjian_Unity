using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 customRot;
    private Vector3 camPos;
    [SerializeField] private GameObject _player;

    void Start()
    {
        customRot = new(90f, 0f, 0f);



    }
    // Update is called once per frame
    void Update()
    {
       camPos = _player.transform.position; 
        transform.position = new Vector3 ( camPos.x, 20f, camPos.z);
        transform.rotation = Quaternion.Euler ( customRot);
        


    }
}
