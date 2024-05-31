using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;


public class SymbolController : MonoBehaviour
{    
    public TextMeshProUGUI islem;
    public int sonuc;
    public TextMeshPro sayiText;
    float sayac = 5f;
    public int dogruCevap;
    public static SymbolController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GenerateProblem();
    }
    private void Update()
    {
        sayac -= Time.deltaTime;
        if (sayac < 0f)
        {
            islem.text = "";
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Addition")) // Oyuncu sembole temas ettiðinde
        {           
            GenerateProblem();
        }
    }

    
    public void GenerateProblem()
    {
        
        sayac = 5f; // Problem ekranda kalacak süreyi 5 saniye olarak ayarla

        int num1 = Random.Range(1, 6);
        int ciftSayi1 = num1 * 2;
        int num2 = Random.Range(1, 6);
        int ciftSayi2 = num2 * 2;

        //ciftSayi1'in her zaman ciftSayi2'den büyük olmasýný saðla
        if (ciftSayi1 < ciftSayi2)
        {
            int temp = ciftSayi1;
            ciftSayi1 = ciftSayi2;
            ciftSayi2 = temp;
        }

        int operation = Random.Range(0, 3);
        int num3 = Random.Range(1, 6);
        int ciftSayi3 = num3 ;
        int num4 = Random.Range(1, 6);
        int ciftSayi4 = num4 * 2;

        //ciftSayi3'ün her zaman ciftSayi4'ten büyük olmasýný saðla
        if (ciftSayi3 < ciftSayi4)
        {
            int temp = ciftSayi3;
            ciftSayi3 = ciftSayi4;
            ciftSayi4 = temp;
        }


        switch (operation)
        {
            case 0:
                islem.text = $"{ciftSayi1} + {ciftSayi2} = ?";
                dogruCevap = ciftSayi1 + ciftSayi2;
                break;
            case 1:
                islem.text = $"{ciftSayi1} - {ciftSayi2} = ?";
                dogruCevap = ciftSayi1 - ciftSayi2;
                break;
            case 2:
                islem.text = $"{ciftSayi3} * {ciftSayi4} = ?";
                dogruCevap = ciftSayi3 * ciftSayi4;
                break;
            
        }
    }
}
