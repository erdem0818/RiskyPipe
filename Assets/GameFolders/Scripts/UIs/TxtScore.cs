﻿namespace RiskyPipe3D.UIs
{
    using System;
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.Scripts.Managers;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Text))]
    public class TxtScore : MonoBehaviour
    {
        private Text _txtScore;
        void Awake()
        {
            _txtScore = GetComponent<Text>();
            EventManager.Instance.ScoreChanged += OnScoreChanged;
            EventManager.Instance.GameStateChanged += OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            if (gameState.Equals(GameState.Playing) || gameState.Equals(GameState.Win))
            {
                OnScoreChanged(0);
                gameObject.SetActive(true);
            }
            else
                gameObject.SetActive(false);
        }

        private void OnScoreChanged(int totalScore)
        {
            _txtScore.text = totalScore.ToString();
        }
    }
}