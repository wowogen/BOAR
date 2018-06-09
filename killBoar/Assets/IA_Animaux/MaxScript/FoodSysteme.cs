using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSysteme : MonoBehaviour
{


	public float food;
	public int fleshNumber;
	public float vitesseFaim;
	public bool starving;
	public bool hungry;
	public float InitChrono;
	private float chrono;
	private charCtrl dammage;
	
	
	// Use this for initialization
	void Start ()
	{
		chrono = InitChrono;
		dammage = GetComponent<charCtrl>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (food <= 0)
		{
			starving = true;
			food = 0;
			chrono -= Time.deltaTime;
			if (chrono <= 0)
			{
				chrono = InitChrono;
				dammage.dammege(10);
			}
		}
		else
		{
			starving = false;
			food -= vitesseFaim * Time.deltaTime;
			if (food<30)
			{
				hungry = true;
			}
			else
			{
				hungry = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			fleshNumber = eat(fleshNumber);
		}
	}

	public void addFood(int plusfood)
	{
		fleshNumber += plusfood;
	}
	
	int eat(int element)
	{
		if (element > 0)
		{
			element--;
			food += 20;
			if (food>100)
			{
				food = 100;
			}
		}

		return element;
	}
}
