using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressSlide : MonoBehaviour {


    [SerializeField] private Slider slider;

    [SerializeField] private Player player;
    [SerializeField] private Transform playerPelvis;
    [SerializeField] private Transform playerStart;
    [SerializeField] private Transform playerEnd;
    [SerializeField] private Transform playerPos;

    private void Awake() {
        player = FindObjectOfType<Player>();
        playerPelvis = player.GetComponentInChildren<RagdollPart>().transform;
        playerStart = player.transform;
        playerEnd = FindObjectOfType<FinishLine>().transform;
        UpdateSlider(playerStart.position.x, playerEnd.position.x, 0.5f);
    }

    private void Update() {

        UpdateSlider(playerStart.position.x, playerEnd.position.x - 1, playerPelvis.position.x);

    }

    public void UpdateSlider(float min, float max, float progress) {

        slider.minValue = min;
        slider.maxValue = max;
        slider.value = progress;
    }


}
