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
        if (triggeringBerry)
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
            PlayerController player = target.GetComponent<PlayerController>();
            if (player.Hunger < 100)
            {
                player.Health += 10;
                player.Hunger += 10;
                print("You have filled your hunger!");
                Destroy(Blueberry);
            }

            else
            {
                if (player.Hunger >= 100)
                {
                    print("You have full hunger!");
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
        if(other.tag == "Player")
        {
            triggeringBerry = null;
            triggeringWithBerry = false;
        }
    }
}
