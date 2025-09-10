using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableWords", menuName = "WordsScriptable")]

public class Words: ScriptableObject
{
    
    [Header("Words Easy")]
    public string word0; 
    public string word1; 
    public string word2; 
    public string word3;
    public string word4; 
    ///////////////////////////////// 
    public string word5; 
    public string word6; 
    public string word7; 
    public string word8; 
    public string word9; 
    public string word10;

    [Header("Words Medium")]
    public string wordM0;
    public string wordM1;
    public string wordM2;
    public string wordM3;
    public string wordM4;
    ///////////////////////////////// 
    public string wordM5;
    public string wordM6;
    public string wordM7;
    public string wordM8;
    public string wordM9;
    public string wordM10;

    [Header("Words Hard")]
    public string wordH0;
    public string wordH1;
    public string wordH2;
    public string wordH3;
    public string wordH4;
    ///////////////////////////////// 
    public string wordH5;
    public string wordH6;
    public string wordH7;
    public string wordH8;
    public string wordH9;
    public string wordH10;
}
