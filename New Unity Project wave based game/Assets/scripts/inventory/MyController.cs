using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyController : MonoBehaviour
{
	public Inventory inventory;
	public Canvas inventoryCanvas;

    // Start is called before the first frame update
    void Start()
    {
		inventory = new Inventory();
		inventoryCanvas.gameObject.SetActive(false);
		inventoryCanvas.gameObject.transform.Find("FullMessage").gameObject.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.P))
		{
			showInventory();
		}
		if(Input.GetKeyUp(KeyCode.P))
		{
			hideInventory();
		}

		if (Input.GetKeyUp(KeyCode.L))
		{
			inventoryCanvas.gameObject.transform.Find("FullMessage").gameObject.SetActive(false);
			dropFirstItem();
		}

		if (Input.GetKeyUp(KeyCode.M))
		{
			inventoryCanvas.gameObject.transform.Find("FullMessage").gameObject.SetActive(false);
			dropAllItemsAndRandomiseLocation();
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<InventoryItem>() != null)
		{
			if (inventory.addItem(other.gameObject)) other.gameObject.SetActive(false);
			else DisplayInventoryFullMessage();
		}
	}


	private void DisplayInventoryFullMessage()
	{
		showInventory();
		inventoryCanvas.gameObject.transform.Find("FullMessage").gameObject.SetActive(true);
		if(!IsInvoking("hideInventory"))	Invoke("hideInventory", 1f);
	}

	private void showInventory()
	{
		inventoryCanvas.gameObject.SetActive(true);
		Sprite[] sprites = inventory.getAllInventorySprites();

		Image[] images = inventoryCanvas.GetComponentsInChildren<Image>();

		makeAllImagesEmpty(images);

		for (int i = 0;  i < sprites.Length; i++)
		{
			images[i].sprite = sprites[i];
		}
	}

	private void hideInventory()
	{
		inventoryCanvas.gameObject.SetActive(false);
	}

	private void makeAllImagesEmpty(Image[] images)
	{
		for (int i = 0; i < images.Length; i++)
		{
			images[i].sprite = null;
		}
	}

	private void dropFirstItem()
	{
		GameObject item = inventory.removeItem(0);
		if (item != null)
		{
			item.transform.position = new Vector3(this.transform.position.x, item.transform.position.y, this.transform.position.z) + (this.transform.forward * 2);
			item.SetActive(true);
		}

	}

	private void dropAllItemsAndRandomiseLocation()
	{
		InventoryItem[] items = inventory.removeAllItems();
		foreach (InventoryItem item in items)
		{
			Vector2 pos = Random.insideUnitCircle*25  ;
			item.transform.position = new Vector3(pos.x, item.transform.position.y, pos.y);
			item.gameObject.SetActive(true);
		}
	}
}
