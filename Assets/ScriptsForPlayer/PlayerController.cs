using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static bool triggeringWithAI;
    public static GameObject triggeringAI;

    private float Damage = 15f;

    private GameObject Blueberry;

    public float HealthDecreaseRate = 3f;
    public float HealthIncreaseRate = 5f;
    public float StaminaDecreaseRate = 5f;
    private float StaminaIncreaseRate = 8f;
    public float HungerDecreaseRate = 0.3f;

    public float Health = 100f;
    public float Stamina = 100f;
    public float Hunger = 150f;
    public float maxHealth;
    public float maxStamina;
    public float maxHunger;
    private Image HealthImage;
    private Image StaminaImage;
    private Image HungerImage;
    private Image Inventory;

    public float Movement = 100f;
    private Rigidbody player;
    private float gravity = 30.81f;

    public float groundDistance = 0.4f;
    public float JumpHeight;
    public LayerMask Ground;
    public Transform GroundCheck;
    public bool isGrounded;

    public float waterDistance = 0.4f;
    public float Swim;
    public LayerMask Water;
    public Transform WaterCheck;
    public bool isInWater;

    public float TreeDistance = 1f;
    public float Climb;
    public LayerMask Trees;
    public Transform TreeCheck;
    public bool LiveTree;



    public float MovementSpeed { get { return this.Movement; } set { this.Movement = value; } }
    public Rigidbody RigidbodyComponent { get { return this.player; } }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        Blueberry = GameObject.Find("/Bush/BlueBerry");

        HealthImage = GameObject.Find("HealthImage").GetComponent<Image>();
        StaminaImage = GameObject.Find("StaminaImage").GetComponent<Image>();
        HungerImage = GameObject.Find("HungerImage").GetComponent<Image>();

        Health = maxHealth;
        Stamina = maxStamina;
        Hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -gravity, 0);

        Move();
        Jump();
        Swimming();
        Climbing();
        PlayerBars();
        StatsLoss();
        Inventories();

        if (triggeringWithAI)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack(triggeringAI);
            }
        }
    }

    private void Inventories()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            
        }
    }

    public void Attack(GameObject target)
    {
        if (target.tag == "Monster")
        {
            MobController mob = target.GetComponent<MobController>();

            mob.enemyHealth -= Damage;
        }
    }
    private void StatsLoss()
    {
        if (player.gameObject.transform.position.y < -1)
        {
            if (Health > 0)
                Health -= HealthDecreaseRate * Time.deltaTime;
        }
        else
        {
            if (Health < maxHealth)
                Health += HealthIncreaseRate * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Stamina > 0)
                Stamina -= StaminaDecreaseRate * Time.deltaTime;
        }
        else
        {
            if (Stamina < maxStamina)
                Stamina += StaminaIncreaseRate * Time.deltaTime;
        }
        Hunger -= HungerDecreaseRate * Time.deltaTime;
    }
    private void PlayerBars()
    {
        HealthImage.GetComponent<RectTransform>().localScale = new Vector3(Health / 650, 0.15f, 0);
        StaminaImage.GetComponent<RectTransform>().localScale = new Vector3(Stamina / 650, 0.15f, 0);
        HungerImage.GetComponent<RectTransform>().localScale = new Vector3(Hunger / 1000, 0.15f, 0);
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal"); // Left/Right
        float inputZ = Input.GetAxis("Vertical"); // Forward/Back

        if (Input.GetKey(KeyCode.LeftShift) && Stamina > 0)
        {
            Movement = 200f;
        }
        else
        {
            Movement = 100f;
        }

        float x = inputX * Movement * Time.deltaTime;
        float z = inputZ * Movement * Time.deltaTime;

        Vector3 desiredposition = transform.position + (transform.right * x + transform.forward * z);

        player.MovePosition(desiredposition);

        //if (Input.GetKey(KeyCode.W))
        //    player.velocity = new Vector3(player.velocity.x, player.velocity.y, Movement);
        //if (Input.GetKey(KeyCode.S))
        //    player.velocity = new Vector3(player.velocity.x, player.velocity.y, -Movement);
        //if (Input.GetKey(KeyCode.A))
        //    player.velocity = new Vector3(-Movement, player.velocity.y, player.velocity.z);
        //if (Input.GetKey(KeyCode.D))
        //    player.velocity = new Vector3(Movement, player.velocity.y, player.velocity.z);
    }

    public void Jump()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, Ground);
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                player.velocity = new Vector3(0, JumpHeight, 0);
        }

    }
    public void Swimming()
    {
        isInWater = Physics.CheckSphere(WaterCheck.position, waterDistance, Water);
        if (player.gameObject.transform.position.y < 0)
        {
            if (Input.GetKey(KeyCode.Space))
                player.velocity = new Vector3(0, Swim, 0);
        }
    }

    public void Climbing()
    {
        LiveTree = Physics.CheckSphere(TreeCheck.position, TreeDistance, Trees);
        if (LiveTree)
        {
            if (Input.GetKey(KeyCode.E))
            {
                player.velocity = new Vector3(0, Climb, 0);
                Stamina -= StaminaDecreaseRate * Time.deltaTime;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            triggeringAI = other.gameObject;
            triggeringWithAI = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Monster")
        {
            triggeringAI = null;
            triggeringWithAI = false;
        }
    }

    public void CutTree(int treeDamage)
    {

    }
}
