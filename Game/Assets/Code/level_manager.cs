using UnityEngine;

public class level_manager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private character_movement player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<character_movement> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Respawn(){
		Debug.Log("Player Respawn");
		player.transform.position = currentCheckpoint.transform.position;
	}//Respawn

}
