using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MobController
{
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
        if (randomMob.gameObject.GetComponent<MobController>().enemyHealth <= 0)
        {
            Destroy(randomMob);
            print("You gained 20 Experience!");
        }
    }

    IEnumerator MobRespawn()
    {
        yield return new WaitForSeconds(10);
        randomMob.gameObject.transform.position = this.transform.position;
    }
}
