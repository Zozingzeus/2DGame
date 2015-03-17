using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		SpawnPlayer(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnPlayer(bool controller) {
		GameObject player1 = Instantiate(player, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		player1.SendMessage("TheStart", controller);
	}
}
