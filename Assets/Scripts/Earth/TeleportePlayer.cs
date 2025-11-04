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
    [SerializeField] private GameObject _BlackHolePlayer;
    private GameObject Player;
    private Hook Hookref;

    private void Start()
    {

         Player = GameObject.Find("===Player===");
        Hookref = Player.GetComponent<Hook>();
    }
    private void OnCollisionEnter(Collision other)
    {

        
        {
            FindObjectOfType<Audiomanager>().Play("Teleport");
            if (other.gameObject.GetComponent<PlayerMovement>() != null || other.gameObject.GetComponent<HitCubeLittle>() != null)
            {

                if (Hookref.attachedRocks.Count != 0)
                {
                    foreach (Rigidbody rb in Hookref.attachedRocks)
                    {
                        other.transform.position = _BlackHolePlayer.transform.position;
                        rb.transform.position = _BlackHolePlayer.transform.position;
                    }

                }
                else
                {
                    other.transform.position = _BlackHolePlayer.transform.position;
                }
                    
            }
            else
            {
                other.transform.position = _BlackHole.transform.position;
            }
                
                
          
        }

    }


}

   


    

