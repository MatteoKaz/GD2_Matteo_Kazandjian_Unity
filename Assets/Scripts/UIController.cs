using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTEXT;
    [SerializeField] private TMP_Text _LifeTEXT;
    [SerializeField] private int Goal = 10;
    public ScoreDataS _ScoreData;
    

    //Fonction actier à chaque activation du MonoBehaviour
    private void OnEnable()
    {
        //Bind entre la fonction update et l'action target collected 
        PlayerCollect.OnTargetCollected += UpdateScore;
        DeathPlayer.DamageTaken += UpdateLife;


    }
    //Fonction appellé lors de la desactivation du monoBehaviour
    private void OnDisable()
    {
        //Unbind
        PlayerCollect.OnTargetCollected -= UpdateScore;
        DeathPlayer.DamageTaken -= UpdateLife;
    }
    private void Start()
    {
        UpdateScore(0);
        UpdateLife(3);
        if (_ScoreData != null)
        {
            _ScoreData.ScoreValue = 0;
        }
    }

    public void UpdateScore(int newScore)
    {
        _scoreTEXT.text = $"Score : {newScore.ToString()} / {Goal.ToString()}";
        if (newScore >= Goal)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void UpdateLife(int newLife)
    {
        _LifeTEXT.text = $"Life : {newLife.ToString()}";
    }
}

