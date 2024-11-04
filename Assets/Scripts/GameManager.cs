using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int dayCounter = 1;
    public TextMeshProUGUI dayCounterText;

    public List<Follower> followers = new List<Follower>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Makes sure this object is not destroyed when switching scenes

        Debug.Log($"Day {dayCounter} has started.");

    }

    private void Start()
    {
        UpdateDayCounterUI(); // Initialize the day counter UI
    }


    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDay();
        }
    }*/

    public void AdvanceDay()
    {
        dayCounter++;
        Debug.Log($"Day {dayCounter} has started.");
        UpdateDayCounterUI();

        foreach (var follower in followers)
        {
            follower.OnNewDay();
        }

    }

    public int GetCurrentDay()
    {
        return dayCounter;
    }

    private void UpdateDayCounterUI()
    {
        if (dayCounterText != null)
        {
            dayCounterText.text = "Day: " + dayCounter;
        }
    }

}