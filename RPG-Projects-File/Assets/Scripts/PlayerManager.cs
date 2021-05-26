using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    #region Static Script
    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Transform player;

    internal void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
