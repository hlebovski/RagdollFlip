using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public static Manager Instance { get; private set; }

    [SerializeField] private GameObject _youWinText;
    [SerializeField] private GameObject _youLostText;

    private void Awake() {
        Instance = this;
        _youWinText.SetActive(false);
        _youLostText.SetActive(false);

    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape)) QuitGame();
    }

    public void Win() {
        _youWinText.SetActive(true);
        Invoke(nameof(LoadNextScene), 2f);

    }

    public void Lose() {
        _youLostText.SetActive(true);
        Invoke(nameof(ReloadScene), 2f);

    }

    private void LoadNextScene() {
        Progress.Instance.level = SceneManager.GetActiveScene().buildIndex;
        Progress.Instance.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

}

