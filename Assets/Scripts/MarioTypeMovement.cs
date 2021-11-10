using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioTypeMovement : MonoBehaviour
{
	//returns number of enemies killed
	public static event System.Action<int> enemyKilled;

    public float speed = 25;
    public float jumpStrength = 10;
    private float angle = 0;
    private bool grounded = true;
	private int count = 0;
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
        }

		//removed from grounded check
            //if touching enemy
            if (other.gameObject.tag == "Enemy") {
				EnemySpawner.enemies.Remove(other.gameObject.GetComponent<Enemy>());
                GameObject.Destroy(other.gameObject);
				enemyKilled?.Invoke(++count);
            }
    }
}
