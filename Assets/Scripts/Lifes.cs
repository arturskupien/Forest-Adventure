using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lifes : MonoBehaviour
{
    public TextMeshProUGUI text;
    GameManager gameManager;
    public static bool reallyDead;
    public static bool isDead;
    public Animator animator;
    PlayerMovement playerMovement = new PlayerMovement();

    void Start()
    {
        isDead = false;
        reallyDead = false;
    }

    void Update()
    {
        text.SetText(GameManager.lifes.ToString());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("Death"))
        {

            LifesCount();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death"))
        {

            LifesCount();
        }
    }

    private async void LifesCount()
    {
        if (GameManager.lifes > 0) 
        {
            isDead = true;
            GameManager.lifes--;
            animator.SetBool("isDead", true);
            await Task.Delay(400);
            isDead = false;
            animator.SetBool("isDead", false);
        }
        else
        {
            isDead = true;
            reallyDead = true;
            animator.SetBool("isDead", true);
            await Task.Delay(1000);
            SceneManager.LoadScene("GameOver");
        }
    }

}