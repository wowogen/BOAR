using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foxAnimation : MonoBehaviour {
    Animation animate = new Animation();
    public foxAnimation()
    {
        animate = GetComponent<Animation>();
    }

    public void walk()
    {
        animate.Play("walk");
    }

}
