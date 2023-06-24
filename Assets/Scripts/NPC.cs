using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour {


    private Rigidbody[] _ragdollRigidbodies;
    
    

    private void Awake() {

        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        EnableRagdoll();

    }


    private void DisableRagdoll() {

        foreach (Rigidbody rigidbody in _ragdollRigidbodies) {
            rigidbody.isKinematic = true;
        }
    }

    private void EnableRagdoll() {
        foreach (Rigidbody rigidbody in _ragdollRigidbodies) {
            rigidbody.isKinematic = false;
        }
    }


    void Update() {

    }



}
