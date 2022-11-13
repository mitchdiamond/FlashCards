using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField]
    private GameObject hiraganaText;

    public void DisplayHiragana()
    {
        hiraganaText.SetActive(true);
    }

}
