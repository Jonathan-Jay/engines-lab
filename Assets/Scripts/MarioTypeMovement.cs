using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioTypeMovement : MonoBehaviour
{

    public float speed = 25;
    public float jumpStrength = 10;
    private float angle = 0;
    private bool grounded = true;
    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        Vector3 movement = Vector3.zero;
        movement.y = rigid.velocity.y;
        movement.x = Input.GetAxis("Horizontal") * speed;
        movement.z = Input.GetAxis("Vertical") * speed;
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            grounded = false;
            movement.y = jumpStrength;
        }

        rigid.velocity = transform.rotation * movement;
    }

    void OnCollisionEnter(Collision other) {
        //if landing on ground
        if (other.impulse.y > 0.6f) {
            grounded = true;
            //if touching enemy
            if (other.gameObject.tag == "Enemy") {
                GameObject.Destroy(other.gameObject);
            }
        }
    }
}
