using UnityEngine;
using System.Collections;

public class LooseCollider : MonoBehaviour {
	
	private LevelManager levelManager;
	
	void OnTriggerEnter2D (Collider2D trigger) {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		Paddle.life--;
		levelManager.LoadLevel("Lose");
	}
	
	void OnCollisionEnter2d (Collision2D collision) {
		print ("Collision");
	}
}
