using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    public event Action ScoreChanged;

    public int CurentScore { get; private set; }

    public void AddScore(int value)
    {
        CurentScore += value;
        ScoreChanged?.Invoke();
    }
}
