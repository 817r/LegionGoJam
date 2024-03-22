using JetBrains.Annotations;
using RDCT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrys : MonoBehaviour
{
    PlayerController controller;



    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
       
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            
        }
    }
}
