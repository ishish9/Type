using UnityEngine;
using TMPro;
using System.Collections;

public class WordObj_Spawner : MonoBehaviour
{
    [SerializeField] private TextMeshPro wordDisplay;
    public string retrievedWord;

    void OnEnable()
    {
        StartCoroutine(Deacvtivate());
        wordDisplay = GetComponent<TextMeshPro>();
        wordDisplay.text = retrievedWord;
    }

    void OnDisable()
    {
        StopCoroutine(Deacvtivate());
    }

    IEnumerator Deacvtivate()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
    }

    public string ObjActive()
    {
        return retrievedWord;
    }  
}
