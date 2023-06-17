using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    [SerializeField] Character character;

    private void Awake() {
        character = FindObjectOfType<Character>();
    }

    private void OnTriggerEnter(Collider other) {
        
        

        if (other.gameObject.TryGetComponent(out RagdollPart ragdollPart)) {
            character.FinishSequence();
        }
    }
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("col");
        if (collision.gameObject.TryGetComponent(out Character character)) {
            character.FinishSequence();
        }
    }

}
