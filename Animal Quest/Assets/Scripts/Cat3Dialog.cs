using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat3Dialog : MonoBehaviour
{
    public GameObject dialogObj;
    public Text speechText;
    public string text;
    private string sentence;
    public float typingSpeed;

    public LayerMask playerLayer;
    public float radious;
    bool onRadious, started = false;
    
    public GameObject sleepingCat;

    private string rightAnswer = "tigre";
    public GameObject inputField;
    public GameObject rightImg;
    public GameObject wrongImg;

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

    public void VerifyAnswer()
    {
        string answer = inputField.GetComponent<Text>().text;

        if(answer == rightAnswer)
        {
            wrongImg.SetActive(false);
            rightImg.SetActive(true);

            GameController.instance.cat3Unblocked = true;
        }
        else
        {
            wrongImg.SetActive(true);
            rightImg.SetActive(false);
        }
    }

    public void CloseDialogBox()
    {
        dialogObj.SetActive(false);
        
        started = false;
        speechText.text = "";

        if(GameController.instance.cat3Unblocked)
        {
            sleepingCat.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
