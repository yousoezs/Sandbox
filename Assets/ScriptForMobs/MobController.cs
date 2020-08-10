using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobController : MonoBehaviour
{
    private Rigidbody randomMobs;
    public NavMeshAgent agent;

    public float mobMovement = 120f;
    private float gravity = 30.81f;

    public float Health = 100f;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        randomMobs = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, gravity, 0);
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MobMove();
    }
    public void MobMove()
    {
        if (randomMobs.gameObject.transform.position.y == 8.72)
            {

            agent.transform.position = new Vector3(-10, 0, 10);
            }
    }



}
