using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
public class SpawnerAsteroid : MonoBehaviour
{
    [SerializeField] public GameObject _Asteroid;
    private float SpawnerTime = 7.5f;
    private Vector3 _RotationSprite = new Vector3(90, 0, 0);
    private Quaternion newQuat = new Quaternion();
    private int _currentSpawnCount = 0;
    [SerializeField] private int SpawnCountMax = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnerAsteroidTimer());
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator SpawnerAsteroidTimer()
    //vous pouvez mettre un delay dans une fonction, 
    {

        yield return new WaitForSeconds(SpawnerTime);
        Instantiate(_Asteroid, transform.position, newQuat);
       
        RelaunchSpawn();

       
      }

    private void RelaunchSpawn()
    {
        if (_currentSpawnCount <= SpawnCountMax)
        {
            StartCoroutine(SpawnerAsteroidTimer());
            _currentSpawnCount ++;
            Debug.Log("Spawn 1" + 1);
        }
    }
}


