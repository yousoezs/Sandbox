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
        if (item)
        {
            emptySlot = false;

            itemIcon = item.GetComponent<Item>().Icon;
            this.GetComponent<RawImage>().texture = itemIcon;
        }
        else
        {
            emptySlot = true;
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }

    public void OnPointerClick(PointerEventData eventDate)
    {
        if(item)
        {
            Item thisItem = item.GetComponent<Item>();

            //Checking for item type
            if (thisItem.type == "Axe")
            {
                player.GetComponent<PlayerController>().CutTree(thisItem.treeDamage);
            }
        }
    }
}
