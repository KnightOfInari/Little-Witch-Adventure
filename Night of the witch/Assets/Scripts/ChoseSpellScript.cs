using UnityEngine;
using UnityEngine.UI;

public class ChoseSpellScript : MonoBehaviour {

    [SerializeField]
    private Sprite spellOne;
    [SerializeField]
    private Sprite spellTwo;
    [SerializeField]
    private Sprite spellThree;

    private Image currentImage;

	// Use this for initialization
	void Start () {
        currentImage = GetComponent<Image>();
        currentImage.sprite = spellOne;
	}

    public void ChangeIcon(int spellNumber)
    {
       switch (spellNumber)
        {
            case 0:
                currentImage.sprite = spellOne;
                break;
            case 1:
                currentImage.sprite = spellTwo;
                break;
            case 2:
                currentImage.sprite = spellThree;
                break;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
