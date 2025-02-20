using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public GameObject laserPrefab;
    public GameObject blockPrefab;
    public List<Vector3> blockSpawnPoints = new List<Vector3>();
    public float laserSpawnDelay = 2.5f;
    public float blockSpawnDelay = 5f;
    public float speed = 50f;
    public float laserSpawnDist = 100f;

    void Start(){
        StartCoroutine(SpawnObstaclesRoutine());
    }
    IEnumerator SpawnObstaclesRoutine(){
        
        while(true){
            int choice = Random.Range(0, 2);
            if(choice == 0){
                GameObject newOb = Instantiate(laserPrefab, new Vector3(Random.Range(-2.5f, 2.5f), 0, laserSpawnDist), Quaternion.identity);
                newOb.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -50);
                Destroy(newOb, 20f);
                yield return new WaitForSeconds(laserSpawnDelay); 
            }else{

                transform.position = blockSpawnPoints[Random.Range(0, blockSpawnPoints.Count)];

                GameObject newOb = Instantiate(blockPrefab, blockSpawnPoints[Random.Range(0, blockSpawnPoints.Count)], Quaternion.identity);
                newOb.GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, -50);
                Destroy(newOb, 20f);
                yield return new WaitForSeconds(blockSpawnDelay);
            }
            
        }
    }
}
