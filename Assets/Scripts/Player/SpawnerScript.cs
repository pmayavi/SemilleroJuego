using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public List<GameObject> SpawnList = new List<GameObject>();
    public float SpawnTime;
    private Vector3 SpawnPos;
    private float x, y;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        SpawnPos = transform.position;
        x = Random.Range(-50, 50) + SpawnPos.x;
        while(x > 90 || x < -90){
            x = Random.Range(-50, 50) + SpawnPos.x;
        }
        y = Random.Range(-25, 25) + SpawnPos.y;
        while(y > 40 || y < -40){
            y = Random.Range(-25, 25) + SpawnPos.y;
        } 
        SpawnPos.x = x;
        SpawnPos.y = y;
        Instantiate(SpawnList[Random.Range(0,SpawnList.Count)], SpawnPos, Quaternion.identity);
        yield return new WaitForSeconds(SpawnTime);
        StartCoroutine(Spawn());
    }
}
