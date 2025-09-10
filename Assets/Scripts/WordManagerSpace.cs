using UnityEngine;
using System;
using System.Collections;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class WordManagerSpace : MonoBehaviour
{
    WordArrays wordArrays;
    TouchScreenKeyboard keyboard;
    public static event Action OnScoreChange;
    public static event Action OnMultiplierSubtract;
    public static event Action OnMultiplierAdd;
    public delegate void SaveStat(int correctWord,int incorrectChar);
    public static event SaveStat OnStatUpdate;
    public delegate void RestartStat();
    public static event RestartStat OnHealthRestart;
    public delegate void RestartPool();
    public static event RestartPool OnPoolRestart;
    public delegate void RestartScore();
    public static event RestartScore OnScoreRestart;
    //public static event Action OnScoreRestfart;

    private List<char> wordToChar = new List<char>();
   // private List<string> activeWord = new List<string>();
    private List<GameObject> asteroidList = new List<GameObject>();
    public float[] distanceList = new float[20];
    private Dictionary<float, Transform> distanceDictionary = new Dictionary<float, Transform>();
    private int[] test = {5,4,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
    [SerializeField] private Transform targetAsteroid ;
    [SerializeField] private int beginTrackingDistance;
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] bulletSpawn;
    [SerializeField] private TextMeshPro wordDisplay;
    [SerializeField] private TextMeshPro wordDisplay2;
    [SerializeField] private TextMeshProUGUI levelDisplay;
    [SerializeField] private GameObject astroidSpawnLocation;
    [SerializeField] private float spawnInterval;
    public string currentWord;
    private int asteroidIndex;
    private float time;
    public char inputChar;
    public bool acceptingInput = true;
    public bool newInput;
    private bool wordSelected;
    private int asteroidIdIndex;
    private int completedWords;
    public int incorrectInputCounter;
    private int level = 1;
    private bool gameActive = true;

    void Start()
    {
        Physics.gravity = new Vector3(0, 0, 0);
        wordArrays = GetComponent<WordArrays>();
        StartCoroutine(WaitForInput());

       // WordSpawner();
    }

    private void OnEnable()
    {
        // Enables capturing keyboard input
        Keyboard.current.onTextInput += KeyboardInput;
        WordObj.OnKillObject += ObjectKilled;
        HealthManager.OnDeath += Death;
        Fracture.OnAsteroidDeath += RemoveAsteroidFromList;
    }

    private void OnDisable()
    {
        // Disable capturing keyboard input
        Keyboard.current.onTextInput -= KeyboardInput;
        WordObj.OnKillObject -= ObjectKilled;
        HealthManager.OnDeath -= Death;
        Fracture.OnAsteroidDeath -= RemoveAsteroidFromList;
    }

    private void Update()
    {
        if (gameActive)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime;
            }
            else
            {
                time = spawnInterval;
                SpawnAsteroid();
            }
        }
        //TrackAsteroid();
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

                if (wordSelected)
                {
                    newInput = true;
                    return;
                }
                else
                {
                    acceptingInput = true;
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
            if (wordSelected)
            {
                newInput = true;
                return;
            }
            else
            {
                acceptingInput = true;
                return;
            }
        }
    }

    IEnumerator WordCheck()
    {

        for (int i = 0; i < wordToChar.Count; i++)
        {
            yield return new WaitUntil(() => newInput == true);
            
                if (inputChar == wordToChar[i])

                {
                    AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LetterCorrect);
                    WriteToSecondDisplay(inputChar);
                    Fire();
                    newInput = false;
                    acceptingInput = true;
                }
                else
                {
                Debug.Log("Incorrect Input");
                    AudioManager.instance.PlaySound(AudioManager.instance.audioClips.LetterWrong);
                    incorrectInputCounter++;
                    OnMultiplierSubtract?.Invoke();
                    newInput = false;
                    acceptingInput = true;
                    i--;
                }
        }
     
        OnScoreChange?.Invoke();
        OnMultiplierAdd?.Invoke();
        completedWords++;
        yield return new WaitForSeconds(.5f);
        newInput = true;
        wordSelected = false;
        wordDisplay2.text = null;
        wordToChar.Clear();
        StartCoroutine(WaitForInput());

       // WordSpawner();
        LevelManager();
        OnStatUpdate(completedWords, incorrectInputCounter);
        StopCoroutine(WordCheck());
    }

    public void WordSpawner()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.WordSpawn);    
        currentWord = wordArrays.DispenseWord();
        wordDisplay.text = currentWord;
        foreach (char c in currentWord)
        {
            wordToChar.Add(c);
        }
       // activeWord.Add(currentWord);
        wordSelected = true;
        StartCoroutine(WordCheck());
    }

    IEnumerator WaitForInput()
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.WordSpawn);
        currentWord = wordArrays.DispenseWord();
        wordDisplay.text = currentWord;
        foreach (char c in currentWord)
        {
            wordToChar.Add(c);
        }
        wordSelected = true;
        newInput = false;
        yield return new WaitUntil(() => newInput == true);
        StartCoroutine(WordCheck());
    }

    private void Fire()
    {
        
        targetAsteroid = TrackAsteroid();
        
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.FireProjectile);
        GameObject bulletPool = ObjectPool.instance.GetPooledObject2();
        if (bulletPool != null)
        {
            int bulletIndex = Random.Range(0, 2);
            bulletPool.transform.position = bulletSpawn[bulletIndex].transform.position;
            bulletPool.SetActive(true);
            //bulletPool.GetComponent<Rigidbody>().linearVelocity = transform.forward * Projectilespeed;
            Rigidbody rb = bulletPool.GetComponent<Rigidbody>();
              
            Vector3 direction = targetAsteroid.transform.position - bulletSpawn[bulletIndex].transform.position;
            rb.linearVelocity = new Vector3(direction.x, direction.y, direction.z).normalized * 20;
            return;
        }
    }

    private Transform TrackAsteroid()
    {
        distanceDictionary.Clear();
        for (int i = 0; i < asteroidList.Count; i++)
        {
            //distanceList2.Add(Vector3.Distance(player.transform.position, asteroidList[i].transform.position));
            distanceDictionary.Add(Vector3.Distance(player.transform.position, asteroidList[i].transform.position), asteroidList[i].transform);
        }
       
        if (distanceDictionary == null || distanceDictionary.Count == 0)
        {
            return astroidSpawnLocation.transform;
        }
        else
        {
            Transform t = distanceDictionary[distanceDictionary.Keys.Min()] ;
            return t;
        }
    }

    private void SpawnAsteroid()
    {
        GameObject asteroidObject = ObjectPool.instance.GetPooledObjectMultiple();
        asteroidObject.transform.position = astroidSpawnLocation.transform.position + new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), 0);
        Debug.Log("ITWORKS");
        asteroidObject.SetActive(true);
        asteroidObject.GetComponent<Fracture>().id = asteroidIdIndex;
        asteroidIdIndex++;
        Rigidbody rb = asteroidObject.GetComponent<Rigidbody>();
        Vector3 direction = player.transform.position - asteroidObject.transform.position ;
        rb.linearVelocity = new Vector3(direction.x, direction.y, direction.z).normalized * 5;
        asteroidList.Add(asteroidObject);
    }

    public void OpenKeyboard()
    {
        // Opens Virtual Keyboard
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true, true);       
    }


    public void WriteToSecondDisplay(char c)
    {
        //wordDisplay2.text += c;
        if (c.ToString() == " ")
        {
            wordDisplay2.text += ".";
        }
        else
        {
            wordDisplay2.text += c;
        }
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
    }

    // The "HealthManager" class upon detecting players death will call this function through an event.
    private void Death()
    {
        wordDisplay.text = null;
        wordDisplay2.text = null;
        newInput = true;
        wordSelected = false;
        wordToChar.Clear();

        gameActive = false;
        acceptingInput = false;
        OnPoolRestart();
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.Defeat);

    }
    // The OnClick() for the restart button that appears after player dies, calls this function.
    // This method resets variables to default for a new player session.
    public void Restart()
    {
        OnScoreRestart();
        OnHealthRestart();
        level = 1;
        spawnInterval = 10;
        gameActive = true;
        acceptingInput = true;
        completedWords = 0;
    }

    // An asteroid upon its destruction will call this function to remove it from the list ("asteroidList") of currently active asteroids.
    public void RemoveAsteroidFromList(int id)
    {
        for (int i = 0; i < asteroidList.Count; i++)
        {
            if (asteroidList[i].GetComponent<Fracture>().id == id)
            {
                asteroidList.RemoveAt(i);
            }
        }
    }
}
