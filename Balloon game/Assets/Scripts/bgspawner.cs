using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgspawner : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint,Quaternion.Euler(-90,0,0));
        nextSpawnPoint = temp.transform.GetChild(0).TransformPoint(Vector3.zero);

    
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            
          SpawnTile();
        
        }
    }
}