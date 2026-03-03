using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Boss : MonoBehaviour
{
    // estadisticas Boss
    public float ataque;
    public float critical;
    public float Rango1;
    public float Rango2;
    public float vida;

    //Jugadores
    private GameObject[] jugadores;
    public LinkedList<Player> players;
    public Animator[] aniPlayers;
    public Player[] PlayCod;
    private Animator aniBoss;

    //info Daño
    private TextMeshProUGUI damageInfo;
    private Animator DamageAni;
    public GameObject FondoDamage;

    //posiciones
    private int pos = 0;
    private int nRandom;
    private int posList;

    //fin del jefe
    private Animator transition;
    public string escena;

    public AudioSource[] musica;
    private string nombreEscena;
    public GameObject[] musicas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

        players = new LinkedList<Player>();
        jugadores = GameObject.FindGameObjectsWithTag("Player");
        aniBoss = gameObject.GetComponent<Animator>();
        aniPlayers = new Animator[jugadores.Length];
        PlayCod= new Player[jugadores.Length];
        transition = GameObject.Find("Fade").GetComponent<Animator>();

        foreach (GameObject obj in jugadores)
        {
            players.AddLast(obj.GetComponent<Player>());
            aniPlayers[pos] = obj.GetComponent<Animator>();
            PlayCod[pos] = obj.GetComponent<Player>();
            pos++;

        }

        FondoDamage = GameObject.FindGameObjectWithTag("Damage");
        DamageAni=FondoDamage.GetComponent<Animator>();
        damageInfo =FondoDamage.GetComponentInChildren<TextMeshProUGUI>();

        //FondoDamage.SetActive(false);

        for (int i = 0; i < musica.Length; i++)
        {
            musica[i].gameObject.SetActive(false);
        }

        musica[GameManager.primeraBatalla].gameObject.SetActive(true);
        musicas = GameObject.FindGameObjectsWithTag("Musica");

        if (SceneManager.GetActiveScene().name == "Batalla")
        {

            if (musicas.Length > 1)
            {
                GameObject lastObject = musicas[musicas.Length - 1];
                Destroy(lastObject);
            }

            DontDestroyOnLoad(musica[GameManager.primeraBatalla]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.vida <= 0)
        {
            /*
            GameManager.GuardarPartida();
            */

            StartCoroutine(SceneLoad(escena));
        }

    }

    public void Atacar1()
    {
        //inteligencia artificial del jefe

        critical = 0;
        posList = 0;
        LinkedListNode<Player> currentNode = players.First;

        float RandomCritik= UnityEngine.Random.Range(0f, 1f);
        if (RandomCritik <= 0.70f) critical = 0;
        else critical = UnityEngine.Random.Range(Rango1, Rango2);

        foreach (Player ActualPlayer in players)
        {
            Player nextPlayer = currentNode.Next?.Value;

            if (nextPlayer != null)
            {
                if (ActualPlayer.vida<=0) nextPlayer.RecibirDano(posList, critical);
                else if(nextPlayer.vida<=0) ActualPlayer.RecibirDano(posList, critical);
                else if (ActualPlayer.vida == nextPlayer.vida && ActualPlayer.Defensa == nextPlayer.Defensa)
                {
                    Debug.Log("1");
                    nRandom = UnityEngine.Random.Range(0, jugadores.Length);

                    PlayCod[nRandom].RecibirDano(nRandom, critical);

                }
                else if (ActualPlayer.vida == nextPlayer.vida && ActualPlayer.Defensa != nextPlayer.Defensa)
                {
                    Debug.Log("2");
                    if (ActualPlayer.Defensa == false)
                    {
                        Debug.Log("entra2");
                        ActualPlayer.RecibirDano(posList, critical);
                    }
                    else nextPlayer.RecibirDano(posList, critical);


                }
                else if (ActualPlayer.vida != nextPlayer.vida && ActualPlayer.Defensa == nextPlayer.Defensa)
                {
                    Debug.Log("3");
                    if (ActualPlayer.vida < nextPlayer.vida) ActualPlayer.RecibirDano(posList, critical);
                    else nextPlayer.RecibirDano(posList, critical);

                }
                else if (ActualPlayer.vida != nextPlayer.vida && ActualPlayer.Defensa != nextPlayer.Defensa)
                {
                    Debug.Log("4");
                    if (ActualPlayer.vida < nextPlayer.vida)
                    {
                        if (!ActualPlayer.Defensa)ActualPlayer.RecibirDano(posList, critical);
                        else nextPlayer.RecibirDano(posList, critical);
                    }
                    else if (ActualPlayer.vida > nextPlayer.vida)
                    {
                        if (!nextPlayer.Defensa)nextPlayer.RecibirDano(posList, critical);
                        else ActualPlayer.RecibirDano(posList, critical);
                    }

                }
            }
            currentNode = currentNode.Next;

            if (posList > players.Count)
            {
                posList = players.Count;
            }
            else posList++;
        
        }
    }
    public void Atacar2()
    {
        //aqui unicamente recorre el array de personajes para atacarllos a todos

        int num = 0;
        critical = 0;
        LinkedListNode<Player> currentNode = players.First;

        float RandomCritik = UnityEngine.Random.Range(0f, 1f);
        if (RandomCritik <= 0.70f) critical = 0;
        else critical = UnityEngine.Random.Range(Rango1, Rango2);

        foreach (Player ActualPlayer in players)
        {
            Player nextPlayer = currentNode.Next?.Value;

            if(ActualPlayer.vida<=0) nextPlayer.RecibirDano(num, critical);
            else if(nextPlayer.vida<=0) ActualPlayer.RecibirDano(num, critical);
            else ActualPlayer.RecibirDano(num,critical);

            num++;
        }

    }

    public void RecibirDanoBoss(float AtaCrick)
    {
        if (this.vida <= 0)
        {
            Debug.Log("Esta muerto");
        }
        else
        {
            aniBoss.Play("Daño");

            this.vida -= AtaCrick;

            if (this.vida <= 0) this.vida = 0;
        }

        FondoDamage.SetActive(true);

        DamageAni.SetTrigger("ActiveDamage");

        damageInfo.text = (int) AtaCrick+"";

        Invoke("DesacInfoDamage", 0.27f);
    }


    public void DesacInfoDamage()
    {
        FondoDamage.SetActive(false);
    }

    public IEnumerator SceneLoad(string escena)
    {
        //aqui se controla cuando el jefe muere, asi la variable se modificara y cambiara la musica, los objetos y cambiara de escena
        Time.timeScale = 1;
        aniBoss.Play("AniMuerte");
        yield return new WaitForSeconds(0.20f);
        transition.SetTrigger("StartTransition");

        if (SceneManager.GetActiveScene().name == "Batalla")
        {
            int index = GameManager.primeraBatalla;

            if (index >= musica.Length)
            {
                index = musica.Length - 1;
            }

            if (index >= 0 && musica[index] != null)
            {
                Destroy(musica[index].gameObject);
            }
        }

        yield return new WaitForSeconds(0.50f);
        GameManager.primeraBatalla++;
        if (GameManager.primeraBatalla == 1) Items.cantidad = 10;
        if (GameManager.primeraBatalla == 2) Items.cantidad = 15;
        SceneManager.LoadScene(escena);
    }


}
