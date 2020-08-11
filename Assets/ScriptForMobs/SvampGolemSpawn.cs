using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvampGolemSpawn : SvampGolem
{
    public GameObject golemBody;
    public GameObject Golem;
        
    // Start is called before the first frame update
    void Start()
    {
        Golem = (GameObject)Instantiate(golemBody, this.transform.position, Quaternion.identity);
        Golem.name = "Svamp Golem";
    }

    // Update is called once per frame
    void Update()
    {
        if (Golem.gameObject.GetComponent<SvampGolem>().golemHealth == 0)
        {
            print("You have killed the golem! But watchout, he can respawn!");
        }
    }

    IEnumerator GolemRespawn()
    {
            yield return new WaitForSeconds(10);
            Golem.gameObject.transform.position = this.transform.position;
    }
}
