using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationVisualizer : MonoBehaviour
{
    ///<summary>A visualization for supplylocation spawn points</summary>
    void Start()
    {
        // Create a new cube primitive to set the color on
       GameObject visual = CreateVisualizerMesh();


       // Get the Renderer component from the new cube
       var cubeRenderer = visual.GetComponent<Renderer>();

       // Call SetColor using the shader property name "_Color" and setting the color to red
       cubeRenderer.material.SetColor("_Color", Color.red);

    }

    ///<summary>creates the mesh for the spawn point visulization</summary>
    ///<return>GameObject with a 3D mesh attached as child</return>
    GameObject CreateVisualizerMesh(){

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = gameObject.transform.position;
        cube.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        return cube;
    }

}
