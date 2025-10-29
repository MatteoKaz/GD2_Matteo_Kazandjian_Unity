using System;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    [SerializeField] private ScoreDataS _scoreData;
    [SerializeField] private UIController _uiController;

    public static Action<int> OnTargetCollected;

    public void UpdateScore(int value)
    {
        _scoreData.ScoreValue = Mathf.Clamp(_scoreData.ScoreValue + value, min:0, max: _scoreData.ScoreValue+ value);
        OnTargetCollected?.Invoke(_scoreData.ScoreValue); 
        Debug.Log(_scoreData.ScoreValue);
    }
}