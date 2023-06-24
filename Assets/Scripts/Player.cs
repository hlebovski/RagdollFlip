using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float _force;
    [SerializeField] private float _horizontal;
    [SerializeField] private float _angular;
    [SerializeField] Rigidbody _pelvisRigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] Manager manager;

    private Rigidbody[] _ragdollRigidbodies;
    public bool IsGrounded;
    public bool IsWin = false;
    private int _times;



    private void Awake() {

        manager = FindObjectOfType<Manager>();
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        _pelvisRigidbody.maxAngularVelocity = 500f;
        DisableRagdoll();
        
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
            rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        } 
        _animator.enabled = false;
    }


    void Update() {
        

        if (_pelvisRigidbody.isKinematic == false) {
            _pelvisRigidbody.angularVelocity = Vector3.Lerp(_pelvisRigidbody.angularVelocity, new Vector3(_pelvisRigidbody.angularVelocity.x, _pelvisRigidbody.angularVelocity.y, _angular), 1f);
        }
        

        if (Input.GetMouseButtonDown(0)) {

            if(_pelvisRigidbody.isKinematic == true) EnableRagdoll();

            if (_times < 2) {
                _times += 1;
                foreach (Rigidbody rigidbody in _ragdollRigidbodies) {
                    rigidbody.velocity = Vector3.zero;
                }
                _pelvisRigidbody.angularVelocity = Vector3.one;

                _pelvisRigidbody.velocity = new Vector3(_horizontal, _force, 0);
            }

        }


    }

    public void Hit() {
        _times = 0;

    }

    public void FinishSequence() {
        if (enabled) {
            enabled = false;
            manager.Win();
        }

    }

    public void HitGround() {

        enabled = false;
        manager.Lose();

    }



}
