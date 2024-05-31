using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberHolder : MonoBehaviour
{
    public int number;
    public TextMeshProUGUI numberText;

    private void Start()
    {
        if (numberText != null)
        {
            numberText.text = number.ToString();
        }
    }

    public void SetNumber(int newNumber)
    {
        number = newNumber;
        if (numberText != null)
        {
            numberText.text = number.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player tag'ini kontrol ediyoruz
        {
            //Debug.Log("carptiginiz prefabin sayisi: " + number);
            CheckAnswer();
            Destroy(gameObject);
        }


    }

    public void CheckAnswer()
    {
        if (SymbolController.Instance.dogruCevap == number)
        {
            //Debug.Log("cevap dogru");
            GameManager.Instance.score += 50;

        }

        else
        {


            if (GameManager.Instance.currentIndex >= 0)
            {
                GameManager.Instance.canUI[GameManager.Instance.currentIndex].SetActive(false);
                GameManager.Instance.currentIndex--;
            }


            GameManager.Instance.can--;
            Debug.Log(GameManager.Instance.can);
            if (GameManager.Instance.can == 0)
            {
                GameManager.Instance.GameOver();
            }

        }
    }


}

