﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class SvampGolem : MonoBehaviour
{
    NavMeshAgent agent;
    private Rigidbody Player;

    public float radius;
    public float timer;
    private float currentTime;
    public float currentIdleTimer;
    public float idleTimer;
    public float distance;

    private Transform target;

    public bool idle;

    private float gravity = 28.81f;
    public float golemHealth = 1000f;
    public float golemMaxHealth;

    private float golemDamage = 40;
    private int hitCount = 100;
    private float hitTime = 2;
    float curTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Rigidbody>();

        Physics.gravity = new Vector3(0, -gravity, 0);

        golemHealth = golemMaxHealth;
    }

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTime = timer;
        currentIdleTimer = idleTimer;
    }



    // Update is called once per frame
    void Update()
    {
        TargetSvamp();
        Timer();

        if (curTime >= hitTime)
        {
            DamageSvamp();
        }

        currentTime += Time.deltaTime;
        currentIdleTimer += Time.deltaTime;

        if (currentIdleTimer >= idleTimer)
        {
            StartCoroutine("switchIdle");
        }
    }
    private void Timer()
    {
        if (hitCount > 0) // if there are several hits left
        {
            curTime += Time.deltaTime; // adds time
        }
    }

    IEnumerator switchIdle()
    {
        idle = true;
        yield return new WaitForSeconds(3);
        currentIdleTimer = 0;
        idle = false;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layerMask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layerMask);

        return navHit.position;

    }
    private void TargetSvamp()
    {
        float closeEnough = Vector3.Distance(Player.transform.position, transform.position);
        bool playerIsClose = closeEnough <= 15;

        if (Player.GetComponent<PlayerController>().Health > 0 && playerIsClose)
        {
            agent.enabled = true;
            GetComponent<NavMeshAgent>().destination = Player.position;
        }
        else
        {
            if (currentTime >= timer && !idle)
            {
                Vector3 NewPosition = RandomNavSphere(transform.position, radius, -1);
                agent.SetDestination(NewPosition);
                currentTime = 0;
            }
        }
    }
    private void DamageSvamp()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.tag == "Player" && hit.distance <= 3)
            {
                hit.collider.gameObject.GetComponent<PlayerController>().Health -= golemDamage;
                curTime = 0;
                hitCount--;
            }
        }
    }
}
