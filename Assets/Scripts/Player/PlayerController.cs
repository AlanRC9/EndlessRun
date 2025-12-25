using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour {
    [SerializeField] private InputAction touchInputAction;
    [SerializeField] private float movementSens;

    Rigidbody rb;

    private void OnEnable() {
        touchInputAction.Enable();
    }

    private void OnDisable() {
        touchInputAction.Disable();
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
    }   

    void FixedUpdate() {
        Vector2 touch = touchInputAction.ReadValue<Vector2>();

        float centeredX = (touch.x / Screen.width) - 0.5f;

        DOTween.Clear();
        transform.DOMoveX(centeredX * movementSens, 0.3f).SetEase(Ease.OutQuad);


    }
}
