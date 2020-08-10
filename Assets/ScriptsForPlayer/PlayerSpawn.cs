using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : PlayerController
{
    public GameObject playerBody;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = (GameObject)Instantiate(playerBody, this.transform.position, Quaternion.identity);
        player.name = "Player";
    }

    // Update is called once per frame < 
    void Update()
    {
        Die();
    }

    public void Die()
    {
        
        if(player.gameObject.transform.position.y < -8)
        {
            print("You have died");
            player.gameObject.transform.position = this.transform.position;
        }
        if (player.GetComponent<PlayerController>().Health <= 0f)
        {
            print("You have died");
            player.gameObject.transform.position = this.transform.position;
        }
    }
}
