using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    InputMap inputMap;
    [SerializeField] private GameObject menuUI;
    //[SerializeField] private GameObject LoadingText;
    [SerializeField] private bool MainMenu;
    public UnityEvent UnPausePlayerEvent;
    public UnityEvent SelectMenuButton;
    public UnityEvent PausePlayerEvent;

    private void Awake()
    {
        inputMap = new InputMap();
        inputMap.Player.Menu.performed += OnMenuActivated;
    }

    public void OnEnable()
    {
        inputMap.Player.Enable();
    }

    public void OnDisable()
    {
        inputMap.Player.Disable();
    }

    public void OnMenuActivated(InputAction.CallbackContext context)
    {
        // Activates Menu //
        if (menuUI.activeSelf == false)
        {
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.MenuOpen);
            menuUI.gameObject.SetActive(true);
            AudioManager.instance.MasterVolumeControl(0.4f);
            PausePlayerEvent.Invoke();
        }

        // Deactivates Menu //        
        else
        {
            if (MainMenu)
            {
                SelectMenuButton.Invoke();
            }       
            AudioManager.instance.PlaySound(AudioManager.instance.audioClips.MenuClose);
            AudioManager.instance.MasterVolumeControl(0.9f);
            menuUI.gameObject.SetActive(false);
            UnPausePlayerEvent.Invoke();
        }
    }  

    public void Level_1()
    {
       // LoadingText.SetActive(true);
        SceneManager.LoadScene("L1");
    }

    public void Level_Trap()
    {
       // LoadingText.SetActive(true);
        SceneManager.LoadScene("Trap");
    }

    public void Level_Space()
    {
        //LoadingText.SetActive(true);
        SceneManager.LoadScene("Space");
    }
    public void Level_Mine()
    {
        //LoadingText.SetActive(true);
        SceneManager.LoadScene("Mine");
    }
    public void Load_MainMenu()
    {
        // LoadingText.SetActive(true);
        SceneManager.LoadScene("Menu");
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}
