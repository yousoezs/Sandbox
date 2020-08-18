using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berry : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (player.Hunger < 150)
                {
                    player.Hunger += 10;
                    player.Health += 10;
                    print("You refilled your stats");
                    Destroy(gameObject);
                }
                else
                {
                    print("You have full stats");
                }
            }
        }
    }
}
