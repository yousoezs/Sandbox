using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBerry : MonoBehaviour
{
    public bool triggeringWithRedBerry;
    public GameObject triggeringRedBerry;

    private PlayerController Player;
    private GameObject Berry;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        Berry = GameObject.Find("/Bush/Berry");
    }

    // Update is called once per frame
    void Update()
    {
        if(triggeringWithRedBerry)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Eat(triggeringRedBerry);
            }
        }
    }
    public void Eat(GameObject target)
    {
            if (Player.Hunger < 150 && target.tag == "Player")
            {
                Player.Health += 10;
                Player.Hunger += 10;
                print("You have refilled your stats!");
                Destroy(Berry);
            }
            else
            {
                if (Player.Hunger >= 150)
                {
                    print("You have full stats!");
                }
            }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggeringRedBerry = other.gameObject;
            triggeringWithRedBerry = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            triggeringRedBerry = null;
            triggeringWithRedBerry = false;
        }
    }
}
