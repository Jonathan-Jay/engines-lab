using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
	GameObject PlaceShape(Vector3 position, Color colour);
}
