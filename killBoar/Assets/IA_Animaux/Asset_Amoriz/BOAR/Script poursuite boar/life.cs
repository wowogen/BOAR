﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{

	public int Pdv = 100;
	Animation animete;

	public float chrono;
	public float chrono2;
	private float tmp;
	private bool spawn = true;
	private Rigidbody freez;
	public bool isdead = false;
	private GameObject thisboar;

	FoodSysteme food;

	[SerializeField] 
	private GameObject spawner;
	
	// Use this for initialization
	void Start ()
	{
		tmp = chrono2;
		animete = GetComponent<Animation>();
		freez = GetComponent<Rigidbody>();
		thisboar = GetComponent<GameObject>();
		food = PlayerManager.instance.player.GetComponent<FoodSysteme>();

	}
	
	// Update is called once per frame
	void Update () {
		if (isdead)
		{
			chrono -= Time.deltaTime;
			if (chrono<=0 && spawn)
			{
				spawn = false;
				chrono = 0;
				int rand = Random.Range(-1, 1);
				if (rand == 0)
				{
					spawner.GetComponent<SpownObjet>().SpawnFood();
				}
				else
				{
					spawner.GetComponent<SpownObjet>().SpawnFood2();
				}
				this.gameObject.SetActive(false);
			}
			return;
		}
		if (Pdv <= 0 && spawn)
		{
			freez.constraints = RigidbodyConstraints.FreezeAll;
			isdead = true;
			food.addFood(1);
		}
	}

	private void OnCollisionStay(Collision other)
	{
		/*string oui = "false";
		if (Pdv > 0)
		{
			oui = "true";
		}
		string non = "false";
		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			non = "true";
		}
		string bof = "non";
		if (other.gameObject.GetComponent<Animation>().IsPlaying("punch"))
		{
			bof = "punch";
		}
		Debug.Log("Is touching " + other.gameObject.tag + " et " + oui + " et " + non);*/


		if (Pdv >0 && other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.Mouse0) && other.gameObject.GetComponent<Animation>().IsPlaying("punch"))
		{
			dammage(Random.Range(28,33));
		}

		
		if (Pdv >0 && other.gameObject.tag == "Player" && other.gameObject.GetComponent<charCtrl>().life > 0)
		{
			chrono2 -= Time.deltaTime;
			if (chrono2 <= 0)
			{
				animete.Play("attack1");
				other.gameObject.GetComponent<Transform>().position = new Vector3(other.gameObject.GetComponent<Transform>().position.x,other.gameObject.GetComponent<Transform>().position.y+1,other.gameObject.GetComponent<Transform>().position.z);
				other.gameObject.GetComponent<charCtrl>().dammege(Random.Range(8,15));
				chrono2 = tmp;
			}
		}
		
	}

	void dammage(int dammage)
	{
		Pdv -= dammage;
	}
}
