using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour {

    [SerializeField] private float _force = 1000f;
    [SerializeField] private float _horizontal;
    [SerializeField] private float _angular = -100f;
    [SerializeField] Rigidbody _pelvisRigidbody;

    [SerializeField] Rigidbody _leftLegRigidbody;
    [SerializeField] Rigidbody _rightLegRigidbody;

    public bool IsGrounded;
    public bool IsWin = false;
    [SerializeField] private int _times;
    [SerializeField] Manager manager;


    [SerializeField] private Animator _animator;
    private Rigidbody[] _ragdollRigidbodies;
    
    

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
        }
        _animator.enabled = false;
    }


    void Update() {
        

        if (_pelvisRigidbody.isKinematic == false) {
            _pelvisRigidbody.angularVelocity += new Vector3(_pelvisRigidbody.angularVelocity.x, _pelvisRigidbody.angularVelocity.y, _angular);
        }
        

        if (Input.GetMouseButtonDown(0)) {

            if(_pelvisRigidbody.isKinematic == true) EnableRagdoll();

            foreach (Rigidbody rigidbody in _ragdollRigidbodies) {
                rigidbody.velocity = Vector3.zero;
            }
            //_pelvisRigidbody.angularVelocity = new Vector3(_pelvisRigidbody.angularVelocity.x, _pelvisRigidbody.angularVelocity.y, _angular * 10);

            _pelvisRigidbody.velocity = new Vector3(_horizontal, _force, 0);
            //_pelvisRigidbody.angularVelocity = Vector3.Lerp(_pelvisRigidbody.angularVelocity, new Vector3(0, 0, _angular), 5f);


        }




    }


    public void FinishSequence() {

        enabled= false;
        manager.Win();

    }

    public void HitGround() {

        enabled = false;
        manager.Lose();

    }



}
