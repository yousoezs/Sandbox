using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject SlotHolder;
    public GameObject ArmLeft;
    public bool inventoryEnabled;

    private GameObject itemPickedUp;
    private bool itemAdded;

    public int slots;
    private Transform[] Slot;

    private GameObject Axe;
    private GameObject Log;
    private GameObject Stick;

    public void Start()
    {
        Axe = GameObject.Find("Axe");
        Log = GameObject.Find("Log(Clone)");
        Stick = GameObject.Find("Stick(Clone)");
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
            inventory.GetComponent<Canvas>().enabled = true;
        else
            inventory.GetComponent<Canvas>().enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
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
        //for loop to check all the slots and add item for each slot if picked up
        for (int i = 0; i < slots; i++)
        {
            //Getting script Slot and checks if emptySlot & itemAdded is false
            if (Slot[i].GetComponent<Slot>().emptySlot && itemAdded == false)
            {
                Slot[i].GetComponent<Slot>().item = itemPickedUp;
                Slot[i].GetComponent<Slot>().itemIcon = itemPickedUp.GetComponent<Item>().Icon;

                //If item is clicked, changes item position to ArmLeft
                item.transform.parent = ArmLeft.transform;
                item.transform.position = ArmLeft.transform.position;

                item.transform.localPosition = item.GetComponent<Item>().position;
                item.transform.localEulerAngles = item.GetComponent<Item>().rotation;
                item.transform.localScale = item.GetComponent<Item>().scale;

                Destroy(item.GetComponent<Rigidbody>());

                itemAdded = true;
                item.SetActive(false);

                //List<GameObject> itemGraveyard = new List<GameObject>();
                //Axe.SetActive(false);
            }
        }
    }

    public void DetectInventorySlots()
    {
        //This detects every inventoryslot trough SlotHolder!
        for (int i = 0; i < slots; i++)
        {
            Slot[i] = SlotHolder.transform.GetChild(i);
        }
    }
}
