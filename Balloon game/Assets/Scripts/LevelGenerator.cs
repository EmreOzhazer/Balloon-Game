using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 800;
    [SerializeField] private Transform levelStart;
    [SerializeField] private List<Transform> levelPartEasyList;
    [SerializeField] private List<Transform> levelPartMediumList;
    [SerializeField] private List<Transform> levelPartHardList;
    [SerializeField] private List<Transform> levelPartImpossibleList;


    private int levelPartsSpawned;

    private enum Difficulty
    {
        Easy,
        Medium,
        Hard,
        Impossible
    }


    [SerializeField] private PlayerMovement player;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelStart.Find("EndPosition").position;
        //SpawnLevelPart();   

    }



    private void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }


    private void SpawnLevelPart()
    {
        List<Transform> difficultyLevelPartList;


        switch (GetDifficulty())
        {
            default:
            case Difficulty.Easy: difficultyLevelPartList = levelPartEasyList; break;
            case Difficulty.Medium: difficultyLevelPartList = levelPartMediumList; break;
            case Difficulty.Hard: difficultyLevelPartList = levelPartHardList; break;
            case Difficulty.Impossible: difficultyLevelPartList = levelPartImpossibleList; break;

        }

        Transform chosenLevelPart = difficultyLevelPartList[Random.Range(0, difficultyLevelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        levelPartsSpawned++;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;

    }

    private Difficulty GetDifficulty()
    {
        if (levelPartsSpawned >= 15) return Difficulty.Impossible;
        if (levelPartsSpawned >= 10) return Difficulty.Hard;
        if (levelPartsSpawned >= 5) return Difficulty.Medium;
        return Difficulty.Easy;
    }
}
