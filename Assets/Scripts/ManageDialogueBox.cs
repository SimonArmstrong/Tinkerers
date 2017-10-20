using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManageDialogueBox : MonoBehaviour {
	void Start(){
		GameManager.dialogueBox = GetComponent<Image> ();
	}
}
