using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HealthManager : MonoBehaviour
{
    public delegate void DeathEvent();
    public static event DeathEvent OnDeath;
    [SerializeField] private TextMeshProUGUI healthDisplay;
    [SerializeField] private TextMeshProUGUI deathDisplay;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private Animator healthAnimation = null;
    private int health = 6;

    private void OnEnable()
    {
        WordObj.OnHealthUpdate += HealthUpdate;
        WordManager.OnHealthRestart += Restart;
        WordManagerTrap.OnHealthRestart += Restart;
        WordManagerSpace.OnHealthRestart += Restart;
        Fracture.OnHealthHit += HealthUpdate;
    }


    private void OnDisable()
    {
        WordObj.OnHealthUpdate -= HealthUpdate;
        WordManager.OnHealthRestart -= Restart;
        WordManagerTrap.OnHealthRestart -= Restart;
        WordManagerSpace.OnHealthRestart -= Restart;
        Fracture.OnHealthHit -= HealthUpdate;
    }

    private void HealthUpdate()
    {
        health--;
        healthDisplay.text = health.ToString();
        //healthAnimation.Play("healthHit", 0, 0.0f);

        if (health <= 0)
        {
            OnDeath();
            deathDisplay.gameObject.SetActive(true);
            restartButton.SetActive(true);
        }
    }

    // This function is called when the "Restart" function in the WordManager's class is called which then triggers an event that this class is listening to.
    private void Restart()
    {
        health = 6;
        healthDisplay.text = health.ToString();
        deathDisplay.gameObject.SetActive(false);
        restartButton.SetActive(false);
    }
}
