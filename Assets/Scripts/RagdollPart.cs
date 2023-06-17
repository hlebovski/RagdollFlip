using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BodyPartType {
    None,
    Head,
    Pelvis,
    Arms,
    Legs
}

public class RagdollPart : MonoBehaviour {

    [SerializeField] private BodyPartType type;

    private Rigidbody _rigidbody;
    private Character _character;


    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        _character = GetComponentInParent<Character>();
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.GetComponent<Floor>()) {
            if (type == BodyPartType.Head || type == BodyPartType.Pelvis) {
                _character.HitGround();
            }
        }
        
    }


    public void ActivateRigidbody()
    {
        _rigidbody.isKinematic= false;
    }

    public void DeactivateRigidbody()
    {
        _rigidbody.isKinematic = true;
    }
}
