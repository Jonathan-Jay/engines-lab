using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class EnemyPopup : MonoBehaviour
{
	[SerializeField] Text textBox;
	private RectTransform trans;
	private Vector3 pos = Vector3.zero;
	private Vector3 target = Vector3.zero;
	public Vector3 offset = Vector3.up;
	private Queue<string> messages = new Queue<string>();
	private float counter = 0;
	public float delay = 0.5f;
	private bool animating = false;

	private void Awake() {
		trans = GetComponent<RectTransform>();
		pos = trans.localPosition;
		target = pos;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.M)) {
			animating = false;
			counter = Time.deltaTime;
			trans.localPosition = pos;
		}

		if (counter > 0 && !animating) {
			counter -= Time.deltaTime;
			if (counter <= 0) {
				target = pos;
				animating = true;
			}
		}

		if (animating) {
			trans.localPosition = Vector3.Lerp(trans.localPosition, target, Time.deltaTime * 5f);
			if (Vector3.Distance(trans.localPosition, target) < 0.1f) {
				animating = false;
				trans.localPosition = target;
			}
		}

		if (messages.Count > 0 && counter <= 0 && !animating) {
			textBox.text = messages.Dequeue();
			counter = delay;
			target = pos + offset;
			animating = true;
		}
	}

    private void OnEnable() {
		MarioTypeMovement.enemyKilled += Popup;
	}

	private void OnDisable() {
		MarioTypeMovement.enemyKilled -= Popup;
	}

	void Popup(int number) {
		messages.Enqueue("Enemy #" + number + " Killed");
	}
}
