using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public GameObject cubePrefab;
    public GameObject pillPrefab;
	int currFactory = 0;

    // Start is called before the first frame update
    void Awake()
    {
		CubePlacer.cube = cubePrefab;
		PillPlacer.pill = pillPrefab;
		
        maincam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

				IFactory factory = null;
				if (currFactory == 0)
					factory = new CubePlacer(hitInfo.point, c);
				else
					factory = new PillPlacer(hitInfo.point, c);

                ICommand command = new PlaceShapeCommand(factory);
                CommandInvoker.AddCommand(command);
            }
        }
        
    }

	public void SetFactory(int val) {
		currFactory = val;
	}
}
