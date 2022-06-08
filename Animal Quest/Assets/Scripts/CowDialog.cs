using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowDialog : MonoBehaviour
{
    public GameObject dialogObj;
    public Text speechText;
    public string text;
    private string sentence;
    public float typingSpeed;

    public LayerMask playerLayer;
    public float radious;
    bool onRadious, started = false;

    public GameObject sleepingCow;

    public int fruitType;

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        // Se colidir
        if(hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && onRadious && !started)
        {
            started = true;
            Speech(text);
        }
    }

    public void Speech(string txt)
    {
        dialogObj.SetActive(true);
        
        switch(fruitType)
        {
            case 1:
                if(GameController.instance.apple == 1)
                {
                    sentence = "Saboroso, falta so o leite";
                }
                else
                {
                    sentence = txt;
                }
            break;

            case 2:
                if(GameController.instance.banana == 1)
                {
                    sentence = "isso ta muuuuuuito bom";
                }
                else
                {
                    sentence = txt;
                }
            break;

            case 3:
                if(GameController.instance.kiwi == 1)
                {
                    sentence = "enchi, agora vou pro brejo";
                }
                else
                {
                    sentence = txt;
                }
            break;
        }
        

        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentence.ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void CloseDialogBox()
    {
        dialogObj.SetActive(false);

        started = false;
        speechText.text = "";

        switch (fruitType)
        {
            case 1:
                if(GameController.instance.apple == 1)
                    {
                        GameController.instance.apple -= 1;
                        GameController.instance.UpdateScoreText(0);
                        sleepingCow.SetActive(true);
                        Destroy(gameObject);
                    }
            break;
            case 2:
                if(GameController.instance.banana == 1)
                    {
                        GameController.instance.banana -= 1;
                        GameController.instance.UpdateScoreText(1);
                        sleepingCow.SetActive(true);
                        Destroy(gameObject);
                    }
            break;
            case 3:
                if(GameController.instance.kiwi == 1)
                    {
                        GameController.instance.kiwi -= 1;
                        GameController.instance.UpdateScoreText(2);
                        sleepingCow.SetActive(true);
                        Destroy(gameObject);
                    }
            break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
