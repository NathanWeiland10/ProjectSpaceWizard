using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create a new cube primitive to set the color on
       GameObject visual = createVisualizerMesh();


       // Get the Renderer component from the new cube
       var cubeRenderer = visual.GetComponent<Renderer>();

       // Call SetColor using the shader property name "_Color" and setting the color to red
       cubeRenderer.material.SetColor("_Color", Color.red);

    }

    GameObject createVisualizerMesh(){

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = gameObject.transform.position;
        cube.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        return cube;
    }

}
