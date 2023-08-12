using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mellon : MonoBehaviour {

    private Transform CoinMesh;

    private void Awake() {
        CoinMesh = transform.GetChild(0);
    }

    void Update() {

    }

    private void OnTriggerEnter(Collider other) {

        Destroy(gameObject);

    }
}
