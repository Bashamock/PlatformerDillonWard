using UnityEngine;

public class player_death : MonoBehaviour {

	public level_manager levelManager;

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			levelManager.Respawn();
		}//if player
	}//Trigger
}
