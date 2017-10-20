using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static Image dialogueBox;
	public static List<GameObject> loadedEntities;
	public int layerCount = 0;


	// Use this for initialization
	void Start () {
		loadedEntities = new List<GameObject> ();
		loadedEntities.AddRange(GameObject.FindGameObjectsWithTag("entity"));
	}

	void ManageLoadedEntities(){
		//GameObject[] entities = loadedEntities.AddRange (GameObject.FindGameObjectsWithTag ("entity"));
	}

	List<GameObject> ReorderedList () {
		float temp = 9999;
		List<GameObject> result = new List<GameObject>();
		for (int i = 0; i < loadedEntities.Count; i++) {
			if (loadedEntities [i].transform.position.y < temp) {
				temp = loadedEntities [i].transform.position.y;

				result.Add (loadedEntities[i]);
			}
		}
		return result;
	}

	void UpdateLayering(){
		// Get our list
		List<GameObject> reorderedList = loadedEntities;

		// Reorder the list by y positions, highest to lowest
		int temp_lhsIdx = 0;
		int temp_rhsIdx = 0;
		float[] temp_heights = new float[loadedEntities.Count];
		int[] temp_IdxOrdered = new int[loadedEntities.Count];
		//int[] temp_IdxUnordered = new int[loadedEntities.Count];

		for (int i = 0; i < loadedEntities.Count; i++) {
			temp_heights [i] = loadedEntities[i].transform.position.y;
		}

		System.Array.Sort (temp_IdxOrdered);

		// Push the reordered list
		loadedEntities = reorderedList;
	}

	// Update is called once per fram
	void Update () {
		int desiredLayer = 0;

		//loadedEntities = ReorderedList ();
		//UpdateLayering();
		/*
		for (int i = 0; i < loadedEntities.Count; i++) {
			// Am I below j?
			for (int j = 0; j < loadedEntities.Count; j++) {
				while (loadedEntities [i].transform.position.y < loadedEntities [j].transform.position.y) {
					loadedEntities [i].GetComponent<SpriteRenderer>().sortingOrder += 1;
					loadedEntities [j].GetComponent<SpriteRenderer>().sortingOrder -= 1;
				}
			}
		}
		*/
		if (GameObject.Find ("Player") != null) {
			//GameObject.Find ("Player").GetComponent<SpriteRenderer> ().sortingOrder = desiredLayer;
		}
	}
}
