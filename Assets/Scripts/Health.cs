using RDCT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int health;
    public int MHP;

    PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        health = MHP;
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        health --;
        if(health == 0)
        {
            Debug.Log("MATI");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

        }
    }
}
