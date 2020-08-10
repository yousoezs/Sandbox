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

    }
}
