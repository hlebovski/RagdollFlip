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
    private Player player;


    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        player = GetComponentInParent<Player>();
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.GetComponent<Floor>()) {
            if (type == BodyPartType.Head || type == BodyPartType.Pelvis) {

                if (player.enabled) player.HitGround();

            }
        } else if (collision.transform.GetComponentInParent<Furniture>()) {
            player.Hit();
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
