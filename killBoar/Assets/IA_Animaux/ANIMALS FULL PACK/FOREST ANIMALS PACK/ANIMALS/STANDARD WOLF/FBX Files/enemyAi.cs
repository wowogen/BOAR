using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemyAi : MonoBehaviour {

    Animation animate = new Animation();

    public float Distance;
    public float distanceAttack;


    public Transform Target;
    public UnityEngine.AI.NavMeshAgent agent;
    Vector3 TargetPos = new Vector3();
    Vector3 thisPos = new Vector3();
	// Use this for initialization
	void Start () {
        animate = GetComponent<Animation>();
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        TargetPos = Target.position;
        thisPos = gameObject.transform.position;
        double distancePlayer = Math.Sqrt((TargetPos.x - thisPos.x)* (TargetPos.x - thisPos.x) + (TargetPos.y - thisPos.y)* (TargetPos.y - thisPos.y) + (TargetPos.z - thisPos.z)* (TargetPos.z - thisPos.z));
        //double distancePlayer = Math.Sqrt((Target.position.x - rb.position.x) * (Target.position.x - rb.position.x) + (Target.position.y - rb.position.y) * (Target.position.y - rb.position.y) + (Target.position.z - rb.position.z) * (Target.position.z - rb.position.z));
        if (distancePlayer < Distance && distancePlayer > distanceAttack)
        {
            animate.Play("walk");
            agent.destination = Target.position;
        }
        else
        {
            if (distancePlayer < distanceAttack)
            {
                animate.Play("standBite");
            }
            else
            {
                animate.Play("idleLookAround");
            }
        }
        
    }

}
