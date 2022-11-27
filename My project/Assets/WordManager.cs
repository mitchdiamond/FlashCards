using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordManager : MonoBehaviour
{
    public delegate void CheckEnglishAnswer();
    public static event CheckEnglishAnswer OnEnglishCheck;


    [SerializeField]
    private string[]english;
    [SerializeField]
    private string[]kanji;
    [SerializeField]
    private string[]kana;

    public TextMeshProUGUI  engText;
    public TextMeshProUGUI  kanaText;
    public TextMeshProUGUI  kanjiText;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        CardUpdater.OnEnglishCheck += CompareEnglish;
        engText.text = english[0];
        kanaText.text = kana[0];
        kanjiText.text = kanji[0];
    }

    private void FixedUpdate() 
    {
        if(Input.GetKeyDown("space"))
        {
            if(index < english.Length-1)
            {
                index ++;
            } 
            else
                index = 0;
            engText.text = english[index];
            kanaText.text = kana[index];
            kanjiText.text = kanji[index];
        }
    }

    public string getEnglishWord(int i)
    {
        return english[i];
    }

    void CompareEnglish(string s)
    {
        if(s == english[index])
        {
            if(index < english.Length-1)
            {
                index ++;
            } 
            else
                index = 0;
            engText.text = english[index];
            kanaText.text = kana[index];
            kanjiText.text = kanji[index];
        }
        else
        {
            Debug.Log("Match not found.");
        }
    }


}
