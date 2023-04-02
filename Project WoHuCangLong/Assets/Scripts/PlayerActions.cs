using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    public ActionForceScriptableObject actionForce;
    
    // public float bendingforceAmount = 1;

    // public float wavingforceAmount = 20;

    private Rigidbody2D bodyRb2D;

    private Rigidbody2D weaponRb2D;
    
    public GameObject body;

    public GameObject weapon;

    private Vector2 bendingVector2;

    private Vector2 wavingVector2;

    // private PlayerInputActions playerInputActions;

    // Start is called before the first frame update
    void Start()
    {
        bodyRb2D = body.GetComponent<Rigidbody2D>();
        weaponRb2D = weapon.GetComponent<Rigidbody2D>();
        // playerInputActions = new PlayerInputActions();
        // playerInputActions.Gameplay.Enable();
        // playerInputActions.Gameplay.Bending.performed += Bending;
        // playerInputActions.Gameplay.WavingWeapon.performed += WavingWeapon;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.isInGame)
        {
            Bending();
            WavingWeapon();
        }
    }

    void Bending()
    {
        bodyRb2D.AddForce(actionForce.bendingForceAmount * bendingVector2, ForceMode2D.Force);
    }

    void WavingWeapon()
    {
        weaponRb2D.AddForce(actionForce.wavingForceAmount * wavingVector2, ForceMode2D.Force);
        // Quaternion rotation = Quaternion.LookRotation(Vector3.forward,wavingVector2);
        // weaponRb2D.SetRotation(rotation);
    }

    public void OnBending(InputAction.CallbackContext context)
    {
        // Vector2 inputVector = context.ReadValue<Vector2>();
        // rb2D.AddForce(forceAmount * inputVector, ForceMode2D.Force);
        bendingVector2 = context.ReadValue<Vector2>();
        // Debug.Log(bendingVector2);
    }

    public void OnWavingWeapon(InputAction.CallbackContext context)
    {
        wavingVector2 = context.ReadValue<Vector2>();
        // Debug.Log(wavingVector2);
    }
}
