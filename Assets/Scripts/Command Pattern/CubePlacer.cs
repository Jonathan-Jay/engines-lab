using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : IFactory
{
	public static GameObject cube;

    public GameObject PlaceShape(Vector3 position, Color color)
    {
        GameObject newCube = GameObject.Instantiate(cube, position, Quaternion.identity);
        newCube.GetComponentInChildren<MeshRenderer>().material.color = color;
        return newCube;
    }
}
