using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    //determines how fast the player returns to rests
    private float brakingSpeed = 1.1f;

    //bounds for where player can move (most likely camera)
    private float xMin, xMax;
    private float yMin, yMax;

    private ZoneTracker zoneTracker;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var spriteSize = GetComponent<BoxCollider2D>().size.x * .5f;
        //GetComponent<SpriteRenderer>().bounds.size.x * .5f;

        var cam = Camera.main;// Camera component to get their size, if this change in runtime make sure to update values
        var camHeight = (transform.position.z - cam.transform.position.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        var camWidtht = camHeight * cam.aspect;
        
        //var camHeight = cam.orthographicSize;
        //var camWidtht = cam.orthographicSize * cam.aspect;

        yMin = -camHeight + spriteSize - GetComponent<BoxCollider2D>().offset.y * .5f; // lower bound
        yMax = camHeight - spriteSize - GetComponent<BoxCollider2D>().offset.y * .5f; // upper bound
        
        xMin = -camWidtht + spriteSize; // left bound
        xMax = camWidtht - spriteSize; // right bound 


        zoneTracker = FindFirstObjectByType<ZoneTracker>();
    }

    void FixedUpdate()
    {
        if (PauseMenu.paused) return;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //lock player to camera's bounds
        var xValidPosition = Mathf.Clamp(transform.position.x, xMin, xMax);
        var yValidPosition = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(transform.position.x, yValidPosition, 0f);

        //if at the edge of the screen and trying to move further, halt velocity
        if((transform.position.y == yMin || transform.position.y == yMax) && rb.linearVelocity != Vector2.zero){
            rb.linearVelocity = Vector2.zero;
        }
        //if no button presssed, slow player's movement
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
        
        speedChange(horizontal);

        //if pushed to the left of the screen, die
        if(transform.position.x == xMin){
            die();
        }
    }

    void speedChange(float horizontal){
        if(zoneTracker != null){
            if (horizontal < 0f){
                zoneTracker.modSpeed('S');
            }
            else if(horizontal > 0f){
                zoneTracker.modSpeed('F');
            }
            else{
                zoneTracker.modSpeed('N');
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        die();
    }

    public void die(){
        Time.timeScale = 0;

        ReloadScene();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(ZoneTracker.main.currentScene);
        Time.timeScale = 1;
    }
}
