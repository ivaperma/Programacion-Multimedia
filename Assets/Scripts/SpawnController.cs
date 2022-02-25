using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    private Vector3 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2f);
        while(true)
        {
            randomPosition = new Vector3(Random.Range(-11f,77f),0,0);
            Instantiate(enemyPrefab,randomPosition,Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f,4f));
        }
        
    }
}
