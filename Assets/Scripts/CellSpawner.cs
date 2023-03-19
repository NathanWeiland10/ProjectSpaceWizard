using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] possibleCells;

    [SerializeField]
    private readonly int gridWidth = 5;

    [SerializeField]
    private readonly int gridLength = 5;

    [SerializeField]
    private readonly int gridHeight = 5;

    [SerializeField]
    private readonly int spaceBetweenCells = 1;
    //ie cell length/width/height;

    // Start is called before the first frame update
    void Start()
    {
        possibleCells = FindCells();

        GameObject[ , , ] cells = GenerateCells(possibleCells);

        //erode some cells
        cells = erodeCells(cells);


        //spawn remaining cells
        spawnCells(cells);

    
    }

    GameObject[ , , ] erodeCells(GameObject[ , , ] currentCells){
         for(int x = 0; x < currentCells.GetLength(0); x ++){
            for(int y = 0; y < currentCells.GetLength(1); y ++){
                for(int z = 0; z < currentCells.GetLength(2); z ++){

                    if(IsOnEdge(x,y,z))
                    {
                        GameObject empty = new GameObject();
                        empty.tag = "EmptyCell";
                        currentCells[x,y,z] = empty;
                    }
                
        
                }
            }
        }


        return currentCells;
    }

    public bool IsOnEdge(int x, int y, int z)
    {
        if(x == 0 && z == 0){
            return true;
        }
        else if(x == 0 && y == 0){
            return true;
        }
        else if(z == 0 && y == 0){
            return true;
        }
        else if(x == gridWidth - 1 && z == gridHeight - 1){
            return true;
        }
        else if(x == gridWidth - 1 && y == gridLength - 1){
            return true;
        }
        else if(z == gridHeight - 1 && y == gridLength - 1){
            return true;
        }
        else if(x == 0 && y == gridLength - 1){
            return true;
        }
        else if(y == 0 && x == gridWidth - 1){
            return true;
        }
        else if(z == 0 && x == gridHeight - 1){
            return true;
        }
        else if(x == 0 && z == gridHeight - 1){
            return true;
        }
        else if(y == 0 && z == gridHeight - 1){
            //EQUAL
            return true;
        }
        else if(z == 0 && y == gridHeight - 1){
            return true;
        }

        return false;
    }

    GameObject[ , , ] GenerateCells(GameObject[] possibleCells){

        GameObject[ , , ] returnArr = new GameObject [gridWidth, gridLength, gridHeight];
        
        for(int i = 0; i < gridWidth; i ++){

            for(int j = 0; j < gridLength; j ++){

                for(int k = 0; k < gridHeight; k ++){

                    returnArr[i, j, k] = possibleCells[Random.Range(0, possibleCells.Length)];
                }       
            }
        }
        
        return returnArr;
    }



    void spawnCells(GameObject[ , , ] objs){
        

        for(int i = 0; i < objs.GetLength(0); i ++){
            for(int j = 0; j < objs.GetLength(1); j ++){
                for(int k = 0; k < objs.GetLength(2); k ++){
                    Instantiate(objs[i,j,k], 
                        new Vector3(i * spaceBetweenCells, j * spaceBetweenCells, k * spaceBetweenCells), 
                        Quaternion.identity);
                }
            }
        }

    }

    GameObject[] FindCells(){
        return GameObject.FindGameObjectsWithTag("cell");
    }
}
