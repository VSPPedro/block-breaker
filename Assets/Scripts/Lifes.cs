using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lifes : MonoBehaviour {
	
	public GameObject[] image;
	
	// Use this for initialization
	void Start () {
		for (int x = 1; x >= Paddle.life; x--) {
			image[x+1].GetComponent<Image>().color = Color.red;
		}
	}
}
