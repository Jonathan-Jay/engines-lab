using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceShapeCommand : ICommand
{
    Vector3 position;
    Color color;
	IFactory factory;
    GameObject reference;

    public PlaceShapeCommand(Vector3 position, Color color, IFactory factory)
    {
        this.position = position;
        this.color = color;
		this.factory = factory;
    }
    
    public void Execute()
    {
        reference = factory.PlaceShape(position, color);
    }

    public void Undo()
    {
		if (reference != null)
			GameObject.Destroy(reference);
    }
}
