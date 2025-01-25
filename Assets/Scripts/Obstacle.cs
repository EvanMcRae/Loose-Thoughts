using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        //
        transform.position -= Vector3.right * ZoneTracker.main.levelSpeed * Time.deltaTime;

    }
}
