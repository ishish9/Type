using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreDisplay;
    [SerializeField] private GameObject coinDisplay;
    [SerializeField] private ParticleSystem addPointParticle;
    private static int coins = 0;
    [SerializeField] private bool L1Level;
    [SerializeField] private bool TrapLevel;
    [SerializeField] private bool SpaceLevel;
    [SerializeField] private bool MineLevel;

    private void Start()
    {
        ScoreDisplay.text = coins.ToString();
    }

    void OnEnable()
    {
       
        MultiplierManager.OnScore += ScoreAdd;
    

        if (L1Level)
        {
            WordManager.OnScoreRestart += Restart;
        }
        if (TrapLevel)
        {
            WordManagerTrap.OnScoreRestart += Restart;
        }
        if (SpaceLevel)
        {
            WordManagerSpace.OnScoreRestart += Restart;
        }
        if (MineLevel)
        {
            //WordManagerMine.OnScoreRestart += Restart;
        }
    }

    void OnDisable()
    {
        MultiplierManager.OnScore -= ScoreAdd;


        if (L1Level)
        {
            WordManager.OnScoreRestart -= Restart;
        }
        if (TrapLevel)
        {
            WordManagerTrap.OnScoreRestart -= Restart;
        }
        if (SpaceLevel)
        {
            WordManagerSpace.OnScoreRestart -= Restart;
        }
        if (MineLevel)
        {
            //WordManagerMine.OnScoreRestart -= Restart;
        }
    }

    public void ScoreAdd(int AddAmount)
    {      
        int waitDisplay = 4;
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.WordComplete);
        addPointParticle.Play();
        coinDisplay.SetActive(true);
        StartCoroutine(updateCoinScore());

        IEnumerator updateCoinScore()
        {
            yield return new WaitForSeconds(.2f);
            coins += AddAmount;
            ScoreDisplay.text = coins.ToString();
            yield return new WaitForSeconds(waitDisplay);
            coinDisplay.SetActive(false);
            StopCoroutine(updateCoinScore());
        }   
    } 

    private void Restart()
    {
        coins = 0;
        ScoreDisplay.text = coins.ToString();
        coinDisplay.SetActive(false);

    }
}
