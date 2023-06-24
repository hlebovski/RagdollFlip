using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    [SerializeField] Player character;

    private void Awake() {
        character = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other) {
        
        

        if (other.gameObject.TryGetComponent(out RagdollPart ragdollPart)) {
            character.FinishSequence();
        }
    }
    private void OnCollisionEnter(Collision collision) {
        //if (collision.gameObject.GetComponentInParent<Character>() is Character character) {
        //    character.FinishSequence();
        //}
    }

}
