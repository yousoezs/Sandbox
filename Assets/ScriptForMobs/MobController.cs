using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MobController : MonoBehaviour
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
    public float enemyHealth = 100f;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Rigidbody>();

        Physics.gravity = new Vector3(0, gravity, 0);

        enemyHealth = maxHealth;
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
        Target();

        currentTime +=  Time.deltaTime;
        currentIdleTimer += Time.deltaTime;

        if(currentIdleTimer >= idleTimer)
        {
            StartCoroutine("switchIdle");
        }

        if(currentTime >= timer && !idle)
        {
            Vector3 NewPosition = RandomNavSphere(transform.position, radius, -1);
            agent.SetDestination(NewPosition);
            currentTime = 0;
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

    public void Target()
    {
        
    }
}
    
