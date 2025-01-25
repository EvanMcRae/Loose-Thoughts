using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    //determines how fast the player returns to rests
    float brakingSpeed = 1.1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
       // float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //if no button presssed, stop player's movement
        if(vertical == 0f){
            rb.linearVelocity /= brakingSpeed;
        }
        //if trying to move in opposite direction of movement, add extra force to desired direction
        else if(vertical > 0f && rb.linearVelocity.y < 0f || vertical < 0f && rb.linearVelocity.y > 0f){
            rb.AddForceY(vertical * speed * 2);
        }
        else
        {
            rb.AddForceY(vertical * speed);
        }
        
    }
}
