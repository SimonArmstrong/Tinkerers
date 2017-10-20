using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {
	public Item item;
	public void Awake(){
		name = item.name;
	}
}
