using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 800;
    [SerializeField] private Transform levelStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private PlayerMovement player;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelStart.Find("EndPosition").position;
        //SpawnLevelPart();   
        
    }
   


    private void Update()
    {
        if(Vector3.Distance(player.GetPosition(),lastEndPosition)< PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }


    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart,lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

   private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;

    }
}
