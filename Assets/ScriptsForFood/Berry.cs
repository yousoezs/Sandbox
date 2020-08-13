using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    public static bool triggeringWithBerry;
    public static GameObject triggeringBerry;

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
        if(triggeringWithBerry)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Eat(triggeringBerry);
            }
        }

    }

    public void Eat(GameObject target)
    {
        if (target.tag == "Berry")
        {
            
            if (Player.Health <= 100)
            {
                Player.Health += 10;
                Player.Stamina += 10;
                print("You refilled your stats");
                Destroy(Blueberry);
            }
            else
            {
                if(Player.Health > 100)
                print("You have full stats!");
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
        if(other.tag == "Player")
        {
            triggeringBerry = null;
            triggeringWithBerry = false;
        }
    }
}
