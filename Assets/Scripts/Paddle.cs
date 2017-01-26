using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	static public int life = 3;
	
	public bool autoPlay = false;
	public float minX;
	public float maxX;
	
	private Ball ball;
	
	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) { MoveWithMouse(); }
		else {
			AutoPlay();
		}
	}
	
	void AutoPlay() {
		Vector3 paddlePos = this.transform.position;
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
	
	
	void MoveWithMouse () {
		Vector3 paddlePos = this.transform.position;
		float mousePosInBlocks = Input.mousePosition.x/Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
}
