using UnityEngine;
using System.Collections;

public class CharacterParty : MonoBehaviour {

	ArrayList targets;

	void Awake() {
		targets = new ArrayList();
		foreach (Transform trf in transform) {
			print("Child: " + trf.gameObject);
			bool validTarget = false;
			CharacterController con = GetComponentInChildren<CharacterController>();
			if (con is CharacterController) {
				validTarget = true;
			}
			if (validTarget) {
				targets.Add(con.gameObject);
			}

		}
		/*foreach (GameObject obj in GetComponentsInChildren<GameObject>()) {
			if (obj.CompareTag("Character")) {
				if (true) {	
					targets.Add(obj);
				}	
			}
		}*/
	}
	public GameObject GetTarget() {
		return (GameObject)targets[0];
	}
}
