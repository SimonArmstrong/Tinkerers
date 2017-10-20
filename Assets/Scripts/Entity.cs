using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Entity : TinkerObject {
	public int creatureIndex;
	public List<SpriteRenderer> otherEntitySprites = new List<SpriteRenderer>();
	[System.Serializable]
	public struct Stat{
		public float cur, max, mod, total;

		public void Modify(float amt){
			this.mod = amt;
			max = total * mod;
		}
	}
	public Stat health;
	public List<Item> drops = new List<Item>();

	private GameObject textBoxObject;
	private DamageComponent damager;

	// Flagged when we have deducted damage
	bool flagStop = false; 
	float t = 0;
	public virtual void Damage(float amt = (1.0F), bool tickOnce = (false)){

		Vector3 screenSpacePosition = Camera.main.WorldToScreenPoint (transform.position);

		if (tickOnce) {
			health.cur -= amt;
			GameObject dmgInfoInst = Instantiate (textBoxObject, screenSpacePosition, Quaternion.identity) as GameObject;
			dmgInfoInst.transform.SetParent(GameObject.Find("Canvas").transform);
			dmgInfoInst.GetComponent<DamageInformation> ().damage = amt;

			//flagStop = true;
		}

		if (!tickOnce) {
			/*
			t -= Time.deltaTime;
			if (t <= 0) { 
				health.cur -= amt;
				t = damager.dmgDelay;
				Debug.Log (t);
			}
			*/
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject != gameObject) {
			if (other.GetComponent<DamageComponent> () != null) {
				float dmg = other.GetComponent<DamageComponent> ().dmg;
				Damage (dmg, true);
			}
		}
	}

	public void Die(){
		if (creatureIndex != -1) {
			Encyclopedia.Learn (creatureIndex);
		}
		// Remove references here
		Destroy (gameObject);
	}

	void Awake(){
		for (int i = 0; i < GameObject.FindGameObjectsWithTag ("entity").Length; i++) {
			otherEntitySprites.Add (GameObject.FindGameObjectsWithTag ("entity")[i].GetComponent<SpriteRenderer> ());
		}
	}

	public void Start(){
		textBoxObject = Resources.Load<GameObject> ("Prefabs/UI/DamageInformation");
	}

	public virtual void Update(){
		GetComponent<SpriteRenderer> ().sortingOrder = -(int)(transform.position.y * 10) * heightLayer;

		for (int j = 0; j < otherEntitySprites.Count; j++) {
			// 
			/*
			if(otherEntitySprites[j].gameObject.transform.position.y > gameObject.transform.position.y){
				GetComponent<SpriteRenderer>().sortingOrder = otherEntitySprites [j].sortingOrder + 1;
				otherEntitySprites [j].sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
			}
			*/
		}


		if (health.cur <= 0) {
			Die ();
		}
	}
}
