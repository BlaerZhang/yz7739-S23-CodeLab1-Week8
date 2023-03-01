using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BendBamboo : MonoBehaviour
{
    public float forceAmount = 1;

    private Rigidbody2D rb2D;

    public Rigidbody2D weaponRb2D;

    private Vector2 bendingVector2;

    private Vector2 wavingVector2;

    // private PlayerInputActions playerInputActions;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        // playerInputActions = new PlayerInputActions();
        // playerInputActions.Gameplay.Enable();
        // playerInputActions.Gameplay.Bending.performed += Bending;
        // playerInputActions.Gameplay.WavingWeapon.performed += WavingWeapon;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bending();
        WavingWeapon();
    }

    void Bending()
    {
        rb2D.AddForce(forceAmount * bendingVector2, ForceMode2D.Force);
    }

    void WavingWeapon()
    {
        weaponRb2D.AddForce(wavingVector2 * 20f);
        // Quaternion rotation = Quaternion.LookRotation(Vector3.forward,wavingVector2);
        // weaponRb2D.SetRotation(rotation);
    }

    public void OnBending(InputAction.CallbackContext context)
    {
        // Vector2 inputVector = context.ReadValue<Vector2>();
        // rb2D.AddForce(forceAmount * inputVector, ForceMode2D.Force);
        bendingVector2 = context.ReadValue<Vector2>();
        Debug.Log(bendingVector2);
    }

    public void OnWavingWeapon(InputAction.CallbackContext context)
    {
        wavingVector2 = context.ReadValue<Vector2>();
        Debug.Log(wavingVector2);
    }
}
