using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplierManager : MonoBehaviour
{
    UIShake uiShake;
    public static event Action <int> OnScore;
    [SerializeField] Image barFill;
    [SerializeField] private Gradient gradient;
    [SerializeField] private TextMeshProUGUI multiplierLevelDisplay;
    private float barSpeed = 2f;
    public int multiplierLevel;
    private float currentHealth;
    private float targetFillAmount;                
    private float currentFillAmount;
    [SerializeField] private bool L1Level;
    [SerializeField] private bool TrapLevel;
    [SerializeField] private bool SpaceLevel;
    [SerializeField] private bool MineLevel;

    private void Start()
    {
        uiShake = GetComponent<UIShake>();
    }

    void OnEnable()
    {
        if (L1Level)
        {
            WordManager.OnScoreChange += AddScore;
            WordManager.OnMultiplierSubtract += SubtractMultiplier;
            WordManager.OnMultiplierAdd += AddMultiplier;
        }
        if (TrapLevel)
        {
            WordManagerTrap.OnScoreChange += AddScore;
            WordManagerTrap.OnMultiplierSubtract += SubtractMultiplier;
            WordManagerTrap.OnMultiplierAdd += AddMultiplier;
        }
        if (SpaceLevel)
        {
            WordManagerSpace.OnScoreChange += AddScore;
            WordManagerSpace.OnMultiplierSubtract += SubtractMultiplier;
            WordManagerSpace.OnMultiplierAdd += AddMultiplier;
        }
        if (MineLevel)
        {
            //WordManagerMine.OnScoreChange += AddScore;
            //WordManagerMine.OnMultiplierSubtract += SubtractMultiplier;
            //WordManagerMine.OnMultiplierAdd += AddMultiplier;
        }
    }

    void OnDisable()
    {
        if (L1Level)
        {
            WordManager.OnScoreChange -= AddScore;
            WordManager.OnMultiplierSubtract -= SubtractMultiplier;
            WordManager.OnMultiplierAdd -= AddMultiplier;
        }
        if (TrapLevel)
        {
            WordManagerTrap.OnScoreChange -= AddScore;
            WordManagerTrap.OnMultiplierSubtract -= SubtractMultiplier;
            WordManagerTrap.OnMultiplierAdd -= AddMultiplier;
        }
        if (SpaceLevel)
        {
            WordManagerSpace.OnScoreChange -= AddScore;
            WordManagerSpace.OnMultiplierSubtract -= SubtractMultiplier;
            WordManagerSpace.OnMultiplierAdd -= AddMultiplier;
        }
        if (MineLevel)
        {
            //WordManagerMine.OnScoreChange -= AddScore;
            //WordManagerMine.OnMultiplierSubtract -= SubtractMultiplier;
            //WordManagerMine.OnMultiplierAdd -= AddMultiplier;
        }
    }

    private void Update()
    {
        //currentFillAmount = Mathf.Lerp(0, targetFillAmount, Time.deltaTime * barSpeed);
        //barFill.fillAmount = currentFillAmount;
    }

    private void AddScore()
    {
        
        if (multiplierLevel == 0)
        {
            OnScore?.Invoke(1);

        }
        else
        {
            OnScore?.Invoke(multiplierLevel);

        }
    }

    private void AddMultiplier()
    {
        // multiplyerLevel += .2f;
        currentHealth += 5;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100f);
        multiplierLevelDisplay.text = multiplierLevel.ToString() + " x";
        barFill.fillAmount = currentHealth / 100f;
        barFill.color = gradient.Evaluate(currentHealth / 100f);
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.MultiAdd);
        if (currentHealth >= 100)
        {
            currentHealth = 0;
            multiplierLevel += 10;
            multiplierLevel = Mathf.Clamp(multiplierLevel, 0, 100);
            multiplierLevelDisplay.text = multiplierLevel.ToString() + " x";
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.MultiLevelUp);
        }
    }

    private void SubtractMultiplier()
    {
        currentHealth -= 6;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100f);
        multiplierLevelDisplay.text = multiplierLevel.ToString() + " x";
        barFill.fillAmount = currentHealth / 100f;
        barFill.color = gradient.Evaluate(currentHealth / 100f);
        AudioManager.instance.PlaySound(AudioManager.instance.audioClips.MultiSubtract);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            multiplierLevel -= 10;
            multiplierLevel = Mathf.Clamp(multiplierLevel, 0, 100);
            multiplierLevelDisplay.text = multiplierLevel.ToString() + " x";
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.MultiLevelDown);
        }
        uiShake.TriggerShake();
    }  
}
