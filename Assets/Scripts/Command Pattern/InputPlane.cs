using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public GameObject cubePrefab;
    public GameObject pillPrefab;
	IFactory[] factory = new IFactory[2];
	int currFactory = 0;

    // Start is called before the first frame update
    void Awake()
    {
		factory[0] = new CubePlacer();
		CubePlacer.cube = cubePrefab;
		factory[1] = new PillPlacer();
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

                ICommand command = new PlaceShapeCommand(hitInfo.point, c, factory[currFactory]);
                CommandInvoker.AddCommand(command);
            }
        }
        
    }

	public void SetFactory(int val) {
		currFactory = val;
	}
}
