using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle_animaux : MonoBehaviour {

    public GameObject lapin;
    public GameObject stag;
    public GameObject Boar;
    private Vector3 start_Pos_lapin;

    // Use this for initialization
    void Start () {
        start_Pos_lapin = lapin.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.M))
        {
            lapin.SetActive(false);
            Boar.SetActive(false);
            stag.transform.position = start_Pos_lapin;
            stag.SetActive(true);
        }
        if (Input.GetKey(KeyCode.L))
        {
            stag.SetActive(false);
            Boar.SetActive(false);
            lapin.transform.position = start_Pos_lapin;
            lapin.SetActive(true);
        }
        if (Input.GetKey(KeyCode.O))
        {
            stag.SetActive(false);
            lapin.SetActive(false);
            Boar.transform.position = start_Pos_lapin;
            Boar.SetActive(true);
        }
    }
}
