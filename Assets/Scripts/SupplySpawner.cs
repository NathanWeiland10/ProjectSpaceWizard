using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplySpawner : MonoBehaviour
{
    void Start()
    {
        GameObject[] supplies = GameObject.FindGameObjectsWithTag("Supply");

        GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag("SupplySpawnLocation");

        

        for(int i = 0; i < spawnLocations.Length; i ++)
        {

            if(Random.Range(0,5) >= 2){

                GameObject curSupply = supplies[Random.Range(0, supplies.Length)];

                Instantiate(curSupply, spawnLocations[i].transform.position, Quaternion.identity);
            }
        }

    }
}
