using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RandomKodu : MonoBehaviour
{
    public static RandomKodu Instance { get; private set; }
    public TextMeshProUGUI sayiText;
    public int randomNumber;
    public int tutulanSayi;
    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        RandomNumber();
    }
    public void RandomNumber()
    {
        randomNumber = UnityEngine.Random.Range(1, 20);
        sayiText.text = randomNumber.ToString();
        tutulanSayi = Convert.ToInt32(sayiText.text);
    }


}

