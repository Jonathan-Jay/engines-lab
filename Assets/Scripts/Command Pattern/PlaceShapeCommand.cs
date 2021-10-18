using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceShapeCommand : ICommand
{
	IFactory factory;
    GameObject reference;

    public PlaceShapeCommand(IFactory factory)
    {
		this.factory = factory;
    }
    
    public void Execute()
    {
        reference = factory.PlaceShape();
    }

    public void Undo()
    {
		if (reference != null)
			GameObject.Destroy(reference);
    }
}
