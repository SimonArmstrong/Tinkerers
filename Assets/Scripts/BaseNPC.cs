using UnityEngine;
using System.Collections;

public class BaseNPC : Entity {
	public Vector3 desiredLocation;

	[HideInInspector]
	public Animator animator;

	public struct Dialogue {
		public Sprite speakerSprite;
		public string speakerName;
		public string dialogueMain;
	}


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		desiredLocation = transform.position;
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
		float dist = (desiredLocation - transform.position).magnitude;
		//if (dist >= 0.03f) {
			transform.Translate ((desiredLocation - transform.position).normalized * Time.deltaTime * dist * 10);
		//}

		animator.SetFloat ("velocity", (desiredLocation - transform.position).normalized.magnitude);
	}
}
