using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxCtrl : MonoBehaviour {
    Animation animate = new Animation();

    public float walkSpeed = 8;
    public float runSpeed = 16;

    void Start () {
        animate = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        walk();
	}

    public void walk()
    {
        animate.Play("walk");
        transform.Translate(0, 0, walkSpeed * Time.deltaTime);
    }

    public void run()
    {
        animate.Play("walk");
    }
}
