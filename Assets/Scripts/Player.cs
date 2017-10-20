using UnityEngine;
using System.Collections;
using System;

public class Player : Entity {
	public bool female;

	public bool paused;

	public Stat magic;

	public Stat strength;
	public Stat intelligence;
	public Stat stamina;
	public Stat speed;
	public Stat luck;

	public delegate void Occupation ();
	public Occupation occupation;

	public Vector3 velocity;

	public bool clickMovement = false;
	public bool constantFollow = false;

	[HideInInspector]
	public TinkerAnimator animator;

	private Vector3 target;

	public Vector3 GetClickedLocation(){		
		RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction);
		if (hit.collider != null) {
			return hit.point;
		}
		return transform.position;
	}


	Vector3 prevVelocity;
	private void _Normal(){
		GetComponent<BoxCollider2D> ().isTrigger = false;
		if (clickMovement) {
			if (Input.GetMouseButtonDown (0) && !constantFollow) {
				target = GetClickedLocation ();
			} else if (Input.GetMouseButton(0) && constantFollow){
				target = GetClickedLocation ();
			}
		} else {
			target = new Vector3 (transform.position.x + Input.GetAxisRaw("Horizontal"), transform.position.y + Input.GetAxisRaw("Vertical"), 0);
		}
		float dist = (target - transform.position).magnitude;
		if (dist > Time.deltaTime) {
			velocity = (target - transform.position).normalized * speed.total * Time.deltaTime;
		} else {
			velocity = Vector3.zero;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			occupation = _Dash;
			prevVelocity = velocity;
		}
	}

	float _dt = 0.6f;

	private void _Dash(){
		GetComponent<BoxCollider2D> ().isTrigger = true;
		velocity = prevVelocity * 2;
		_dt -= Time.deltaTime;
		if (_dt <= 0) {
			occupation = _Normal;
			_dt = 0.6f;
		}
	}

	public void Start(){
		target = transform.position;
		animator = GetComponent<TinkerAnimator> ();
		occupation = _Normal;
	}

	public void FixedUpdate(){
		if (!paused) {
			// velocity is equal to the change in position over each frame
			// animator.SetFloat ("velocity", velocity.normalized.magnitude);
			if (velocity.magnitude > .02f) {
				animator.currentAnimation = 1;
			} else {
				animator.currentAnimation = 0;
			}
			occupation ();
			transform.Translate (velocity);
		}

	}

	public override void Update(){
		

		base.Update ();
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}
	}
}