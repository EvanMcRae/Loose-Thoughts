using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;

    public bool handleMovement = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (PauseMenu.paused) return;
        //
        if (handleMovement)
            transform.position -= Vector3.right * ZoneTracker.main.levelSpeed * Time.deltaTime;

    }
}
