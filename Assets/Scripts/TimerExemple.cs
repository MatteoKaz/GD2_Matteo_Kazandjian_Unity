using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerExemple : MonoBehaviour
{
    [SerializeField] private int _targetValue = 1;
    [SerializeField] private float _shadowDuration = 3f;
    private float _shadowTimer = 0f;
    private bool _IsInShadows;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void ToggleVisibility(bool newVisibility)
    {
        GetComponent<MeshRenderer>().enabled = newVisibility;
        GetComponent<Collider>().enabled = newVisibility;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerCollect>() != null)
        {
            other.gameObject.GetComponent<PlayerCollect>().UpdateScore(_targetValue);
            //destroy (game object)
            // hide box 
            ToggleVisibility(false);
            StartCoroutine(ShadowTimerControl());
            //Start Timer
        }

    }

    
    //1 : delta time 
   /* private void Update()
    {
        _shadowTimer += Time.deltaTime;
        if (_shadowTimer >= _shadowDuration) ;
        {
            //T1 :ShowTarget
            ToggleVisibility(true);
            //T2 :HideTarget
            _shadowTimer = 0f;
            _IsInShadows = false;
        }

    }*/
    //2 timer by coroutine 
    private IEnumerator ShadowTimerControl ()
        //vous pouvez mettre un delay dans une fonction, 
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(_shadowDuration);
        ToggleVisibility(true);

    }

    
}
