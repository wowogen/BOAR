using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaise : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    public bool isdetect;
    public bool isinrange;
    private bool fini;
    private life vie;
    charCtrl maxvie;

    Animation animate;
    
    void Start()
    {
        maxvie = PlayerManager.instance.player.GetComponent<charCtrl>();
        vie = GetComponent<life>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animate = GetComponent<Animation>();

    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            isdetect = true;
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                isinrange = true;
                FaceTarget();
            }
            else
            {
                isinrange = false;
            }
        }
        else
        {
            isdetect = false;
        }

        if (fini)
        {
            return;
        }
        if (vie.isdead)
        {
            animate.Play("death");
            fini = true;
            return;
        }
        if (!isdetect && !isinrange || maxvie.life <= 0)
        {
            animate.Play("idle1");
        }        
        else if (isdetect && !isinrange)
        {
            animate.Play("run");
        }
        else if(isdetect && isinrange)
        {
            animate.Play("attack1");
        }
        
        
        
    }

    void FaceTarget()
    {
        if (!vie.isdead)
        {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime*5f);            
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
