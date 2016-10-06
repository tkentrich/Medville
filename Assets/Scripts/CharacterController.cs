using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public enum CharacterState {Idle, Recover, Attack, TakeDamage, Dead};

	public OverallController controller;

	private Animator podiumAnimator;
	private GameObject target;
	private Animator anim;
	private int health;
	private float recoverTimeLeft;
	private CharacterState state;

	void Awake() {
		// TODO: Set all kinds of crap
		podiumAnimator = GetComponent<Animator>();
		state = CharacterState.Idle;
		target = null;
	}

	void OnMouseUp() {
		if (controller.GetNextClick() == OverallController.NextClick.SELECT) {
			controller.Select(gameObject);
			Select();
		} else if (controller.GetNextClick() == OverallController.NextClick.TARGET) {
			
		}
	}

	public void Select() {
		podiumAnimator.SetTrigger("Select");
	}
	public void Unselect() {
		podiumAnimator.SetTrigger("Unselect");
	}

	public void SetTarget(GameObject newTarget) {
		target = newTarget;
	}

	void Update() {
		if (state == CharacterState.Idle) {
			if (target != null) {
				print("Hit target: " + target);
				transform.LookAt(target.transform);
				anim.SetTrigger("Attack");
			}
		}
	}

	public void CompleteHit() {
		print("Pow!");
	}
}
