using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private List<int> _order;

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
            _order.Add(i);
        }

        for(int i=0; i<locations.Length; i++)
        {
            
            tempCardPrefab = Instantiate(cardPrefab, locations[RandomOrder()].transform);
            tempCard = (CardUpdater)tempCardPrefab.GetComponent(typeof(CardUpdater));
            tempCard.UpdateText(wm.getEnglishWord(i));
        }



    }

    int RandomOrder()
    {
        int i = Random.Range(0, _order.Count);
        int n = _order[i];

        _order.RemoveAt(i);

        return n;
    }

}
