using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Slider airSlider, timeSlider;

    [SerializeField]
    private float airMax = 20f, timeMax = 20f;

    private float airValue, timeValue;

    [SerializeField]
    private float airDeductValue = 1f;

    private bool gameRunning;

    [SerializeField]
    private Canvas gameOverCanvas;

    [SerializeField]
    private Text winText, loseText;

    [SerializeField]
    private float restartLvTime = 3f;

    private GameObject player;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        timeValue = timeMax;

        timeSlider.maxValue = timeValue;
        timeSlider.minValue = 0f;
        timeSlider.value = timeValue;

        airValue = airMax;

        airSlider.maxValue = airValue;
        airSlider.minValue = 0f;
        airSlider.value = airValue;

        gameRunning = true;

        player = GameObject.FindWithTag(TagManager.PLAYER_TAG);

    }

    private void Update()
    {
        if (!gameRunning)
            return;

        ReduceTime();
        ReduceAir();
    }

    void ReduceTime()
    {

        timeValue -= Time.deltaTime;
        timeSlider.value = timeValue;

        if (timeValue <= 0f)
        {
            gameRunning = false;
            GameOver(false);
        }

    }

    void ReduceAir()
    {

        airValue -= airDeductValue * Time.deltaTime;
        airSlider.value = airValue;

        if (airValue <= 0f)
        {
            gameRunning = false;
            GameOver(false);
        }

    }

    public void IncreaseAir(float air)
    {
        airValue += air;

        if (airValue > airMax)
            airValue = airMax;

    }

    public void IncreaseTime(float time)
    {
        timeValue += time;

        if (timeValue > timeMax)
            timeValue = timeMax;
    }

    public void GameOver(bool win)
    {

        SoundController.instance.Play_GameOverSound();

        Destroy(player);
        gameOverCanvas.enabled = true;

        gameRunning = false;

        if (win)
            winText.gameObject.SetActive(true);
        else
            loseText.gameObject.SetActive(true);

        Invoke("RestartLevel", restartLvTime);

    }

    void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

} // class














































