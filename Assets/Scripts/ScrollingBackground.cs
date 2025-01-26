using UnityEngine;
using System.Collections.Generic;

public class ScrollingBackground : MonoBehaviour
{

    public GameObject backgroundTile;
    public Sprite sprite;


    public float scale;
    List<SpriteRenderer> tiles = new List<SpriteRenderer>();

    float cameraDistBounds;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float slope = Mathf.Tan(Camera.main.fieldOfView / 2 * Mathf.Deg2Rad); //Gotten based off of Camera FOV

        cameraDistBounds = slope * 2 * (transform.position.z + 5) * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(SpriteRenderer tile in tiles)
        {
            tile.transform.position -= Vector3.right * ZoneTracker.main.levelSpeed * Time.deltaTime;
            tile.sprite = sprite;
        }

        if(tiles.Count > 0 && tiles[0].transform.position.x + scale/2 < -cameraDistBounds)
        {
            Destroy(tiles[0]);
            tiles.RemoveAt(0);
        }

        if (tiles.Count == 0 || tiles[^1].transform.position.x - scale/2  + 1 < cameraDistBounds)
        {
            float xPos = -cameraDistBounds;
            if (tiles.Count != 0)
                xPos = tiles[^1].transform.position.x + scale;
            GameObject addedObj = Instantiate(backgroundTile, new Vector3(xPos, 0, transform.position.z), new Quaternion(), transform);
            tiles.Add(addedObj.GetComponent<SpriteRenderer>());
        }
    }
}
