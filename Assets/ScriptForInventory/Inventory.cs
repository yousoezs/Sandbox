using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject SlotHolder;
    public bool inventoryEnabled;

    private GameObject itemPickedUp;
    private bool itemAdded;

    private int slots;
    private Transform[] Slot;

    public void Start()
    {
        // slots being detected
        inventory = GameObject.Find("InventoryCanvas");
        SlotHolder = GameObject.Find("/InventoryCanvas/Slot Holder");
        slots = SlotHolder.transform.childCount;
        Slot = new Transform[slots];
        DetectInventorySlots();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
            inventory.SetActive(true);
        else
            inventory.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "item")
        {
            print("Item picked up!");
            itemPickedUp = other.gameObject;
            AddItem(itemPickedUp);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "item")
        {
            itemAdded = false;
        }
    }

    public void AddItem(GameObject item)
    {
        for(int i = 0; i < slots; i++)
        {
            if(Slot[i].GetComponent<Slot>().emptySlot && itemAdded == false)
            {
                Slot[i].GetComponent<Slot>().item = itemPickedUp;
                Slot[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().Icon;
                itemAdded = true;
            }
        }
    }

    public void DetectInventorySlots()
    {
        for (int i = 0; i < slots; i++)
        {
            Slot[i] = SlotHolder.transform.GetChild(i);
        }
    }
}
