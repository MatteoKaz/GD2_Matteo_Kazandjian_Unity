using UnityEngine;
using System;
using System.Xml.Linq;
using System.Globalization;
using System.Collections;

public class TeleportePlayer : MonoBehaviour
{
    public DeathUI DeathUiRef;
    [SerializeField]  private int _Life = 3;
    public static Action<int> DamageTaken;
   
    private float _TimeShowUi = 0.6f;
    private float _TimeDisable = 0.2f;
    [SerializeField] private CameraFollow _CamRef;
    [SerializeField] private int _MaxLife = 3;
    [SerializeField] private GameObject _BlackHole;
  
    private void OnCollisionEnter(Collision other)
    {

        
        {
            FindObjectOfType<Audiomanager>().Play("Teleport");
            other.transform.position = _BlackHole.transform.position;
                
          
        }

    }


}

   


    

