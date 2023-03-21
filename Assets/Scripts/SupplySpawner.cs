using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplySpawner : MonoBehaviour
{

    [SerializeField]
    private int percent = 30;


    ///<summary> Begin spawning supplies on first frame </summary>
    void Start()
    {
        PercentErrorCheck();

        GameObject[] supplies = GameObject.FindGameObjectsWithTag("Supply");

        GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag("SupplySpawnLocation");

        spawnSupplies(supplies, spawnLocations);

    }


    ///<summary>Error checks for percentage </summary>
    ///<exception cref="LogError">  1 < percent < 99 <exception>
    void PercentErrorCheck(){
        if(percent > 99){
            Debug.LogError("Percentage must be less than 99, no supplies will spawn. Percent: " + percent);
            return;
        }

        if(percent < 1){
            Debug.LogError("Percentage must be greater than 1, no supplies will spawn. Percent: "+  percent);
            return;
        }
    }



    ///<summary> Spawns a random supply at a random position </summary>
    ///<param name="supplies"> Game object array of supplies </param>
    ///<param name="locations">Game object array of locations </param>
    ///<return> void, spawns directly into world space </return>
    void spawnSupplies(GameObject[] supplies, GameObject[] locations){

        for(int i = 0; i < locations.Length; i ++)
        {
            //random chance to instantiate a supplu object at a point
            
            if(UnityEngine.Random.Range(0,100) >= percent){

                GameObject curSupply = supplies[UnityEngine.Random.Range(0, supplies.Length)];

                Instantiate(curSupply, locations[i].transform.position, Quaternion.identity);
            }
        }
    }
}
