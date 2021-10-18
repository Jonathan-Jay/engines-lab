using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillPlacer : IFactory
{
	public static GameObject pill;

	Vector3 position;
	Color colour;

	public PillPlacer(Vector3 position, Color colour) {
		this.position = position;
		this.colour = colour;
	}

	public GameObject PlaceShape()
	{
		GameObject newPill = GameObject.Instantiate(pill, position, Quaternion.identity);
		newPill.GetComponentInChildren<MeshRenderer>().material.color = colour;
		return newPill;
	}
}
