using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
	public float delayMin = 1;
	public float delayMax = 5;
	private float counter;
	public float speed = 5;
	private Rigidbody rb;
	public Vector3 curDirection = Vector3.zero;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody>();
		counter = Random.Range(delayMin, delayMax);
		curDirection =
			Vector3.right * Random.Range(-1f, 1f) * speed +
			Vector3.forward * Random.Range(-1f, 1f) * speed;
	}

    // Update is called once per frame
    void Update()
    {
		counter -= Time.deltaTime;
		if (counter <= 0) {
			counter += Random.Range(delayMin, delayMax);
			//movement
			curDirection =
				Vector3.right * Random.Range(-1f, 1f) * speed +
				Vector3.forward * Random.Range(-1f, 1f) * speed;
		}
		curDirection.y = rb.velocity.y;
		rb.velocity = curDirection;
	}
}
