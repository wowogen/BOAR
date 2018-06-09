using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownObjet : MonoBehaviour
{

	public GameObject Foodprefab;
	
	public Vector3 center;
	public Vector3 size;

	public Vector3 center2;
	public Vector3 size2;

	
	// Use this for initialization
	void Start ()
	{
		int hazard = Random.Range(-1, 1);
		if (hazard == 0)
		{
			SpawnFood();
		}
		else
		{
			SpawnFood2();
		}
	}
	
	// Update is called once per frame


	public void SpawnFood()
	{
		Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),Random.Range(-size.y / 2, size.y / 2),Random.Range(-size.z / 2, size.z / 2));
		Instantiate(Foodprefab, pos, Quaternion.identity);
	}
	
	public void SpawnFood2()
	{
		Vector3 pos = center2 + new Vector3(Random.Range(-size2.x / 2, size2.x / 2),Random.Range(-size2.y / 2, size2.y / 2),Random.Range(-size2.z / 2, size2.z / 2));
		Instantiate(Foodprefab, pos, Quaternion.identity);
	}
	
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1,0,0,0.5f);
		Gizmos.DrawCube(center,size);
		Gizmos.DrawCube(center2,size2);
	}
}
