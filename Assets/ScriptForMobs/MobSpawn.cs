using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MobController
{
    public bool Dead;
    public float deadTimer;

    public GameObject MobBody;
    public GameObject randomMob;
    
    // Start is called before the first frame update
    void Start()
    {
        randomMob = (GameObject)Instantiate(MobBody, this.transform.position, Quaternion.identity);
        randomMob.name = "RandomMob";
    }

    // Update is called once per frame
    void Update()
    {
        deadTimer += Time.deltaTime;

        if (randomMob.gameObject.GetComponent<MobController>().enemyHealth <= 0)
        {
            StartCoroutine("Respawn");
        }
    }
    IEnumerator Respawn()
    {

        {
            Destroy(randomMob);
            Dead = true;
            print("You gained 20 Experience!");
            yield return new WaitForSeconds(10);
            deadTimer = 10;
            Dead = false;
            randomMob.gameObject.transform.position = this.transform.position;

        }
    }
}
