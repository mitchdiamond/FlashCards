using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardUpdater : MonoBehaviour
{
    public TextMeshPro mText;

    [SerializeField]
    string EnglishTranslation;

    public Vector3 startPos;
    public Vector3 zoomPos;

    [SerializeField]
    private float delay = 2.0f;
    [SerializeField]
    private float elapsedTime = 0.0f;
    [SerializeField]
    bool canMoveCard = true;

    private IEnumerator Timer()
    {
        canMoveCard = false;
        while(elapsedTime<=delay)
        {
            elapsedTime+= Time.deltaTime;
            yield return null;
        }
        canMoveCard = true;
        elapsedTime = 0.0f;

    }



    // Start is called before the first frame update
    void Start()
    {
            mText.text = EnglishTranslation;
            startPos = this.transform.position;
    }

    private void OnMouseOver() 
    {
        if(canMoveCard)
        {
            this.transform.position = zoomPos;
            StartCoroutine(Timer());
        }

    }

    private void OnMouseExit() {
        if(canMoveCard)
        {
            this.transform.position = startPos;
            StartCoroutine(Timer());
        }

    }



}
