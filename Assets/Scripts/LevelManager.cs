using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	static public int loadLevel = 1;
	
	public void RepeatLevel(){
		if (Paddle.life < 0) {
			Paddle.life = 3;
			Application.LoadLevel("Start");
		} else {
			Application.LoadLevel(loadLevel);	
		}
	}
	
	public void LoadLevel(string name){
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			Application.LoadLevel(Application.loadedLevel + 1);
			if (Application.loadedLevel == 4) {
				loadLevel = 1;
                Paddle.life = 3;
			} else {
				loadLevel = Application.loadedLevel + 1;	
			}
		}
	}
}
