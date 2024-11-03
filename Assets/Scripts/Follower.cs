using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public void OnNewDay()
    {
        Debug.Log($"Follower {name} is experiencing day {GameManager.Instance.GetCurrentDay()}");
        // Random event logic here
    }
}
