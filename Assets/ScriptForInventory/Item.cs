using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Texture Icon;
    private GameObject Player;

    public string type;
    public int treeDamage;

    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public bool pickedUp;
    public bool equipped;
    public bool weaponInUse;

    public void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void Update()
    {
        if (equipped)
            Player.GetComponent<PlayerController>().weaponEquipped = true;
        else
            Player.GetComponent<PlayerController>().weaponEquipped = false;

        if (equipped = weaponInUse)
        {
            if (Input.GetKeyDown(KeyCode.F))
                Unequip();
        }

    }
    public void Unequip()
    {
        equipped = false;
        this.gameObject.SetActive(false);
    }
}
