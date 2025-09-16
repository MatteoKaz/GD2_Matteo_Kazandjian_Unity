using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDataS _scoreData;


    public void UpdateScore(int value)
    {
        _scoreData.ScoreValue = Mathf.Clamp(_scoreData.ScoreValue + value, min:0, max: _scoreData.ScoreValue+ value);
        Debug.Log(_scoreData.ScoreValue);
    }
}