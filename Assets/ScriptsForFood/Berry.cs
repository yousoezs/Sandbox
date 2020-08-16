using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Berry : MonoBehaviour
{
    public static bool triggeringWithBerry;
    public static GameObject triggeringBerry;

    public bool berries;

    private PlayerController Player;
    private GameObject Blueberry;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        Blueberry = GameObject.Find("/Bush/BlueBerry");
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
        if (target.tag == "Berry")
        {
            PlayerController player = target.GetComponent<PlayerController>();
            if(player == Input.GetKeyDown(KeyCode.F))
            if(player.Health < 100)
            {
                player.Health += 10;
                player.Hunger += 10;
                print("You refilled your hunger!");
                Destroy(Blueberry);
            }
            else
            {
                if(player.Health >= 100)
                {
                    print("You have full stats!");
                }
            }
        }
    }

    public void OnCollisionEnter(Collision berries)
    {
        if(Player)
        {
            

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
        if(other.tag == "Player")
        {
            triggeringBerry = null;
            triggeringWithBerry = false;
        }
    }
}
