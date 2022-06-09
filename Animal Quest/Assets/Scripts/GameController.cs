using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public int apple;
    public int banana;
    public int kiwi;
    public int orange;
    public int pineapple;
    public int strawberry;
    public int key;

    public bool cat2Unblocked = false;
    public bool cat3Unblocked = false;
    public bool armadilloUnblocked = false;

    public Text appleText;
    public Text bananaText;
    public Text kiwiText;
    public Text orangeText;
    public Text pineappleText;
    public Text strawberryText;
    public Text keyText;

    public static GameController instance;

    void Start()
    {
        instance = this;

        // Resolução da tela padrão
        Screen.SetResolution(880, 360, true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
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
                case 6:
                    keyText.text = key.ToString();
                break;
            }
    }
}
