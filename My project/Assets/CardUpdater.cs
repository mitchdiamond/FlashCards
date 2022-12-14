using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardUpdater : MonoBehaviour
{
    public delegate void CheckEnglishAnswer(string s, int i);
    public static event CheckEnglishAnswer OnEnglishCheck;




    public int cardIndex = 0;

    public TextMeshPro  mText;

    [SerializeField]
    string EnglishTranslation;
    [SerializeField]
    string JapaneseTranslation;

    public Vector3 startPos;
    public Vector3 zoomPos;

    // [SerializeField]
    // private float delay = 2.0f;
    // [SerializeField]
    // private float elapsedTime = 0.0f;
    // [SerializeField]
    // bool canMoveCard = true;

    // private IEnumerator Timer()
    // {
    //     canMoveCard = false;
    //     while(elapsedTime<=delay)
    //     {
    //         elapsedTime+= Time.deltaTime;
    //         yield return null;
    //     }
    //     canMoveCard = true;
    //     elapsedTime = 0.0f;

    // }

    public void UpdateCardInfo(string e, int i)
    {
        if(mText!= null)
        {
            EnglishTranslation = e;
            mText.text = e;
        }

        cardIndex = i;
    }

    public void PrintWord()
    {
        Debug.Log(EnglishTranslation);
    }

    // Start is called before the first frame update
    void Start()
    {
        mText = GetComponentInChildren(typeof(TextMeshPro)) as TextMeshPro;
        // if()
        mText.text = EnglishTranslation;
        startPos = this.transform.position;
    }

    private void OnMouseOver() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(OnEnglishCheck != null)
                OnEnglishCheck(EnglishTranslation, cardIndex);

            
        }    
    }


}