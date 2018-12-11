using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour {


    GameManager gameManagerInstance;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        gameManagerInstance = GameManager.gameManager;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
