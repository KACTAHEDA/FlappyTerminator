using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    public int CurentScore { get; private set; }

    public event Action ScoreChanged;

    public void AddScore(int value)
    {
        CurentScore += value;
        ScoreChanged?.Invoke();
    }
}
