using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
	float despawnTimer;
	public bool die = false;
	GameObject particles;

	void OnEnable()
	{
		despawnTimer = Shooting.player.despawnTime;
	}

    void Update()
    {
        despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0) {
			if (die)
				Destroy(gameObject);
			else {
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				gameObject.SetActive(false);
			}

			//particles on death
			if (particles != null)
				Instantiate(particles, transform.position, particles.transform.rotation);
		}
    }

	public void SetParticles(GameObject particles) {
		this.particles = particles;
	}
}
