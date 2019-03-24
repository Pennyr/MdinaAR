using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOff : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {

    }


    void AnimationEnd()
    {
        anim.enabled = false;
        
    }
}
