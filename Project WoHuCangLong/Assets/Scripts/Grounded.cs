using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using Unity.VisualScripting;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public MMF_Player groundFeedback;

    private bool isGrounded = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (isGrounded == false)
        {
            isGrounded = true;
            groundFeedback.PlayFeedbacks();
        }
    }
}
