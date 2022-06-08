using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperLink : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenVideo()
    {
        Application.OpenURL("https://youtu.be/dQw4w9WgXcQ");
    }
}
