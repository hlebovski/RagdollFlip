using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField] private Player player;
    [SerializeField] private float lerpRate = 10f;

    private Transform target;

    private void Awake() {
        target = player.GetComponentInChildren<RagdollPart>().transform;
        
    }

    void LateUpdate() {
       
        Vector3 newPos = Vector3.Lerp(transform.position, target.position, Time.deltaTime * lerpRate);
        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
    }
}
