using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private int TreeCut = 10;
    public float treeHealth;
    public float maxTreeHealth;

    public GameObject[] dropItems;

    void Start()
    {
        treeHealth = maxTreeHealth;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (Input.GetMouseButtonDown(0))
            {
                treeHealth -= TreeCut;
                if(treeHealth <= 0)
                {
                    foreach(GameObject g in dropItems)
                    {
                        Instantiate(g, this.transform.position, Quaternion.identity);
                    }
                    print("You cut down the tree!");
                    Destroy(gameObject);
                }
                else
                {
                    print("Where is your axe?");
                }
            }
        } 
    }
}
