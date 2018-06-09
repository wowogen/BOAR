using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaiseRabbit : MonoBehaviour {


    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    private bool dontrepeat;

    public bool isdetect;
    public bool isinrange;
    private bool fini;
    private life vie;
    charCtrl maxvie;
    private bool isdead;

    Animation animate;
    
    [SerializeField] 
    private GameObject terrier;
    
    void Start()
    {
        isdead = GetComponent<lifeRabbit>().isdead;
        maxvie = PlayerManager.instance.player.GetComponent<charCtrl>();
        vie = GetComponent<life>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animate = GetComponent<Animation>();

    }

    void Update()
    {
        detect();
        if (!isdetect && !isdead)
        {
            animate.Play("idle1");
        }

        if (isdetect && !isdead)
        {
            animate.Play("run");
        }

        if (isdead && dontrepeat)
        {
            return;
        }
        if (isdead && !dontrepeat)
        {
            animate.Play("death");
            dontrepeat = true;
        }
    }

    private void detect()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            isdetect = true;
            agent.SetDestination(terrier.GetComponent<Transform>().position);

            if (distance <= agent.stoppingDistance)
            {
                isinrange = true;
            }
            else
            {
                isinrange = false;
            }
        }     
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
