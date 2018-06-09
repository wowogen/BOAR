using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class terrier : MonoBehaviour
{

	public GameObject rabbit;
	public float chrono;
	public bool HideRabbit;
	private bool ispoown;
	
	public float lookRadius = 10f;
	
	
	[SerializeField] 
	private GameObject spawner;
	
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
		if (ispoown)
		{
			return;
		}
		if (HideRabbit)
		{
			chrono -= Time.deltaTime;
			if (chrono <= 0)
			{
				chrono = 0;
				ispoown = true;
				int rand = Random.Range(-1, 1);
				if (rand == 0)
				{
					spawner.GetComponent<SpownObjet>().SpawnFood();
				}
				else
				{
					spawner.GetComponent<SpownObjet>().SpawnFood2();
				}
			}
			HideRabbit = false;
		}
		detect();
	}
	
	public void detect()
	{
		float distance = Vector3.Distance(rabbit.GetComponent<Transform>().position, transform.position);

		if (distance <= lookRadius)
		{
			HideRabbit = true;
			rabbit.SetActive(false);
		}  
	}
	
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
