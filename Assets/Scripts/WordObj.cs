using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class WordObj : MonoBehaviour
{
    public Outline outLine;
    [SerializeField] private TextMeshPro wordDisplay;
    [SerializeField] private TextMeshPro wordDisplay2;
    public delegate void ScoreEvent();
    public static event ScoreEvent OnKillObject;
    public delegate void HealthEvent();
    public static event HealthEvent OnHealthUpdate;
    public string retrievedWord;
    private float speed = .5f;
    public char firstChar;
    [SerializeField] private bool trap;
    private bool active; 

    private void Awake()
    {
        wordDisplay = GetComponent<TextMeshPro>();
    }

    void OnEnable()
    {
        wordDisplay2.text = "";
        wordDisplay.text = retrievedWord;
        foreach (char c in retrievedWord)
        {
            firstChar = c;
            return;
        }
    }

    void OnDisable()
    {
        wordDisplay.color = Color.white;
    }

    private void Update()
    {
        if (trap)
        {

        }
        else
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.WordExpired);

        if (other.CompareTag("WordKiller"))
        {
            OnHealthUpdate();
            gameObject.SetActive(false);
        }

        if (active)
        {
            OnKillObject();
        }
    }

    public string ObjActive(char c)
    {
        outLine.OutlineMode = Outline.Mode.OutlineVisible;
        active = true;

        return retrievedWord;
    }  

    public char GetFirstChar()
    {
        return firstChar;
    }

    public void ResetObject()
    {
        wordDisplay2.text = "";
        retrievedWord = null;
        firstChar = new char();
        active = false;
        outLine.OutlineMode = Outline.Mode.OutlineHidden;
        gameObject.SetActive(false);
    }

    public void WriteToSecondDisplay(char c)
    {
        if (c.ToString() == " ")
        {
            wordDisplay2.text += ".";
        }
        else
        {
            wordDisplay2.text += c;
        }
    }
}
