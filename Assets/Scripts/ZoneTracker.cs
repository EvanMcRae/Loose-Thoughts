using UnityEngine;
using System.Collections.Generic;

public class ZoneTracker : MonoBehaviour
{

    public List<Obstacle> spawnedObstacles = new List<Obstacle>();


    public List<PremadeObstacle> FullsizeObstaclePool = new List<PremadeObstacle>();

    //Basically the fixed base speed of the player moving forwards
    //Used to scroll backgrounds and obstacles
    public float levelSpeed = 1;

    public static ZoneTracker main;

    float bgLayerStepDistance = 5;



    public List<BGObjectSpawnInfo> bgObjects = new List<BGObjectSpawnInfo>();

    public float BackgroundObjectFrequency;

    public float obstacleSpawnHeight;

    public GameObject bgContainer;

    //Set Order of zones:
    //They will have a transition picture between them
    //Should order be random or pre-determined?

    //List of zones:
    //happy
    //neutral
    //angry
    //depressed/sad
    //scared
    //anxiety


    public float lastObstacleEndPos
    {
        get
        {
            return spawnedObstacles[^1].transform.position.x + 1;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        MakeBackgroundElements();
        ObstacleUpdate();
    }


    void ObstacleUpdate()
    {

    }

    void MakeBackgroundElements()
    {
        //if(Random.Range(0f, 1f) < Time.deltaTime * BackgroundObjectFrequency)
        //{
        //    SpawnBackgroundObject();
        //}

        //Redone to allow for spawning more than one in a frame (will probably not actually change anything)
        for(float i = Time.deltaTime * BackgroundObjectFrequency - Random.Range(0f, 1f); i > 0; i--)
        {
            SpawnBackgroundObject();
        }
    }


    public float GetBackgroundLayer(float layer)
    {
        return bgLayerStepDistance * layer;
    }

    public float GetBackgroundLayerStartOffset(float layer)
    {
        //float slope = Mathf.Atan(34 * Mathf.Deg2Rad); //Gotten based off of Camera FOV
        float slope = Mathf.Tan(Camera.main.fieldOfView/2 * Mathf.Deg2Rad); //Gotten based off of Camera FOV

        return slope * 2 * GetBackgroundLayer(layer) * Camera.main.aspect;
    }


    void SpawnBackgroundObject()
    {
        if(bgObjects.Count <= 0)
        {
            Debug.LogWarning("No background objects to spawn!");
            return;
        }

        float MaxChance = 0;

        for(int i = 0; i < bgObjects.Count; i++)
        {
            MaxChance += bgObjects[i].chance;
        }

        float randVal = Random.Range(0, MaxChance);
        float partialChanceRange = 0;

        BGObjectSpawnInfo chosenObject = bgObjects[0];

        for(int i = 0; i < bgObjects.Count; i++)
        {
            if(bgObjects[i].chance + partialChanceRange >= randVal && randVal > partialChanceRange)
            {
                chosenObject = bgObjects[i];
            }
            partialChanceRange += bgObjects[i].chance;
        }

        //Need to better scale this range
        //float xPos = Random.Range(-5f, 5f);
        float playAreaWidth = GetBackgroundLayerStartOffset(chosenObject.backgroundLayer) / Camera.main.aspect;
        float yPos = Random.Range(-playAreaWidth, playAreaWidth);

        GameObject spawnedObj = Instantiate(chosenObject.prefab, new Vector3( obstacleSpawnHeight + GetBackgroundLayerStartOffset(chosenObject.backgroundLayer), yPos, GetBackgroundLayer(chosenObject.backgroundLayer)), new Quaternion(), bgContainer.transform);
        BackgroundObject bgObj = spawnedObj.GetComponent<BackgroundObject>();
        bgObj.bgLayer = chosenObject.backgroundLayer;
    }
}

[System.Serializable]
public class BGObjectSpawnInfo
{
    public GameObject prefab;
    public int backgroundLayer;
    public float chance;
}

