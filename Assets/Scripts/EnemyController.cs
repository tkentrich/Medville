using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public enum EnemyState {Idle, Recover, Attack, TakeDamage, Dead};

	public GameObject model;
	public float recoverTime;
	public int startingHealth;
	public float readyPercent;
	public GameObject characterPartyObject;

	private Animator anim;
	private int health;
	private float recoverTimeLeft;
	private EnemyState state;
	private CharacterParty characterParty;
	private GameObject target;

	void Awake () {
		anim = model.GetComponentInChildren<Animator>();
		health = startingHealth;
		SetState(EnemyState.Recover);
		characterParty = characterPartyObject.GetComponent<CharacterParty>();
	}
	
	void Update () {
		if (state == EnemyState.Idle) {
			target = characterParty.GetTarget();
		}
		if (state == EnemyState.Recover) {
			recoverTimeLeft -= Time.deltaTime;
			readyPercent = 1 - (recoverTimeLeft / recoverTime);
			if (recoverTimeLeft <= 0) {
				SetState(EnemyState.Idle);
			}
		}
	}

	void SetState(EnemyState newState) {
		switch (newState) {
			case EnemyState.Recover:
				recoverTimeLeft = recoverTime;
				break;
		}
	}
}
