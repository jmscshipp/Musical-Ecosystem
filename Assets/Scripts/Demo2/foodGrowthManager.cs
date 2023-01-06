using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodGrowthManager : MonoBehaviour
{
    public GameObject foodPrefab;
    public int foodAvailable;
    public activeFoodManager afm;
    List<Vector2> clusterLocations;

    // SETTINGS
    private float arenaBoundLeft, arenaBoundRight, arenaBoundTop, arenaBoundBottom;
    public int startClusterNum;
    public float clusterDistance = 2f; // how far clusters need to be from each other
    public int clusterSizeMin, clusterSizeMax;
    public float clusterSpread = 1f; // how far food spawns from cluster center
    public int minActiveFood = 5;
    private bool gameStarted = false;

    void Start()
    {
        arenaBoundLeft = -3.4f;
        arenaBoundRight = 3.4f;
        arenaBoundTop = 3.4f;
        arenaBoundBottom = -3.4f;

        clusterLocations = new List<Vector2>();
        StartCoroutine(SpawnFoodCluster(startClusterNum, Random.Range(clusterSizeMin, clusterSizeMax)));
    }

    void Update()
    {
        if ((afm.activeFood.Count <= minActiveFood) && gameStarted)
        {
            StartCoroutine(SpawnFoodCluster(startClusterNum, Random.Range(clusterSizeMin, clusterSizeMax)));
        }
    }

    IEnumerator SpawnFoodCluster(int clusterNum, int foodInClusterNum)
    {
        for (int i = 0; i < clusterNum; i++)
        {
            Vector2 clusterLocation = GetRandomPointInArena();
    
            // spawn food morsels
            for (int j = 0; j < foodInClusterNum; j++)
            {
                Vector2 foodLocation = new Vector2(clusterLocation.x + Random.Range(0f, clusterSpread), clusterLocation.y + Random.Range(0f, clusterSpread));
                GameObject newFood = Instantiate(foodPrefab, EnvironmentClamp(foodLocation), Quaternion.identity);
                afm.GetActiveFood().Add(newFood.GetComponent<food>());
                yield return new WaitForSeconds(0.1f);
            }
    
            yield return new WaitForSeconds(0.5f);
            gameStarted = true;
        }
    }
    
    Vector2 EnvironmentClamp(Vector2 originalPos)
    {
        return new Vector2(Mathf.Clamp(originalPos.x, arenaBoundLeft, arenaBoundRight), Mathf.Clamp(originalPos.y, arenaBoundBottom, arenaBoundTop));
    }

    bool ClusterSpawnVerified(Vector2 newClusterSpot)
    {
        foreach (Vector2 clusterLocation in clusterLocations)
        {
            if (Vector2.Distance(newClusterSpot, clusterLocation) >= clusterDistance)
                return false;
        }
        return true;
    }
    
    Vector2 GetRandomPointInArena()
    {
        return new Vector2(Random.Range(arenaBoundLeft, arenaBoundRight), 
            Random.Range(arenaBoundBottom, arenaBoundTop));
    }
}
