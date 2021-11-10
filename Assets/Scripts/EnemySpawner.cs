using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject prefab;

	public float minDelay = 1f;
	public float maxDelay = 5f;
	public int maxCount = 10;

	public static List<Enemy> enemies = new List<Enemy>(0);

	float counter;

    // Start is called before the first frame update
    void Start()
    {
        Enemy[] all = FindObjectsOfType<Enemy>();
		foreach (Enemy enemy in all) {
			enemies.Add(enemy);
		}

		counter = Random.Range(minDelay, maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count >= maxCount)	return;

		if (counter > 0) {
			counter -= Time.deltaTime;
			if (counter <= 0) {
				counter = Random.Range(minDelay, maxDelay);
				enemies.Add(Instantiate(prefab, transform.position, Quaternion.identity).GetComponent<Enemy>());
			}
		}
    }
}
