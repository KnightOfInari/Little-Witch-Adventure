using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIScript : MonoBehaviour {

    GameManager gameManagerInstance;

    public TMP_Text LifeText;
    public Image HealthBar;

    [SerializeField]
    private Sprite noHP;
    [SerializeField]
    private Sprite oneHP;
    [SerializeField]
    private Sprite twoHP;
    [SerializeField]
    private Sprite threeHP;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        gameManagerInstance = GameManager.gameManager;
        HealthBar.sprite = threeHP;
	}
	

    public void HealthUpdate(int currentHealth)
    {
        switch (currentHealth)
        {
            case 0:
                HealthBar.sprite = noHP;
                break;
            case 1:
                HealthBar.sprite = oneHP;
                break;
            case 2:
                HealthBar.sprite = twoHP;
                break;
            case 3:
                HealthBar.sprite = threeHP;
                break;
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        LifeText.text = gameManagerInstance.currentLives.ToString();
    }
}
