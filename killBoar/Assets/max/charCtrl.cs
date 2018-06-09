using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charCtrl : MonoBehaviour {
    //public Inventory myInventory;
    public AudioSource audioSource;

    Animation animate;
    new Rigidbody rigidbody;
    private Vector3 JumpSpeed;
    private float walkSpeed = 10;
    private float runSpeed = 30;
    private float turnLspeed = -100;
    private float turnRspeed = 100;
    public bool onCollision = true;

    private bool isdead;

    public float life = 100;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("inventory_DATA"))
        {
            //myInventory = JsonUtility.FromJson<Inventory>(PlayerPrefs.GetString("inventory_DATA"));
            //myInventory.bow = JsonUtility.FromJson<Bow>(PlayerPrefs.GetString("inventory_DATA_bow"));
            //myInventory.spear = JsonUtility.FromJson<Spear>(PlayerPrefs.GetString("inventory_DATA_spear"));
            //myInventory.torch = JsonUtility.FromJson<Torch>(PlayerPrefs.GetString("inventory_DATA_torch"));
        }
            
        else
            //myInventory = new Inventory();
        //myInventory = new Inventory();
        animate = GetComponent<Animation>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.detectCollisions = true;
    }

    void Update()
    {
        if (isdead)
        {
            return;
        }
        
        if (life <= 0)
        {
            animate.Play("death");
            isdead = true;
            return;
        }
        //saveInventory(myInventory);
        if (Input.GetKey(KeyCode.F5) && life> 0)
        {            
            life -= 1;
        }
        if (Input.GetKey(KeyCode.F8))
        {
            //myInventory = new Inventory();
        }
        if (Input.GetKey(KeyCode.F9))
        {
            //myInventory.spear.number += 1;
        }
        if (Input.GetKey(KeyCode.F10))
        {
            //myInventory.bow.number += 1;
        }
        if (Input.GetKey(KeyCode.F11))
        {
            //myInventory.torch.number += 1;
        }
        if (Input.GetKey(KeyCode.F12))
        {
            //myInventory.woods += 1;
            //myInventory.rocks += 1;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animate.Play("punch");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, turnLspeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnRspeed * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onCollision)
            {
                animate.Play("jump");
                Vector3 v = gameObject.GetComponent<Rigidbody>().velocity;
                v.y = JumpSpeed.y;
                gameObject.GetComponent<Rigidbody>().velocity = JumpSpeed;
            }
        }

        if (Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (!animate.IsPlaying("jump") && onCollision)
            {
                animate.Play("walk");
            }
                
            JumpSpeed = new Vector3(0, 30, 0);
            transform.Translate(0, 0, walkSpeed * Time.deltaTime);
        }

        else
        {
            if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
            {
                JumpSpeed = new Vector3(0, 35, 0);
                if (!animate.IsPlaying("jump") && onCollision)
                    animate.Play("run");
                transform.Translate(0, 0, runSpeed * Time.deltaTime);
            }
            else
            {
                JumpSpeed = new Vector3(0, 20, 0);
                if (!animate.IsPlaying("jump") && onCollision && !animate.IsPlaying("punch"))
                    animate.Play("idle");
            }
        }
    }

    public void dammege(int degat)
    {
        life -= degat;
    }

    public void OnCollisionEnter(Collision collision)
    {
        onCollision = true;
    }


    public void OnCollisionExit(Collision collision)
    {
        onCollision = false;
    }

    public void addWood(int woods)
    {
        //myInventory.woods += woods;
    }

    public void addRocks(int rocks)
    {
        //myInventory.rocks += rocks;
    }

    public bool isplayingAnimation(string animation)
    {
        return animate.IsPlaying(animation);
    }

    public float timeAnimation(string animation)
    {
        return animate[animation].time;
    }

    //public void saveInventory(Inventory inventory)
    //{
        //PlayerPrefs.SetString("inventory_DATA", JsonUtility.ToJson(myInventory));
        //PlayerPrefs.SetString("inventory_DATA_spear", JsonUtility.ToJson(myInventory.spear));
        //PlayerPrefs.SetString("inventory_DATA_torch", JsonUtility.ToJson(myInventory.torch));
        //PlayerPrefs.SetString("inventory_DATA_bow", JsonUtility.ToJson(myInventory.bow));
    //}
}
