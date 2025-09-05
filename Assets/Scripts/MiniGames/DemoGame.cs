using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

namespace Games
{
    public class DemoGameSetup : MonoBehaviour
    {
        void Start()
        {
            // Register your games
            //GameFrameworkManager.Instance.RegisterGame("TicTacToe", new TicTacToeGame());
            //GameFrameworkManager.Instance.RegisterGame("Memory", new MemoryGame());

            // Start TicTacToe immediately
            //GameFrameworkManager.Instance.StartGame();
        }
    }
}
