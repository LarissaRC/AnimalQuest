using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogDialog : MonoBehaviour
{
    public GameObject dialogObj;
    public Text speechText;
    public string text;
    private string sentence;
    public float typingSpeed;

    public LayerMask playerLayer;
    public float radious;
    bool onRadious, started = false;

    public GameObject sleepingDog;

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

        if(GameController.instance.pineapple == 1)
        {
            sentence = "chomp chomp gostoso pra cachorro chomp";
        }
        else
        {
            sentence = txt;
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

        if(GameController.instance.pineapple == 1)
        {
            GameController.instance.pineapple -= 1;
            GameController.instance.UpdateScoreText(4);
            sleepingDog.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
