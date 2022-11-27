using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private string []cards;

    [SerializeField]
    private GameObject []locations;

    [SerializeField]
    private GameObject cardPrefab;
    [SerializeField]
    private WordManager wm;


    private GameObject tempCardPrefab;
    private CardUpdater tempCard;



    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<locations.Length; i++)
        {
            
            Debug.Log(i);
            tempCardPrefab = Instantiate(cardPrefab, locations[i].transform);
            tempCard = (CardUpdater)tempCardPrefab.GetComponent(typeof(CardUpdater));
            tempCard.UpdateText(wm.getEnglishWord(i));
        }
    }

}
