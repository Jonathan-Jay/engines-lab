using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillPlacer : IFactory
{
	public static GameObject pill;

	public GameObject PlaceShape(Vector3 position, Color color)
	{
		GameObject newPill = GameObject.Instantiate(pill, position, Quaternion.identity);
		newPill.GetComponentInChildren<MeshRenderer>().material.color = color;
		return newPill;
	}
}
