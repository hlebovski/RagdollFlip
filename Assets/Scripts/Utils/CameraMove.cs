using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField] private Transform _target;
    [SerializeField] private float _lerpRate = 10f;

    void LateUpdate() {
        Vector3 newPos = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * _lerpRate);
        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
    }
}
