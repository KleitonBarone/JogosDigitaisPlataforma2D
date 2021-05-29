using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int isDying = Animator.StringToHash("isDying");
    private Animator _animator = null;
    public bool IsOnRiver = false;
    public int Lifes = 3;
    public GameObject Canvas;
    public Image CI_GameOver;
    private Vector3 RespawnPoint;
 
    public bool isDied = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameOverText.SetActive(false);
        CI_GameOver.enabled = false;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("River"))
        {
            isDied = true;
            if (Lifes == 1)
            {
                GameOver();
            }
            else
            {

                if (Lifes > 0)
                {
                    OnPlayerDeath();
                }

            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            isDied = true;
            if (Lifes == 1)
            {
                GameOver();
            }
            else
            {
                OnPlayerDeath();
            }
        }
        else if (collision.gameObject.CompareTag("Spikes"))
        {
            isDied = true;
            if (Lifes == 1)
            {
                GameOver();
            }
            else
            {
                OnPlayerDeath();
            }
        }
        _animator.SetBool(isDying, isDied);


    }

    void DestroyLife(string tag, int life)
    {

        GameObject[] hearts = GameObject.FindGameObjectsWithTag(tag);
        Destroy(hearts[life]);
    }

    void GameOver()
    {
        CI_GameOver.enabled = true;
        //GetComponent<Collider2D>().enabled = false;
        ////this.GetComponent<SpriteRenderer>().flipY = true;
        //this.GetComponent<Collider2D>().enabled = false;
        //Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
        //this.transform.position = this.transform.position + movement * Time.deltaTime;
        OnPlayerDeath();

        StartCoroutine(Restart());
    }

    void OnPlayerDeath()
    {
        Lifes--;
        DestroyLife("Life", Lifes);
        StartCoroutine(BacktoCheckpoint());
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        isDied = false;
        _animator.SetBool(isDying, isDied);
        GameManager.Instance.LoadLevel("MainScreen");

    }

    IEnumerator BacktoCheckpoint()
    {
        yield return new WaitForSeconds(2);
        isDied = false;
        _animator.SetBool(isDying, isDied);
        this.transform.position = new Vector3(-18.1f, 0.46f, 0);
        this.GetComponent<SpriteRenderer>().flipY = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
