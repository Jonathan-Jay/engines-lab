using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
	public GameObject bulletPrefab;
	Queue<GameObject> bullets = new Queue<GameObject>();

	public Transform gun;
	public float speed = 100f;
	public float despawnTime = 5f;
	public static Shooting player;

	GameObject temp = null;

    // Start is called before the first frame update
    void Start()
    {
		player = this;

		for (int i = 0; i < 20; ++i) {
			temp = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
			temp.SetActive(false);
        	bullets.Enqueue(temp);
		}
		temp = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
			temp = bullets.Dequeue();
			temp.SetActive(true);
			temp.transform.position = gun.position + gun.transform.forward;
			temp.GetComponent<Rigidbody>().velocity = gun.forward * speed;
			bullets.Enqueue(temp);
		}
    }
}
