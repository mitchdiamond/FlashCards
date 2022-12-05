using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordManager : MonoBehaviour
{
    public delegate void CheckEnglishAnswer(string s, int i);
    public static event CheckEnglishAnswer OnEnglishCheck;

    public delegate void AdvanceCardIndex(int posIndex, int wordIndex);
    public static event AdvanceCardIndex OnAdvanceIndex;

    public TextMeshProUGUI  engText3;
    public TextMeshProUGUI  kanaText3;
    public TextMeshProUGUI  kanjiText3;

    public TextMeshProUGUI kanaText2;
    public TextMeshProUGUI kanjiText2;

    public TextMeshProUGUI kanjiText1;

    public List<VocabCard> activeWords = new List<VocabCard>();

    public int index = 0;

    public int attemptNumber = 1;

    public GameObject Attempt1;
    public GameObject Attempt2;
    public GameObject Attempt3;

    // Start is called before the first frame update
    void Awake()
    {
        // Establish connections to TextMeshPros
        CardUpdater.OnEnglishCheck += CompareEnglish;


        TextAsset cardData = Resources.Load<TextAsset>("WordList");

        string[] data = cardData.text.Split(new char[] {'\n'});

        for(int i = 1; i < data.Length-1; i++)
        {
            string[] row = data[i].Split(new char[] {','});
            VocabCard v = ScriptableObject.CreateInstance<VocabCard>();
            v.e_word = row[0];
            v.k_word = row[1];
            v.h_word = row[2];
            activeWords.Add(v);
        }

        engText3.text = activeWords[index].e_word;
        kanaText3.text = activeWords[index].h_word;
        kanjiText3.text = activeWords[index].k_word;

        kanaText2.text = activeWords[index].h_word;
        kanjiText2.text = activeWords[index].k_word;

        kanjiText1.text = activeWords[index].k_word;

        SetAttemptPrompt();
        
        // foreach(VocabCard v in activeWords)
        // {   
        //     // Debug.Log(v.e_word + ", " + v.k_word + ", " + v.h_word);
        // }
        

    }

    public string getEnglishWord(int i)
    {
        // Debug.Log("Active word size " + activeWords.Count);
        return activeWords[i].e_word;
    }

    void CompareEnglish(string s, int i)
    {
        Debug.Log("Before if statement index is " + i);
        if(s == activeWords[index].e_word)
        {
            if(index < activeWords.Count-1)
            {
                index ++;
            } 
            else
                index = 0;
            engText3.text = activeWords[index].e_word;
            kanaText3.text = activeWords[index].h_word;
            kanjiText3.text = activeWords[index].k_word;

            kanaText2.text = activeWords[index].h_word;
            kanjiText2.text = activeWords[index].k_word;

            kanjiText1.text = activeWords[index].k_word;

            attemptNumber = 1;
            SetAttemptPrompt();

            if(OnAdvanceIndex != null)
                OnAdvanceIndex(i, index+9);

            return;
        }
        else
        {
            if(attemptNumber != 3)
            {
                attemptNumber ++;
                SetAttemptPrompt();
            }
            Debug.Log("Match not found.");
            return;
        }
    }

    public void SetAttemptPrompt()
    {
        switch(attemptNumber)
        {
            case 1:
                Attempt1.gameObject.SetActive(true);
                Attempt2.gameObject.SetActive(false);
                Attempt3.gameObject.SetActive(false);
                break;
            case 2:
                Attempt1.gameObject.SetActive(false);
                Attempt2.gameObject.SetActive(true);
                Attempt3.gameObject.SetActive(false);
                break;
            default:
                Attempt1.gameObject.SetActive(false);
                Attempt2.gameObject.SetActive(false);
                Attempt3.gameObject.SetActive(true);
                break;

        }
    }

}
