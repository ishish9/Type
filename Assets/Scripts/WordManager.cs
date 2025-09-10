using UnityEngine;
using System;
using System.Collections;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using TMPro;
using System.Collections.Generic;

public class WordManager : MonoBehaviour
{
    WordArrays wordArrays;
    TouchScreenKeyboard keyboard;
    public static event Action OnScoreChange;
    public static event Action OnMultiplierSubtract;
    public static event Action OnMultiplierAdd;
    public delegate void SaveStat(int correctWord, int incorrectChar);
    public static event SaveStat OnStatUpdate;
    public delegate void RestartStat();
    public static event RestartStat OnHealthRestart;
    public delegate void RestartPool();
    public static event RestartPool OnPoolRestart;
    public delegate void RestartScore();
    public static event RestartScore OnScoreRestart;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private TextMeshProUGUI levelDisplay;
    [SerializeField] private float spawnInterval;
    private List<char> wordToChar = new List<char>();
    private List<GameObject> activeObject = new List<GameObject>();
    public string currentWord;
    private int currentActiveObject;
    private float time = 2;
    public char inputChar;
    public bool acceptingInput = true;
    private bool gameActive = true;
    public bool newInput = true;
    private bool objectSelected;
    private bool objectExpired;
    public int completedWords;
    public int incorrectInputCounter;
    private int level = 1;

    void Start() => wordArrays = GetComponent<WordArrays>();

    private void OnEnable()
    {
        // Enables capturing keyboard input
        Keyboard.current.onTextInput += KeyboardInput;
        WordObj.OnKillObject += ObjectKilled;
        HealthManager.OnDeath += Death;
    }

    private void OnDisable()
    {
        // Disable capturing keyboard input
        Keyboard.current.onTextInput -= KeyboardInput;
        WordObj.OnKillObject -= ObjectKilled;
        HealthManager.OnDeath -= Death;
    }

    private void Update()
    {
        // Spawns new word object after set time interval.
        if (gameActive) 
        { 
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = spawnInterval;
                WordSpawner();
            }
        }
        return;
        // If new text input is detected from virtual keyboard begin inputProcessing.
        if (keyboard.text != null && acceptingInput)
        {
            foreach (char c in keyboard.text)
            {
                inputChar = c;
                break;
            }
            keyboard.text = null;

                if (acceptingInput)
                {
                    acceptingInput = false;

                if (objectSelected)
                    {
                        newInput = true;
                        return;
                    }
                    else
                    {
                        ParseWord();
                        return;
                    }
                }           
        }
    }

    private void KeyboardInput(char c)
    {
        if (acceptingInput)
        {
            acceptingInput = false;
            inputChar = c;
            if (objectSelected)
            {
                newInput = true;
                return;
            }
            else
            {
                ParseWord();
            }
        }
    }

    private void ParseWord()
    {
        gameActive = false;
        for (int i = 0; i < activeObject.Count; i++)
        {
            if (inputChar == activeObject[i].GetComponent<WordObj>().GetFirstChar())
            {
                objectSelected = true;
                currentWord = activeObject[i].GetComponent<WordObj>().ObjActive(inputChar);
                currentActiveObject = i;
                wordToChar.Clear();

                foreach (char c in currentWord)
                {
                    wordToChar.Add(c);
                }
                StartCoroutine(WordCheck());
                return;
            }
            else
            {

            }       
        }
        Debug.Log("NO_MATCHING_INPUT");
        acceptingInput = true;
        gameActive = true;
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LetterWrong);
    }

    IEnumerator WordCheck()
    {
        gameActive = true;

        for (int i = 0; i < wordToChar.Count; i++)
        {
            yield return new WaitUntil(() => newInput == true);
            if (!objectExpired)
            {
                if (inputChar == wordToChar[i])

                {
                    AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LetterCorrect);
                    activeObject[currentActiveObject].GetComponent<WordObj>().WriteToSecondDisplay(inputChar);
                    OnMultiplierAdd?.Invoke();
                    newInput = false;
                    acceptingInput = true;
                }
                else
                {
                    AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LetterWrong);
                    incorrectInputCounter++;
                    OnMultiplierSubtract?.Invoke();
                    newInput = false;
                    acceptingInput = true;
                    i--;
                }
            }
            else
            {
                StopCoroutine(WordCheck());

                newInput = true;
                objectExpired = false;
                objectSelected = false;
                wordToChar.Clear();
                yield break;
            }
        }

        OnScoreChange?.Invoke();
        activeObject[currentActiveObject].GetComponent<WordObj>().ResetObject();
        newInput = true;
        objectSelected = false;
        wordToChar.Clear();
        completedWords++;
        OnStatUpdate(1, incorrectInputCounter);
        LevelManager();
        StopCoroutine(WordCheck());
    }

    public void WordSpawner()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.WordSpawn);
        GameObject wordObject = ObjectPool.instance.GetPooledObject();
        wordObject.transform.position = spawnLocation.transform.position + new Vector3(Random.Range(-2f, 2f), 0, 0);
        wordObject.GetComponent<WordObj>().retrievedWord = wordArrays.DispenseWord();
        activeObject.Add(wordObject);
        wordObject.SetActive(true);
    }

    public void OpenKeyboard()
    {
        // Opens Virtual Keyboard
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, true);       
    }

    public void AcceptInput()
    {
        acceptingInput = !acceptingInput;
    }
    private void LevelManager()
    {
        if (completedWords == 10)
        {
            completedWords = 0;
            spawnInterval -= .2f;
            level++;
            levelDisplay.text = "Level " + level.ToString();
            levelDisplay.gameObject.SetActive(true);
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LevelUp);
        }
    }

    private void ObjectKilled()
    {
        newInput = true;
        objectExpired = true;
    }

    private void Death()
    {
        gameActive = false;
        acceptingInput = false;
        OnPoolRestart();
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.Defeat);

    }

    public void Restart()
    {
        OnScoreRestart();
        OnHealthRestart();
        level = 1;
        spawnInterval = 4;
        gameActive = true;
        acceptingInput = true;
    }
}
