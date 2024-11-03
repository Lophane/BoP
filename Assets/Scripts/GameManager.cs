using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int dayCounter = 1;

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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDay();
        }
    }

    public void AdvanceDay()
    {
        dayCounter++;
        Debug.Log($"Day {dayCounter} has started.");

        foreach (var follower in followers)
        {
            follower.OnNewDay();
        }
    }

    public int GetCurrentDay()
    {
        return dayCounter;
    }
}