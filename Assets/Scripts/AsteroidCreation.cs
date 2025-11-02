using System.Globalization;
using UnityEngine;
using System.Collections;

public class AsteroidCreation : MonoBehaviour
{
    [SerializeField] public int n_numbertoSpawn = 3;
    [SerializeField] public GameObject _AsteroidChild;
    private float _shadowDuration = 0.2f;

    //Fonction actier à chaque activation du MonoBehaviour
    //private void OnEnable()
    //{
        //Bind entre la fonction update et l'action target collected 
       // HitCube.OnAsteroidDestroy += SpawnNewWall;

    //}
    //Fonction appellé lors de la desactivation du monoBehaviour
    //private void OnDisable()
   //{
        //Unbind
        //HitCube.OnAsteroidDestroy -= SpawnNewWall;
    //}
    //private void SpawnNewWall(Vector3 _DeathLocation)
    //{
//for (int i = 3; i > 0; i--)
       // {

            //StartCoroutine(ShadowTimerControl());
    ///   // }
   // }
    ///private IEnumerator ShadowTimerControl()
    //vous pouvez mettre un delay dans une fonction, 
    //{
        
      //  Instantiate(_AsteroidChild, transform.position, Quaternion.identity);
      //  Rigidbody _rb = _AsteroidChild.GetComponent<Rigidbody>();
        
      //  var position = new Vector3(Random.Range(-45.0f, 45.0f), transform.position.y, Random.Range(-45.0f, 45.0f));
      //  _rb.AddForce(position * 85, ForceMode.Impulse);
        
       // yield return new WaitForSeconds(_shadowDuration);
   // }
}
