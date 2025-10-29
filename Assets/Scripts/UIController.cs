using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTEXT;

    //Fonction actier à chaque activation du MonoBehaviour
    private void OnEnable()
    {
        //Bind entre la fonction update et l'action target collected 
        PlayerCollect.OnTargetCollected += UpdateScore;
     
    }
    //Fonction appellé lors de la desactivation du monoBehaviour
    private void OnDisable()
    {
        //Unbind
        PlayerCollect.OnTargetCollected -= UpdateScore;
    }
    private void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int newScore)
    {
        _scoreTEXT.text = $"Score : {newScore.ToString()}";
    }
}
