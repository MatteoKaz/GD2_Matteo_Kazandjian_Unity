using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] public GameObject _wallPrefab;
    [SerializeField] public Transform[] _spawnPoints;
    private int _spawnPointIndex = 0;
    //Fonction actier à chaque activation du MonoBehaviour
    private void OnEnable()
    {
        //Bind entre la fonction update et l'action target collected 
        //PlayerCollect.OnTargetCollected += SpawnNewWall;

    }
    //Fonction appellé lors de la desactivation du monoBehaviour
    private void OnDisable()
    {
        //Unbind
        //PlayerCollect.OnTargetCollected -= SpawnNewWall;
    }
    private void SpawnNewWall(int score)
    {
        if (_spawnPointIndex >= _spawnPoints.Length)
        {
            return;
        }
        Instantiate(_wallPrefab, _spawnPoints[_spawnPointIndex].position, _spawnPoints[_spawnPointIndex].rotation);
        _spawnPointIndex++;
        
    }
}