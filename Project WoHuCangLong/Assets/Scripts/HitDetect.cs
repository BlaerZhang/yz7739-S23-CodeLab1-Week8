using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;

public class HitDetect : MonoBehaviour
{
    public TextMeshProUGUI endingText;

    public HingeJoint2D handJoint;

    public HingeJoint2D footJoint;

    private MMF_Player hitFeedback;

    private bool isHit = false;

    private float hitCoolDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        hitFeedback = GetComponentInParent<MMF_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (footJoint.enabled == false && handJoint.enabled == false)
        {
            GameManager.instance.isInGame = false;
            if (gameObject.CompareTag("Player 1 Weapon"))
            {
                endingText.text = "Player 1 Wins";
            }
            
            if (gameObject.CompareTag("Player 2 Weapon"))
            {
                endingText.text = "Player 2 Wins";
            }
        }

        if (isHit)
        {
            hitCoolDown += Time.deltaTime;
        }

        if (hitCoolDown >= 0.1f)
        {
            isHit = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (GameManager.instance.isInGame && isHit == false)
        {
            if (col.relativeVelocity.magnitude >= 7.5f)
            {
                if(col.gameObject.CompareTag("Player 1 Upper Body") || col.gameObject.CompareTag("Player 2 Upper Body"))
                {
                    isHit = true;
                    hitFeedback.PlayFeedbacks();
                    handJoint.enabled = false;
                }
        
                if(col.gameObject.CompareTag("Player 1 Lower Body") || col.gameObject.CompareTag("Player 2 Lower Body"))
                {
                    isHit = true;
                    hitFeedback.PlayFeedbacks();
                    footJoint.enabled = false;
                }
            }
            
            // if (col.gameObject.CompareTag("Ground"))
            // {
            //     GameManager.instance.isInGame = false;
            //     if (gameObject.CompareTag("Player 1 Weapon"))
            //     {
            //         endingText.text = "Player 2 Wins";
            //     }
            //
            //     if (gameObject.CompareTag("Player 2 Weapon"))
            //     {
            //         endingText.text = "Player 1 Wins";
            //     }
            // }
            
        }
    }

}
