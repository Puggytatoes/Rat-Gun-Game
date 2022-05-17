using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowTraps : MonoBehaviour
{
    [SerializeField] private float m_PushingForce;  //get float value for deciding pushing up force

    public Rigidbody2D m_Rb;    //make variable for setting rigidbody2D object in Unity

    private void OnTriggerEnter2D(Collider2D collision) //trigger this function when colliding
    {
        if (collision.gameObject.tag == "Player")   //check if colliding object is a Player tagged object
        {
            Vector2 movement = new Vector2(m_Rb.velocity.x, m_PushingForce);    //pushing up by changing the velocity of the rigidbody object
            m_Rb.velocity = movement;
        }
    }
}