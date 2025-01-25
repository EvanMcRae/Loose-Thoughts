using UnityEngine;
using System.Collections.Generic;

public class BackgroundObject : MonoBehaviour
{
    //Scrolls down and deletes itself when no longer rendered
    float lastSeen = 0;
    float destroyTimer = 2;

    public SpriteRenderer rend;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(rend.isVisible)
        {
            lastSeen = Time.time;
        }

        //Delete if it has not been seen for 2 seconds and is below the camera (it always moves down so no chance its seen again)
        if(lastSeen + destroyTimer < Time.time && gameObject.transform.position.y < Camera.main.transform.position.y)
        {
            Destroy(gameObject);
        }

        transform.position -= Vector3.up * ZoneTracker.main.levelSpeed * Time.deltaTime;
    }
}

