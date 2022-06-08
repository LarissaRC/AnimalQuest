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
        sentence = txt;
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
                        sleepingCow.SetActive(true);
                        Destroy(gameObject);
                    }
            break;
            case 2:
                if(GameController.instance.banana == 1)
                    {
                        sleepingCow.SetActive(true);
                        Destroy(gameObject);
                    }
            break;
            case 3:
                if(GameController.instance.kiwi == 1)
                    {
                        sleepingCow.SetActive(true);
                        Destroy(gameObject);
                    }
            break;
        }

        if(GameController.instance.orange == 1)
        {
            sleepingCow.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
