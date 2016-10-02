using UnityEngine;
using System.Collections;

public class ScorpionController : MonoBehaviour {

	private Animator anim;
	private bool dead;
	private int health;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		dead = false;
		health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead) {
			if (Input.GetAxis("Fire1") > 0) {
				anim.SetTrigger("Attack");
			}
			if (Input.GetAxis("Fire2") > 0) {
				print("Hurt!");
				health -= 2;
				if (health < 0) {
					dead = true;
				} else {
					anim.SetTrigger("TakeDamage");
				}
			}
			if (Input.GetAxis("Fire3") > 0) {
				dead = true;
			}
			if (dead) {
				print("Dead!");
				anim.SetTrigger("Die");
			}
		}
	}
}
