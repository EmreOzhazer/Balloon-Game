using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgspawner : MonoBehaviour
{
    [SerializeField] GameObject easyGroundTile;
    //[SerializeField] GameObject mediumGroundTile;

    Vector3 nextSpawnPoint;

    public void easySpawnTile()
    {
        GameObject temp = Instantiate(easyGroundTile, nextSpawnPoint,Quaternion.Euler(-90,0,0));
        nextSpawnPoint = temp.transform.GetChild(0).TransformPoint(Vector3.zero);

    
    }

    //public void mediumSpawnTile()
    //{
    //    GameObject temp = Instantiate(mediumGroundTile, nextSpawnPoint, Quaternion.Euler(-90, 0, 0));
    //    nextSpawnPoint = temp.transform.GetChild(0).TransformPoint(Vector3.one);
    //}

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            
          easySpawnTile();
        
        }

    }
}