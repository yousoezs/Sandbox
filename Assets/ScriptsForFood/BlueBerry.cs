using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBerry : MonoBehaviour
{
    private Rigidbody Player;
    private GameObject Blueberry;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Rigidbody>();
        Blueberry = GameObject.Find("/Bush/BlueBerry");
    }

    // Update is called once per frame
    void Update()
    {
        Berry();
    }

    public void Berry()
    {
        if (Player)
        {
            GetComponent<PlayerController>().Eat();
            Destroy(Blueberry);
        } 
    }
}
