using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    //determines how fast the player returns to rests
    float brakingSpeed = 1.1f;

    //bounds for where player can move (most likely camera)
    private float xMin, xMax;
    private float yMin, yMax;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var spriteSize = GetComponent<SpriteRenderer>().bounds.size.x * .5f;

        var cam = Camera.main;// Camera component to get their size, if this change in runtime make sure to update values
        var camHeight = cam.orthographicSize;
        var camWidth = cam.orthographicSize * cam.aspect;

        yMin = -camHeight + spriteSize; // lower bound
        yMax = camHeight - spriteSize; // upper bound
        
        xMin = -camWidth + spriteSize; // left bound
        xMax = camWidth - spriteSize; // right bound 
    }

    void FixedUpdate()
    {
       // float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var xValidPosition = Mathf.Clamp(transform.position.x, xMin, xMax);
        var yValidPosition = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(transform.position.x, yValidPosition, 0f);

        //if at the edge of the screen and trying to move further, halt velocity
        if((transform.position.y == yMin || transform.position.y == yMax) && rb.linearVelocity != Vector2.zero){
            rb.linearVelocity = Vector2.zero;
        }
        //if no button presssed, stop player's movement
        else if(vertical == 0f){
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
