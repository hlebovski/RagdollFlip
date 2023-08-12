using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float _verticalImp;
    [SerializeField] private float _horizontalImp;
    [SerializeField] private float _angularImp;

    [SerializeField] private bool _secondTapAngular;
    [SerializeField] private float _targetAngular;
    [SerializeField] private float _currentAngular;

    [SerializeField] Rigidbody _pelvisRigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] Manager manager;


    private Rigidbody[] _ragdollRigidbodies;
    public bool IsGrounded;
    public bool IsWin = false;
    private int _tapTimes;
    private float _tapDuration;


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

        _currentAngular = Mathf.Lerp(_currentAngular, _targetAngular, 2f * Time.deltaTime);  

        if (_pelvisRigidbody.isKinematic == false) {
            _pelvisRigidbody.angularVelocity = new Vector3(_pelvisRigidbody.angularVelocity.x, _pelvisRigidbody.angularVelocity.y, _currentAngular);
        }
        

        if (Input.GetMouseButtonDown(0)) {

            _tapDuration= Time.time;

            if(_pelvisRigidbody.isKinematic == true) EnableRagdoll();

            if(_secondTapAngular) _currentAngular = _targetAngular;
            _targetAngular = _angularImp;

            if (_tapTimes < 2) {
                _tapTimes += 1;
                foreach (Rigidbody rigidbody in _ragdollRigidbodies) {
                    rigidbody.velocity = Vector3.zero;
                }

                _pelvisRigidbody.velocity = new Vector3(_horizontalImp, _verticalImp, 0);
            }

        }


    }


    public void Hit() {
        _tapTimes = 0;
        if (Time.time - _tapDuration > 0.1f) {
            _currentAngular = 2f;
            _targetAngular = 0f;
        }
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
