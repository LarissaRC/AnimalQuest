using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public int apple;
    public int banana;
    public int kiwi;
    public int orange;
    public int pineapple;
    public int strawberry;

    public Text appleText;
    public Text bananaText;
    public Text kiwiText;
    public Text orangeText;
    public Text pineappleText;
    public Text strawberryText;

    public static GameController instance;

    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText(int fruit)
    {
        switch(fruit)
            {
                case 0:
                    appleText.text = apple.ToString();
                break;
                case 1:
                    bananaText.text = banana.ToString();
                break;
                case 2:
                    kiwiText.text = kiwi.ToString();
                break;
                case 3:
                    orangeText.text = orange.ToString();
                break;
                case 4:
                    pineappleText.text = pineapple.ToString();
                break;
                case 5:
                    strawberryText.text = strawberry.ToString();
                break;
            }
    }
}
