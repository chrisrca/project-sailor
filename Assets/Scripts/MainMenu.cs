using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartMenu() {
        SceneManager.LoadScene(0);
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void ShowVersion() {
        SceneManager.LoadScene(2);
    }

    public void ShowCredits() {
        SceneManager.LoadScene(3);
    }
}
