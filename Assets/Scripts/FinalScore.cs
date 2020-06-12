using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI gemNum;
    GameManager gameManager;
    
    void Update()
    {
        gemNum.SetText(GameManager.pickedGems.ToString() + " out of 7");
    }
}
