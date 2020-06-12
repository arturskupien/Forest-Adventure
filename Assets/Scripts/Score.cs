using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI gemNum;
    GameManager gameManager;

    private void Awake()
    {

    }
    void Update()
    {
        gemNum.SetText(GameManager.pickedGems.ToString());
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Collectibles"))
        {
            //Debug.Log("Diamond get into my sphere of influence");
            PickUp(collider);
        }
    }

    void PickUp(Collider2D  collider)
    {
        Destroy(collider.gameObject);


        GameManager.pickedGems++;
    }

}
