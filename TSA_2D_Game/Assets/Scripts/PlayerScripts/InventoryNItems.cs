using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryNItems : MonoBehaviour {
	public Inventory playerInv;

	public string itemTracker;
	public int itemNumTracker;
	public int sizeTracker;

	// Use this for initialization
	void Awake () {
		playerInv = new Inventory ();
	}
	
	// Update is called once per frame
	void Update () {
		itemTracker = playerInv.nameAt(0);
		itemNumTracker = playerInv.numAt (0);
		sizeTracker = playerInv.GetCount();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Key") {
			//other.GetComponent<OpenDoor> ().OpenDoors();
			int keyNumber = int.Parse (other.name.Substring(4,1));
			Item key = new Item ("LockedDoor " + keyNumber + " Key", keyNumber);
			if (playerInv.hasItem (key)) {
				other.gameObject.SetActive (false);

			} else {
				playerInv.AddItem(key);
				other.gameObject.SetActive (false);
			}

		} 
	}
}

public class Inventory
{
	private List<Item>ItemList;

	public Inventory(){
		ItemList = new List<Item> (0);
	}

	public Inventory(Item firstItem){
		ItemList.Add (firstItem);
	}

	public void AddItem(Item newItem){
		ItemList.Add (newItem);
	}

	public string nameAt(int index){
		if (ItemList.Count == 0 || index >= ItemList.Capacity) {
			return " ";
		}
		return ItemList [index].itemName;
	}
	public int numAt(int index){
		if (ItemList.Count == 0 || index >= ItemList.Capacity) {
			return 0;
		}
		return ItemList [index].itemNum;
	}
	public bool hasItem (Item searchItem){
		bool returnValue = false;
		if (ItemList.Count == 0) {
			return returnValue;
		}
		foreach (Item i in ItemList) {
			if (i.Equals (searchItem)) {
				returnValue = true;
				break;
			}
		}
		return returnValue;
	}

	public bool removeItem(Item remove){
		bool returnValue = false;
		if (ItemList.Count == 0) {
			return returnValue;
		}
		foreach (Item i in ItemList) {
			if (i.Equals (remove)) {
				ItemList.Remove (i);
				returnValue = true;
				break;
			}
		}
		return returnValue;
	}
	public int GetCount(){
		return ItemList.Count;
	}
}

public class Item{
	public Item(string name, int number){
		itemName = name;
		itemNum = number;
	}
	public bool Equals(Item b){
		if (b == null) {
			return false;
		}

		return (itemNum == b.itemNum && itemName == b.itemName);

	}
	public string itemName;

	public int itemNum;

}
