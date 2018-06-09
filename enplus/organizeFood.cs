using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organizeFood : MonoBehaviour
{

	public FoodSysteme food;
	public GameObject apple;
	public GameObject apple1;
	public GameObject apple2;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!food.hungry && !food.starving)
		{
			apple.SetActive(true);
			apple1.SetActive(false);
			apple2.SetActive(false);
		}
		else if (food.hungry && !food.starving)
		{
			apple.SetActive(false);
			apple1.SetActive(true);
			apple2.SetActive(false);
		}
		else
		{
			apple.SetActive(false);
			apple1.SetActive(false);
			apple2.SetActive(true);
		}
	}
}
