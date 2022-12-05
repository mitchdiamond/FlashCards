using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public delegate void AdvanceCardIndex(int posIndex, int wordIndex);
    public static event AdvanceCardIndex OnAdvanceIndex;

    [SerializeField]
    private string []cardObjects;

    [SerializeField]
    private CardUpdater []cards;

    [SerializeField]
    private GameObject []locations;

    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private WordManager wm;


    private GameObject tempCardPrefab;
    public GameObject tempObject;
    public CardUpdater tempCard;



    // Start is called before the first frame update
    void Start()
    {
        WordManager.OnAdvanceIndex += AdvanceIndex;

        for(int i=0; i<locations.Length; i++)
        {
            Debug.Log(i);
            tempCardPrefab = Instantiate(cardPrefab, locations[i].transform);
            tempCard = (CardUpdater)tempCardPrefab.GetComponent(typeof(CardUpdater));
            tempCard.UpdateCardInfo(wm.getEnglishWord(i), i);
            cards[i] = tempCard;
        }
    }

    
    void AdvanceIndex(int posIndex, int wordIndex)
    {
        Debug.Log("Position index is "+ posIndex + " word index is " + wordIndex);
        tempCard = cards[posIndex];

        tempCard.UpdateCardInfo(wm.getEnglishWord(wordIndex), posIndex);
        // tempCard.PrintWord();
    }

}
