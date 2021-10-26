using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
	float despawnTimer;

	void OnEnable()
	{
		despawnTimer = Shooting.player.despawnTime;
	}

    void Update()
    {
        despawnTimer -= Time.deltaTime;
		if (despawnTimer <= 0) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			gameObject.SetActive(false);
		}
    }
}
