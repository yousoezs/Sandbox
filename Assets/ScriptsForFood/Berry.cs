﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    public bool triggeringWithBerry;
    public GameObject triggeringBerry;

    private PlayerController Player;
    private GameObject Blueberry;
    private GameObject Berri;

    // Start is called before the first frame update
    void Start()
    {
        Blueberry = GameObject.Find("/Bush/BlueBerry");
        Berri = GameObject.Find("/Bush/Berry");
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeringWithBerry)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Eat(triggeringBerry);
            }
        }
    }

    public void Eat(GameObject target)
    {
        {
            if (Player.Hunger < 150 && target.tag == "Player")
            {
                Player.Health += 10;
                Player.Hunger += 10;
                print("You refilled your hunger!");
                Destroy(Blueberry);
            }
            else
            {
                if (Player.Hunger >= 150)
                {
                    print("You have full stats!");
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggeringBerry = other.gameObject;
            triggeringWithBerry = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeringBerry = null;
            triggeringWithBerry = false;
        }
    }
}   
