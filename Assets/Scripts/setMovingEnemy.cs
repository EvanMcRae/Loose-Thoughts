using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setMovingEnemy : Obstacle
{
    public bool canMove;
    private int targetIndex;

    //public int boxerNumber;

    public float startWaitTime;

    private float waitTime;
   // private bool firstWalked = false;

    public GameObject objectThatHasMovePositions;

    public float verticalSpeed;
    public float maxRotation;
    float x = 0;
    private float startSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    new void Start()
    {
        canMove = true;

        waitTime = startWaitTime;
        targetIndex = 0;
        startSpeed = speed;
    }

    // Update is called once per frame
    new void Update()
    {
        //if (canMove && !firstWalked)
        //{
        //    firstWalked = true;
        //}
        if (canMove)
        {
            Vector2 targetDirection = objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position - transform.position;

            float RotateSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position) < .05f)
            {
                if (waitTime <= 0)
                {
                    targetIndex += 1;
                    if (targetIndex == objectThatHasMovePositions.GetComponent<movePositions>().targetLocations.Length)
                    {
                        targetIndex = 0;
                    }
                    StartCoroutine(ResetTime());
                }
                else
                {
                    speed = 0;
                    transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * startSpeed));
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    IEnumerator ResetTime()
    {
        yield return new WaitForSeconds(0.5f);
        waitTime = startWaitTime;
        speed = startSpeed;
    }
}
