using UnityEngine;
using System.Collections;
using InControl;

public class PlayerController : MonoBehaviour {

	public Vector2 moving = new Vector2();
	public bool jumping = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var inputDevice = InputManager.ActiveDevice;
		moving.x = moving.y = 0;

		if (inputDevice.LeftStickX > 0) {
			moving.x = 1;
		} else if (inputDevice.LeftStickX < 0) {
			moving.x = -1;
		}

		if (inputDevice.LeftStickY > 0) {
			moving.y = 1;
		} else if (inputDevice.LeftStickY < 0) {
			moving.y = -1;
		}

		if(inputDevice.Action1) {
			jumping = true;
		} else {
			jumping = false;
		}

	}
}
