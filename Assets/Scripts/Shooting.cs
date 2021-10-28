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
	public bool usingQueue;

	GameObject temp = null;
	public int current = 0;
	public List<GameObject> particlePrefabs;

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
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			current = (++current) % particlePrefabs.Count;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			current = (--current < 0) ? particlePrefabs.Count - 1 : current;
		}

        if (Input.GetKeyDown(KeyCode.E)) {
			if (usingQueue) {
				temp = bullets.Dequeue();
				temp.SetActive(false);
				temp.SetActive(true);
				temp.transform.position = gun.position + gun.transform.forward;
				temp.transform.rotation = gun.rotation;
				temp.GetComponent<Rigidbody>().velocity = gun.forward * speed;

				temp.GetComponent<SelfDestruct>().SetParticles(particlePrefabs[current]);

				bullets.Enqueue(temp);
			}
			else {
				temp = Instantiate(bulletPrefab, gun.position + gun.transform.forward, gun.rotation);
				temp.GetComponent<Rigidbody>().velocity = gun.forward * speed;
				temp.GetComponent<SelfDestruct>().die = true;
			}

			temp = null;
		}
    }
}
