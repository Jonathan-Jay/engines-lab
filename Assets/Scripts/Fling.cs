using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fling : MonoBehaviour
{
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Vector3 movement = Vector3.zero;
            movement.x = Input.GetAxis("Mouse X");
            movement.y = Input.GetAxis("Mouse Y");

            movement = mainCamera.transform.rotation * movement;

            GetComponent<Rigidbody>().AddForce(movement, ForceMode.Impulse);
        }

        if (Input.GetMouseButton(1)) {
            Vector3 movement = Vector3.zero;
            movement.x = Input.GetAxis("Mouse X");
            movement.z = Input.GetAxis("Mouse Y");

            movement = mainCamera.transform.rotation * movement;

            GetComponent<Rigidbody>().AddForce(movement, ForceMode.Impulse);
        }
    }
}
