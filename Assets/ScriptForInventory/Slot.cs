using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool hovered;
    public bool emptySlot;

    public GameObject item;
    public Texture itemIcon;

    private GameObject player;

    void Start()
    {
        hovered = false;

        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        //This will check if slot is empty and use the slot, also checks if the slot is empty or not with bool!
        if (item)
        {
            emptySlot = false;

            itemIcon = item.GetComponent<Item>().Icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        }
        else
        {
            emptySlot = true;
            itemIcon = null;
            this.GetComponent<RawImage>().texture = null;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Checks if you are hovering on slot
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerClick(PointerEventData eventDate)
    {
        if (item)
        {
            Item thisItem = item.GetComponent<Item>();

            //Checking for item type
            if (thisItem.type == "Weapon" && player.GetComponent<PlayerController>().weaponEquipped == false)
            {
                player.GetComponent<PlayerController>().CutTree(thisItem.treeDamage);
                thisItem.equipped = true;
                item.SetActive(true);
            }
        }
    }
}
