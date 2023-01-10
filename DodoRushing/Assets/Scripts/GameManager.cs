using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private PlayerController plc;
    private PlayerInputs _inputs; 
    private bool gameFinished;
    private Vector2 initialPositionPlayer;
    private Quaternion initialRotationPlayer;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (instance != null)
        {
            Destroy(instance);
        }
        
        
        instance = this;
        _inputs = new PlayerInputs();
        _inputs.Enable();
        plc._inputs = _inputs;
        Time.timeScale = 0;
        initialPositionPlayer = plc.transform.position;
        initialRotationPlayer = plc.transform.rotation;
    }

    private void Update()
    {
        if (_inputs.Menu.OpenMenu.WasPressedThisFrame() && !gameFinished)
        {
            Pause();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void FinisGame()
    {
        gameFinished = true;
    }

    private void Pause()
    {
        Time.timeScale = 0;
        UIManager.instance.Pause();
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        UIManager.instance.UnPause();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        plc.transform.position = initialPositionPlayer;
        plc.transform.rotation = initialRotationPlayer;
        plc.Reset();
    }
}
