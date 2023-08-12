using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class Car : MonoBehaviour {

    [SerializeField] Player character;
    [SerializeField] private float distance;
    [SerializeField] private float speed;

    private Rigidbody carRigidbody;
    private bool isMoving = false;
    private float distanceTraveled;

    private void Awake() {
        carRigidbody = GetComponent<Rigidbody>();
        character = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.TryGetComponent(out RagdollPart ragdollPart)) {
            isMoving = true;
        }
    }

    private void OnTriggerEnter(Collider other) {

    }

    private void FixedUpdate() {
        if (isMoving && distanceTraveled < distance) {
            //carRigidbody.velocity = transform.right * speed;
            distanceTraveled += 1 * speed;
            carRigidbody.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
        }
    }

}
