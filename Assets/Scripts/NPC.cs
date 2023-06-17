using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour {

    [SerializeField] private Animator _animator;
    private Rigidbody[] _ragdollRigidbodies;
    
    

    private void Awake() {

        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        EnableRagdoll();

    }


    private void DisableRagdoll() {

        foreach (Rigidbody rigidbody in _ragdollRigidbodies) {
            rigidbody.isKinematic = true;
        }
        _animator.enabled = true;
    }

    private void EnableRagdoll() {
        foreach (Rigidbody rigidbody in _ragdollRigidbodies) {
            rigidbody.isKinematic = false;
        }
        _animator.enabled = false;
    }


    void Update() {

    }



}
