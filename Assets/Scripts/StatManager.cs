using UnityEngine;
using System.IO;
using TMPro;

public class StatManager : MonoBehaviour
{
    GameData gameData;
    [SerializeField] private TextMeshProUGUI completedWordDisplay;
    [SerializeField] private TextMeshProUGUI incorrectInputDisplay;
    [SerializeField] private bool menu;

    private void Awake() => gameData = new GameData();
    void Start() => Load();  

    private void OnEnable()
    {
        WordManager.OnStatUpdate += RecieveData;
        WordManagerTrap.OnStatUpdate += RecieveData;
        WordManagerSpace.OnStatUpdate += RecieveData;
    }

    private void OnDisable()
    {
        WordManager.OnStatUpdate -= RecieveData;
        WordManagerTrap.OnStatUpdate -= RecieveData;
        WordManagerSpace.OnStatUpdate -= RecieveData;
    }

    public void RecieveData(int correctWord, int incorrectInput)
    {
        gameData.WordsCompleted += correctWord;
        gameData.ErrorInputs += incorrectInput;
        Save();
    }

    public void RecieveTrophie(int correctWord, int incorrectInput)
    {
        gameData.WordsCompleted += correctWord;
        gameData.ErrorInputs += incorrectInput;
        Save();
    }



    private void Save()
    {
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(Application.dataPath + "/gameData.json", json);
    }

    private void Load()
    {
        string json = File.ReadAllText(Application.dataPath + "/gameData.json");
        gameData = JsonUtility.FromJson<GameData>(json);
        if (menu)
        {
            completedWordDisplay.text = gameData.WordsCompleted.ToString();
            incorrectInputDisplay.text = gameData.ErrorInputs.ToString();
        }     
    }
}
