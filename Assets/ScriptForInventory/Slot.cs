using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovered;
    public bool emptySlot;

    public GameObject item;
    public Texture itemIcon;

    void Start()
    {
        
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
}
