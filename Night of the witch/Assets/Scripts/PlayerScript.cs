using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    GameManager gameManagerInstance;
    public static PlayerScript instance;

    // Use this for initialization
    void Start () {

        gameManagerInstance = GameManager.gameManager;
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void getBonus(GameObject bonus)
    {
        //differentiation des bonus plus tard
        gameManagerInstance.HealPlayer(1);
    }

    public void getHurt(int Damage)
    {
        gameManagerInstance.HurtPlayer(Damage);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
