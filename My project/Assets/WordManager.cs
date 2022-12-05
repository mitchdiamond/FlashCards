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

    public TextMeshProUGUI  engText;
    public TextMeshProUGUI  kanaText;
    public TextMeshProUGUI  kanjiText;

    public List<VocabCard> activeWords = new List<VocabCard>();

    public int index = 0;

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

        engText.text = activeWords[index].e_word;
        kanaText.text = activeWords[index].h_word;
        kanjiText.text = activeWords[index].k_word;
        
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
            engText.text = activeWords[index].e_word;
            kanaText.text = activeWords[index].h_word;
            kanjiText.text = activeWords[index].k_word;

            if(OnAdvanceIndex != null)
                OnAdvanceIndex(i, index+9);

            return;
        }
        else
        {
            Debug.Log("Match not found.");
            return;
        }
    }


}
