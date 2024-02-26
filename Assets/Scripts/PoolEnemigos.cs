using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemigos : MonoBehaviour
{
    
    public GameObject navePrefab;

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNave", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnNave()
    {
        Instantiate(navePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
