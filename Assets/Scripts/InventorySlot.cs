using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour {
	public Sprite icon;
	public bool doesStack;
	int stackCount;

	private Image imageBox;

	void Start(){
		imageBox = GetComponent<Image> ();
	}

	void Update(){
		
	}
}
