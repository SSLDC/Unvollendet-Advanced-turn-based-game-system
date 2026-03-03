using System;
using System.ComponentModel;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // --- Estadísticas del personaje ---
    public int id;               // ID del personaje
    public float ataque;         // Daño base
    public float critical;       // Daño crítico calculado
    public float Rango1;         // Rango mínimo de crítico
    public float Rango2;         // Rango máximo de crítico
    public int Numdefensa;       // Defensa base
    public bool Defensa;         // Flag si está defendiendo
    public float vida;           // Vida actual
    public float vidaMax;        // Vida máxima
    public float magia;          // PM actual
    public float magiaMax;       // PM máxima
    public float limite;         // Barra de límite actual
    public float limitMax;       // Límite máximo
    public bool muerto = false;  // Si el personaje está muerto
    private float limiteAtack;   // Daño del límite

    // --- Animaciones ---
    public Animator ani;         // Animator del personaje

    // --- Interfaz ---
    public GameObject[] barraVida;    // GameObjects de barra de vida
    public Image[] BarrasPV;          // Componentes Image de barra de vida

    public GameObject[] barraMagia;   // GameObjects de barra de PM
    public Image[] BarrasPM;          // Componentes Image de barra de PM

    public GameObject[] barraLimit;   // GameObjects de barra de límite
    public Image[] BarrasLM;          // Componentes Image de barra de límite

    // --- Jefes ---
    public GameObject[] Bosses;       // GameObjects de los jefes
    public Boss[] jefes;              // Componentes Boss

    // --- Control interno ---
    public bool EstaLimite = false;   // Flag si está listo el límite
    private bool debil = false;       // Flag si está débil
    private float danoAttack;         // Daño calculado para ataque

    // --- Start: Inicializa todo ---
    void Start()
    {
        // Ajuste de stats según la batalla
        if (GameManager.primeraBatalla == 1)
        {
            ataque += 50;
            Rango1 += 50;
            Rango2 += 50;
            Numdefensa += 50;
            vida += 500;
            vidaMax += 500;
        }
        if (GameManager.primeraBatalla == 2)
        {
            ataque += 100;
            Rango1 += 100;
            Rango2 += 100;
            Numdefensa += 100;
            vida += 1000;
            vidaMax += 1000;
        }

        // Encuentra los jefes en escena y asigna el Animator
        Bosses = GameObject.FindGameObjectsWithTag("Boss");
        jefes = new Boss[Bosses.Length];
        ani = gameObject.GetComponent<Animator>();

        // Encuentra las barras de interfaz
        barraVida = GameObject.FindGameObjectsWithTag("BarraVida");
        barraMagia = GameObject.FindGameObjectsWithTag("BarraPM");
        barraLimit = GameObject.FindGameObjectsWithTag("BarraLimite");

        // Asignamos las imágenes a cada barra
        BarrasPV = new Image[barraVida.Length];
        BarrasPM = new Image[barraMagia.Length];
        BarrasLM = new Image[barraLimit.Length];

        for (int i = 0; i < barraVida.Length; i++)
            BarrasPV[i] = barraVida[i].GetComponent<Image>();

        for (int i = 0; i < barraMagia.Length; i++)
            BarrasPM[i] = barraMagia[i].GetComponent<Image>();

        for (int i = 0; i < barraLimit.Length; i++)
        {
            BarrasLM[i] = barraLimit[i].GetComponent<Image>();
            BarrasLM[i].fillAmount = limite;
        }

        for (int i = 0; i < Bosses.Length; i++)
            jefes[i] = Bosses[i].GetComponent<Boss>();
    }

    // --- Update: se ejecuta cada frame ---
    void Update()
    {
        // Control de estado muerto
        if (vida <= 0 && !muerto)
        {
            ani.SetBool("Muerto", true);
            muerto = true;
        }
        else if (vida > 0 && muerto)
        {
            ani.SetBool("Muerto", false);
            muerto = false;
        }

        // Control de estado débil (vida < 40%)
        if (vida <= (vidaMax * 0.40f) && debil && !muerto)
        {
            ani.SetBool("Debil", true);
            debil = false;
        }
        else if (vida > (vidaMax * 0.40f) && !debil)
        {
            ani.SetBool("Debil", false);
            debil = true;
        }
    }

    // --- Ataque normal ---
    public void Atacar()
    {
        float nRandom = Random.Range(0f, 1f);

        if (nRandom >= 0.7f)
        {
            critical = Random.Range(Rango1, Rango2);
            danoAttack = critical; // Ataque crítico
        }
        else danoAttack = ataque;

        // Inflige daño al jefe según la batalla actual
        jefes[GameManager.primeraBatalla].RecibirDanoBoss(danoAttack);
    }

    // --- Activar defensa ---
    public void defender()
    {
        Defensa = true;
    }

    // --- Recibir daño ---
    public void RecibirDano(int num, float cri)
    {
        if (vida <= 0)
        {
            Debug.Log("Esta muerto");
            return;
        }

        ani.Play("Daño");

        float ataqueProbabilidad = jefes[GameManager.primeraBatalla].ataque + cri;

        if (Defensa) ataqueProbabilidad -= Numdefensa;

        vida -= ataqueProbabilidad;
        if (vida <= 0) vida = 0;

        // Actualiza barra de vida
        BarrasPV[id].fillAmount = vida / vidaMax;

        // Incrementa barra de límite
        limite += Random.Range(10, 15);
        if (limite >= limitMax)
        {
            limite = limitMax;
            EstaLimite = true;
        }

        BarrasLM[id].fillAmount = limite / limitMax;

        Defensa = false;
    }

    // --- Reducir PM ---
    public void ReducirPM(int num, float cos)
    {
        if (magia <= 0)
        {
            Debug.Log("No tienes suficiente PM");
            return;
        }

        magia -= cos;
        if (magia <= 0) magia = 0;

        BarrasPM[id].fillAmount = magia / magiaMax;
    }

    // --- Recuperar vida ---
    public void RecuperacionVidaSelf(int num, float recu)
    {
        if (vida <= 0) return;

        vida += recu;
        if (vida > vidaMax) vida = vidaMax;

        BarrasPV[id].fillAmount = vida / vidaMax;
    }

    // --- Recuperar PM ---
    public void RecuperacionPMOther(int num, float recu)
    {
        if (vida <= 0) return;

        magia += recu;
        if (magia > magiaMax) magia = magiaMax;

        BarrasPM[id].fillAmount = magia / magiaMax;
    }

    // --- Ataque límite ---
    public void Limite()
    {
        limiteAtack = ataque * 5;

        limite = 0;
        BarrasLM[id].fillAmount = 0;

        jefes[GameManager.primeraBatalla].RecibirDanoBoss(limiteAtack);
    }

    // --- Revivir personaje ---
    public void revivir(int num)
    {
        if (vida > 0) return;

        vida += vidaMax / 5;
        BarrasPV[id].fillAmount = vida / vidaMax;
    }
}