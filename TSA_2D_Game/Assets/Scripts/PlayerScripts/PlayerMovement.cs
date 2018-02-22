using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	Rigidbody2D rb;
	public float moveSpeed = 7.0f;
	public float jumpSpeed = 10f;
	public float jumpForce = 2.0f;
	public float slideSpeed = -3.0f;
	public float rbVelocity = 0;
	public bool isJumping = false;
	public bool grounded = false;
	public bool canMoveLeft = true;
	public bool canMoveRight = true;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	public bool canDoubleJump = true;
	public bool hasDoubleJump = true;
	public Inventory playerInv;



	public string itemTracker;
	public int itemNumTracker;
	public int sizeTracker;


	// Use this for initialization
	void Awake () {
		playerInv = new Inventory ();
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		rbVelocity = rb.velocity.y;
		if (rb.velocity.y > 5) {
			isJumping = true;
		} else {
			isJumping = false;
		}
		itemTracker = playerInv.nameAt(0);
		itemNumTracker = playerInv.numAt (0);
		sizeTracker = playerInv.GetCount();
		//grounded = Physics2D.OverlapArea (new Vector2 (	), new Vector2 (), whatIsGround);
		movePlayer ();
	}

	void movePlayer()
	{
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Jump");
		if (grounded) {
			if (y > 0) {
				rb.velocity = new Vector2 (rb.velocity.x, y * jumpSpeed);
		
			}
		} else if (canDoubleJump && !isJumping && hasDoubleJump) {
			if (y > 0) {
				rb.velocity = new Vector2 (rb.velocity.x, y * jumpSpeed);
				canDoubleJump = false;

			}
		}
		if (x < 0 && canMoveLeft)
			rb.velocity = new Vector2 (x * moveSpeed, rb.velocity.y);
		else if(x > 0 && canMoveRight)
			rb.velocity = new Vector2 (x * moveSpeed, rb.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Ground") {
			grounded = true;
		}
		if (other.tag == "Platform") {
			if (rb.velocity.y > 0) {
				other.gameObject.GetComponent<ValuesForDisablePlat>().parent.GetComponent<BoxCollider2D>().enabled = false;
			} else {
				other.gameObject.GetComponent<ValuesForDisablePlat>().parent.GetComponent<BoxCollider2D>().enabled = true;
			}
		}

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

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Ground" || other.tag == "Platform" ) {
			grounded = false;
			canDoubleJump = true;
		}
		else if (other.tag == "Wall") {
			if (rb.position.x > other.GetComponent<Transform> ().position.x) {
				canMoveLeft = true;
			}
			else if (rb.position.x < other.GetComponent<Transform> ().position.x) {
				canMoveRight = true;
			}
		}

			
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Wall") {
			if (rb.position.x > other.GetComponentInParent<Transform> ().position.x) {
				canMoveLeft = false;
			}
			else if (rb.position.x < other.GetComponentInParent<Transform> ().position.x) {
				canMoveRight = false;
			}
		}
		if (other.tag == "Ground" ||  other.tag == "Platform") {
			
			grounded = true;
			canDoubleJump = true;

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
