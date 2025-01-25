using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyThatMisses : Obstacle
{
    private Rigidbody2D rb;

    private bool playerIsInRange = false;
    public CircleCollider2D cc;

    public Transform player;
    bool dead = false;

    private Vector3 target;

    float x = 0;

    public bool isRoaming = true;

    private int targetIndex;
    public float startWaitTime;
    private float waitTime;
    public GameObject objectThatHasMovePositions;
    public bool roamsRandomly = false;
    // Start is called before the first frame update
    new void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        targetIndex = 0;
    }

    // Update is called once per frame
    new void Update()
    {
        
        if (playerIsInRange && !isRoaming)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            x = transform.position.x;
        }
        else if (isRoaming)
        {
            Vector2 targetDirection = objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position - transform.position;

            float RotateSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position) < .05f)
            {
                if (waitTime <= 0)
                {
                    if(roamsRandomly == false)
                    {
                        targetIndex += 1;
                    }
                    else if (roamsRandomly)
                    {
                        targetIndex = Random.Range(0, objectThatHasMovePositions.GetComponent<movePositions>().targetLocations.Length);
                    }
                    if (targetIndex == objectThatHasMovePositions.GetComponent<movePositions>().targetLocations.Length)
                    {
                        targetIndex = 0;
                    }
                    StartCoroutine(ResetTime());
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerIsInRange = true;
            isRoaming = false;
            target = player.transform.position;
            cc.radius += 7;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            playerIsInRange = false;
            isRoaming = true;
            cc.radius -= 3;
        }


    }

    IEnumerator DestroyEnemy()
    {
        dead = true;
        yield return new WaitForSeconds(0.25f);
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        Destroy(gameObject);
    }

    IEnumerator ResetTime()
    {
        yield return new WaitForSeconds(0.5f);
        waitTime = startWaitTime;
    }
}
