using UnityEngine;

public class GroundTile : MonoBehaviour
{
    bgspawner groundSpawner;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<bgspawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.easySpawnTile();
        Destroy(gameObject, 2);
        //int randomNumber = Random.Range(0, 2);
        //if (randomNumber == 0)
        //{
        //    groundSpawner.easySpawnTile();
        //    Destroy(gameObject, 2);
        //}
        //if(randomNumber == 1)
        //{
        //    groundSpawner.mediumSpawnTile();
        //    Destroy(gameObject, 2);
        //}
    }
    // Update is called once per frame
    void Update()
    {
        //float randomNumber = Random.Range(0, 2);
    }
}
