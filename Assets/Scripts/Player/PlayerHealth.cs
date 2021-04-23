using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool IsOnRiver = false;
    public int Lifes = 3;
    public int test = 1;
    public GameObject GameOverText;
    private Vector3 RespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("River"))
        {

            if (Lifes == 1)
            {
                GameOverText.SetActive(true);
                GameOver();
            }
            else {
                GetComponent<Collider2D>().enabled = false;
                this.GetComponent<SpriteRenderer>().flipY = true;
                this.GetComponent<Collider2D>().enabled = false;
                Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
                this.transform.position = this.transform.position + movement * Time.deltaTime;
                Lifes--;
                DestroyLife("Life", Lifes);
                this.transform.position = new Vector3(-18.1f, 0.46f, 0);
                //RestartScene(this.transform.position);
                this.GetComponent<SpriteRenderer>().flipY = false;
            }

            //IsOnRiver = true;
            //Destroy(collision.gameObject);
        }else if(collision.gameObject.CompareTag("Enemy") && collision.gameObject.CompareTag("Head") == false)
            {
                
                GetComponent<Collider2D>().enabled = false;
                this.GetComponent<SpriteRenderer>().flipY = true;
                this.GetComponent<Collider2D>().enabled = false;
                Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
                this.transform.position = this.transform.position + movement * Time.deltaTime;
                Lifes--;
                DestroyLife("Life", Lifes);
                this.transform.position = new Vector3(-18.1f, 0.46f, 0);
                //RestartScene(this.transform.position);
                this.GetComponent<SpriteRenderer>().flipY = false;
            }
    }

    //public void RestartScene()
    //{
    //    new WaitForSeconds();
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    void DestroyLife(string tag, int life)
    {

        GameObject[] hearts = GameObject.FindGameObjectsWithTag(tag);
        Destroy(hearts[life]);
    }

    void GameOver()
    {
                GetComponent<Collider2D>().enabled = false;
                this.GetComponent<SpriteRenderer>().flipY = true;
                this.GetComponent<Collider2D>().enabled = false;
                Vector3 movement = new Vector3(Random.Range(40, 70), Random.Range(-40, 40), 0f);
                this.transform.position = this.transform.position + movement * Time.deltaTime;
                Lifes--;

        StartCoroutine("Restart");
    }
    
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {

    }
}