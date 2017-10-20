using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Encyclopedia : MonoBehaviour {
	public static List<Entity> creatures = new List<Entity> ();
	public static List<bool> knownCreatures = new List<bool> ();

	public void Start(){
		Entity[] entities = Resources.LoadAll<Entity>("Prefabs/Entities");
		foreach (Entity e in entities) {
			creatures.Add (e);
			knownCreatures.Add (false);
		}

		for (int i = 0; i < creatures.Count; i++) {
			creatures [i].creatureIndex = i;
		}
	}

	// Update is called once per frame
	public static void Learn (int index) {
		knownCreatures [index] = true;
	}

	public void Update(){
		//Debug.Log ("Encyclopedia: " + creatures.Count);
	}
}
