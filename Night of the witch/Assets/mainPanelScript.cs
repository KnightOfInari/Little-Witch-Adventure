using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainPanelScript : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene(1);
        GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();

    }
}
