using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConvoyerBelt : MonoBehaviour {
	public Vector3 direction;
	public float speed;

	public List<GameObject> affectedObjects = new List<GameObject>();

	void OnTriggerEnter(Collider other){
		if (other.gameObject.GetComponent<Entity> () != null) {
			affectedObjects.Add (other.gameObject);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.GetComponent<Entity> () != null) {
			affectedObjects.Remove (other.gameObject);
		}
	}
}
