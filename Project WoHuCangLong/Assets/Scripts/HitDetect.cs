using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class HitDetect : MonoBehaviour
{
    public TextMeshProUGUI endingText;

    [FormerlySerializedAs("handJoint")] public HingeJoint2D rivalHandJoint;

    [FormerlySerializedAs("footJoint")] public HingeJoint2D rivalFootJoint;

    public float weaponContactForce = 10;

    public MMF_Player hitBodyFeedback;

    public MMF_Player hitWeaponFeedback;

    private Rigidbody2D weaponRb2D;

    private bool isHit = false;

    private float hitCoolDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        // hitBodyFeedback = GetComponentInParent<MMF_Player>();
        weaponRb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rivalFootJoint.enabled == false && rivalHandJoint.enabled == false)
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

        if (hitCoolDown >= 0.5f)
        {
            isHit = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (GameManager.instance.isInGame && isHit == false)
        {
            if (col.GetContact(0).relativeVelocity.magnitude >= 10f)
            {
                if(col.gameObject.CompareTag("Player 1 Upper Body") || col.gameObject.CompareTag("Player 2 Upper Body"))
                {
                    isHit = true;
                    hitBodyFeedback.transform.position = col.GetContact(0).point;
                    hitBodyFeedback.PlayFeedbacks();
                    rivalHandJoint.enabled = false;
                }
        
                if(col.gameObject.CompareTag("Player 1 Lower Body") || col.gameObject.CompareTag("Player 2 Lower Body"))
                {
                    isHit = true;
                    hitBodyFeedback.transform.position = col.GetContact(0).point;
                    hitBodyFeedback.PlayFeedbacks();
                    rivalFootJoint.enabled = false;
                }

                if (col.gameObject.CompareTag("Player 1 Weapon") || col.gameObject.CompareTag("Player 2 Weapon"))
                {
                    isHit = true;
                    hitWeaponFeedback.transform.position = col.GetContact(0).point;
                    hitWeaponFeedback.PlayFeedbacks();
                    weaponRb2D.AddForceAtPosition(col.relativeVelocity * weaponContactForce,col.GetContact(0).point, ForceMode2D.Impulse);
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
