using UnityEngine;
using System.Collections.Generic;

public class BackgroundObject : MonoBehaviour
{
    //Scrolls down and deletes itself when no longer in play area
    public float bgLayer = 0;

    public SpriteRenderer rend;


    public float killHeight = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        killHeight = -ZoneTracker.main.GetBackgroundLayerStartOffset(bgLayer) - ZoneTracker.main.obstacleSpawnHeight;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        

        //Delete if it has not been seen for 2 seconds and is below the camera (it always moves down so no chance its seen again)
        if(killHeight > transform.position.x)
        {
            Destroy(gameObject);
        }

        transform.position -= Vector3.right * ZoneTracker.main.levelSpeed * Time.deltaTime;
    }
}

