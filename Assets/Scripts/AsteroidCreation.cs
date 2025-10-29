using System.Globalization;
using UnityEngine;

public class AsteroidCreation : MonoBehaviour
{
    [SerializeField] public int n_numbertoSpawn = 3;
    [SerializeField] public GameObject _AsteroidChild;
    //Fonction actier à chaque activation du MonoBehaviour
    private void OnEnable()
    {
        //Bind entre la fonction update et l'action target collected 
        HitCube.OnAsteroidDestroy += SpawnNewWall;

    }
    //Fonction appellé lors de la desactivation du monoBehaviour
    private void OnDisable()
    {
        //Unbind
        HitCube.OnAsteroidDestroy -= SpawnNewWall;
    }
    private void SpawnNewWall(Vector3 _DeathLocation)
    {
       // while (n_numbertoSpawn=0) 
        
            Instantiate(_AsteroidChild, transform.position, Quaternion.identity);

     
        
    }
}