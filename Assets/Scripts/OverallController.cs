using UnityEngine;
using System.Collections;

public class OverallController : MonoBehaviour {

	public enum NextClick { SELECT, TARGET };
	public enum SelectionState { NONE, CHARACTER, ENEMY };

	private NextClick nextClick;
	private SelectionState state;
	private GameObject selectedObject;

	void Awake () {
		Reset();
	}

	public void Reset () {
		nextClick = NextClick.SELECT;
		state = SelectionState.NONE;
	}

	public void Select (GameObject selectObject) {
		if (selectObject.CompareTag("Character")) {
			nextClick = NextClick.TARGET;
			state = SelectionState.CHARACTER;
			selectedObject = selectObject;
		} else if (selectObject.CompareTag("Enemy")) {
			state = SelectionState.ENEMY;
			selectedObject = selectObject;
		}
	}

	public void SetTarget (GameObject newTarget) {
		if (state == SelectionState.CHARACTER) {
			selectedObject.GetComponent<CharacterController>().SetTarget(newTarget);
		}
	}

	public NextClick GetNextClick() {
		return nextClick;
	}

	public SelectionState GetSelectionState() {
		return state;
	}
}
