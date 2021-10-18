using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : IFactory
{
	public static GameObject cube;
	Vector3 position;
	Color colour;
	public CubePlacer(Vector3 position, Color colour) {
		this.position = position;
		this.colour = colour;
	}

    public GameObject PlaceShape()
    {
        GameObject newCube = GameObject.Instantiate(cube, position, Quaternion.identity);
        newCube.GetComponentInChildren<MeshRenderer>().material.color = colour;
        return newCube;
    }
}
