using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItensScreen : MonoBehaviour
{
    [SerializeField] GameObject itensScreen;

    public void OpenScreen()
    {
        itensScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseScreen()
    {
        itensScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
