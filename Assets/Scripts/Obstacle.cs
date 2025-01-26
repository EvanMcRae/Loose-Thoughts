using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 targetPlayer;
    public bool handleMovement = true;
    public float currentDistanceBehindPlayer;
    public AK.Wwise.Event spawnSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public virtual void Start()
    {
        targetPlayer = GameObject.FindWithTag("Player").transform.position;
        spawnSound?.Post(gameObject);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (PauseMenu.paused) return;
        //
        if (handleMovement)
            transform.position -= Vector3.right * ZoneTracker.main.levelSpeed * Time.deltaTime;

        targetPlayer = GameObject.FindWithTag("Player").transform.position;
        currentDistanceBehindPlayer = Vector2.Distance(transform.position, targetPlayer);
        AkSoundEngine.SetRTPCValue("emotionDistance", currentDistanceBehindPlayer, gameObject);
    }
}
