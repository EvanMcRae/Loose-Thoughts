using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomlyMovingEnemy : Obstacle
{
    public bool canMove;
    private int targetIndex;
    public float startWaitTime;

    private float waitTime;

    public GameObject objectThatHasMovePositions;
    public float maxRotation;
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
        if (PauseMenu.paused) return;

        if (canMove)
        {
            Vector2 targetDirection = objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position - transform.position;

            float RotateSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, objectThatHasMovePositions.GetComponent<movePositions>().targetLocations[targetIndex].position) < .05f)
            {
                if (waitTime <= 0)
                {
                    //targetIndex += 1;
                    targetIndex = Random.Range(0, objectThatHasMovePositions.GetComponent<movePositions>().targetLocations.Length);
                    if (targetIndex == objectThatHasMovePositions.GetComponent<movePositions>().targetLocations.Length)
                    {
                        targetIndex = 0;
                    }
                    StartCoroutine(ResetTime());
                }
                else
                {
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
    }
}
