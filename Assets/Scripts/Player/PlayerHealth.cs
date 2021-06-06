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
    public PlayerScriptObject Savepoint;

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
        switch(collision.gameObject.tag)
        {
            case "River":
            case "Enemy":
            case "Spikes":
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
                break;
        }
        _animator.SetBool(isDying, isDied);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SavePoint"))
        {
            Savepoint.setCheckpointPosition(collision.gameObject.name);
        }
    }

    void DestroyLife(string tag, int life)
    {
        GameObject[] hearts = GameObject.FindGameObjectsWithTag(tag);
        Destroy(hearts[life]);
    }

    void GameOver()
    {
        CI_GameOver.enabled = true;
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
        Savepoint.resetCheckpointPosition();
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
        this.transform.position = Savepoint.getCheckpointPosition();
        this.GetComponent<SpriteRenderer>().flipY = false;
    }

}
