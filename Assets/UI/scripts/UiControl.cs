using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiControl : MonoBehaviour
{
    public static UiControl instace;
    public AudioClip startGame;
    public AudioClip level;
    public AudioClip gameOver;
    public AudioClip pause;

    private Animator animator;
    private void Awake()
    {
        instace = this;
    }
    private void OnEnable()
    {
        Life.alive += Dead;
    }
    private void OnDisable()
    {
        Life.alive -= Dead;
    }
    private void Start()
    {
        GetComponent<AudioSource>().volume = .1f;
        GetComponent<AudioSource>().clip = startGame;
        GetComponent<AudioSource>().Play();
        animator = GetComponent<Animator>();
        Player.instance.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Player.instance.gameObject.GetComponent<Life>().wait = false;
    }

    private void Update()
    {
        if (!animator.GetBool("start"))
        {
            Player.instance.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Player.instance.gameObject.GetComponent<Life>().wait = false;
        }
    }
    public void Reload()
    {
        SceneManager.LoadScene("Main");
        animator.Play("StartGameIn");
    }
    public void StartGame()
    {
        GetComponent<AudioSource>().clip = level;
        GetComponent<AudioSource>().Play();
        animator.SetBool("start", true);
        Player.instance.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        animator.SetBool("record", false);
        Player.instance.gameObject.GetComponent<Life>().wait = true;
    }

    public void Dead()
    {
        GetComponent<AudioSource>().clip = gameOver;
        GetComponent<AudioSource>().Play();
        Score.instance.Order();
        SaveLoadSys.SaveScore(Score.instance.data);
        animator.SetBool("start", false);
        animator.SetBool("record", false);
        animator.SetBool("outGame", true);
        animator.SetBool("dead", true);
    }
    public void Pause()
    {
        GetComponent<AudioSource>().clip = pause;
        GetComponent<AudioSource>().Play();
        Progress.instance.Stop();
        Controller.instance.Stop();
        RatsAttack.instance.Stop();
        animator.SetBool("outGame", true);
        animator.SetBool("dead", false);
        animator.SetBool("pause", true);
    }
    public void Release()
    {

        GetComponent<AudioSource>().clip = level;
        GetComponent<AudioSource>().Play();
        Progress.instance.Play();
        Controller.instance.Release();
        RatsAttack.instance.Play();
        animator.SetBool("outGame", false);
        animator.SetBool("pause", false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Records()
    {
        Score.instance.Order();
        animator.SetBool("record", true);
    }
}
