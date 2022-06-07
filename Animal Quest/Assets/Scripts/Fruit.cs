using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;
    public int fruitType;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            switch(fruitType)
            {
                case 0:
                    GameController.instance.apple += Score;
                    GameController.instance.UpdateScoreText(0);
                break;
                case 1:
                    GameController.instance.banana += Score;
                    GameController.instance.UpdateScoreText(1);
                break;
                case 2:
                    GameController.instance.kiwi += Score;
                    GameController.instance.UpdateScoreText(2);
                break;
                case 3:
                    GameController.instance.orange += Score;
                    GameController.instance.UpdateScoreText(3);
                break;
                case 4:
                    GameController.instance.pineapple += Score;
                    GameController.instance.UpdateScoreText(4);
                break;
                case 5:
                    GameController.instance.strawberry += Score;
                    GameController.instance.UpdateScoreText(5);
                break;
            }
            
            Destroy(gameObject, 0.3f);
        }
    }
}
