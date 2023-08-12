using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour {

    [SerializeField] private float _floatingSpeed = 1f;
    [SerializeField] private float _floatingAmplitude = 0.5f;

    private Transform CoinMesh;
    private Vector3 coinOrigin;

    private void Awake() {
        CoinMesh = transform.GetChild(0);
        coinOrigin = CoinMesh.position;
    }

    void Update() {
        float offset = Mathf.Sin(Time.time * _floatingSpeed) * _floatingAmplitude;

        CoinMesh.position = new Vector3(coinOrigin.x, coinOrigin.y + offset, coinOrigin.z);
    }

    private void OnTriggerEnter(Collider other) {
        
        Destroy(gameObject);

    }

}
