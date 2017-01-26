using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public AudioClip broke;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	private int delay = 2;
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		maxHits = hitSprites.Length + 1;
		isBreakable = (this.tag == "Breakable");
		
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit++;
		
		if (timesHit >= maxHits) {
			PuffSmoke ();
			breakableCount--;
			//Ve se esse tijolo era o ultimo, se sim o jogador vai para o proximo level
			levelManager.BrickDestroyed();
			AudioSource.PlayClipAtPoint(broke, transform.position);
			Destroy(gameObject);
		} else {
			LoadSprites();
			AudioSource.PlayClipAtPoint(crack, transform.position);	
		}
	}
	
	void PuffSmoke () {
		smoke.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
		GameObject smokeObject = Instantiate(smoke, gameObject.transform.position, smoke.transform.rotation) as GameObject;
		Destroy(smokeObject, delay);
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing!");
		}
	}
}
