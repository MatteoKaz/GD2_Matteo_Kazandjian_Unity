using UnityEngine;
using System;
using System.Xml.Linq;
using System.Globalization;
using System.Collections;

public class DeathPlayer : MonoBehaviour
{
    public DeathUI DeathUiRef;
    [SerializeField]  private int _Life = 3;
    public static Action<int> DamageTaken;
    [SerializeField] private UIController _uiController;
    [SerializeField] private GameObject _Explosion;
    private float _TimeShowUi = 0.6f;
    private float _TimeDisable = 0.2f;
    [SerializeField] private CameraFollow _CamRef;
    [SerializeField] private int _MaxLife = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLife(int value)
    {
        if (_Life !=0)
        {
            _Life -= value;
            Debug.Log("_Life");
            DamageTaken?.Invoke(_Life);
            _Explosion.SetActive(true);
            _CamRef.shakeDuration = 0.5f;
            StartCoroutine(DeactivateExplosion()); ;
        }
        if (_Life <= 0) 
        {
            _CamRef.shakeDuration = 0.8f;
            _Explosion.SetActive(true);
            StartCoroutine(DeathUi());
            
        }


    }

    public void GiveLife(int value)
    {
        if (_Life < _MaxLife)
        {
            _Life += value;
            DamageTaken?.Invoke(_Life);
        }
    }



    private IEnumerator DeactivateExplosion()
    //vous pouvez mettre un delay dans une fonction, 
    {
    yield return new WaitForSeconds(_TimeShowUi);
    DisableSprite();
    }

    private IEnumerator DeathUi()
    //vous pouvez mettre un delay dans une fonction, 
    {
        yield return new WaitForSeconds(_TimeDisable);
        OnDeath();
    }


    void OnDeath()
    {
        DeathUiRef.ShowUIDeath();
    }

    void DisableSprite()
    {
        _Explosion.SetActive(false);
    }
}
