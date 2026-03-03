using UnityEngine;
using System.Collections;
using TMPro;

using UnityEngine;
using TMPro;
using System.Collections;

public class Character : MonoBehaviour
{
    // =========================
    // SISTEMA DE TURNOS
    // =========================
    public bool[] turnos = new bool[4];
    public static int contadorTurnos = 0;

    // =========================
    // ANIMACIONES
    // =========================
    public Animator[] ani;
    public Animator[] aniBoss;
    public int contaAni = 0;
    public Animator Magia;
    private Animator itemani;
    private Animator itemanif;

    // =========================
    // PANELES UI
    // =========================
    private GameObject comandos;
    private GameObject PanelMagia;
    private GameObject MagiaAni;
    private GameObject item;
    private GameObject PanelChar;
    private GameObject PanelItem;
    private GameObject Todos;
    private GameObject BotonLimite;

    // =========================
    // CONTROL DE ESTADOS
    // =========================
    private bool abi;
    private bool abiItem;
    private bool abiCharac;
    private bool EsMagia = false;
    public bool primera = true;
    private bool control = true;
    private bool controlBoss = false;

    // =========================
    // ITEM SELECCIONADO
    // =========================
    private bool espocion;
    private bool eseter;
    private bool esfenix;
    private bool escura = false;

    // =========================
    // PERSONAJES Y JEFES
    // =========================
    public GameObject[] playerObjects;
    public GameObject[] BossesObjects;
    public Player[] jugador;

    // =========================
    // CONTROL VARIOS
    // =========================
    private GameObject itema2;
    private int numRandom;
    private bool estAnimacion = false;
    public bool inputBoton = false;

    // =========================
    // TEXTO MAGIAS
    // =========================
    TextMeshProUGUI tecla1;
    TextMeshProUGUI tecla2;
    TextMeshProUGUI magia1;
    TextMeshProUGUI magia2;

    // =========================
    // START
    // =========================
    void Start()
    {
        turnos[contadorTurnos] = true;

        playerObjects = GameObject.FindGameObjectsWithTag("Player");
        BossesObjects = GameObject.FindGameObjectsWithTag("Boss");

        ani = new Animator[playerObjects.Length];
        jugador = new Player[playerObjects.Length];
        aniBoss = new Animator[BossesObjects.Length];

        for (int i = 0; i < playerObjects.Length; i++)
        {
            ani[i] = playerObjects[i].GetComponent<Animator>();
            jugador[i] = playerObjects[i].GetComponent<Player>();
        }

        for (int i = 0; i < BossesObjects.Length; i++)
        {
            aniBoss[i] = BossesObjects[i].GetComponent<Animator>();
        }

        BotonLimite = GameObject.Find("Fondo_Limite");
        PanelItem = GameObject.Find("ItemComSelect ");
        Todos = GameObject.Find("TodosSelec");
        PanelChar = GameObject.Find("MagiasComSelect");
        item = GameObject.Find("Item");
        itemanif = item.GetComponent<Animator>();
        comandos = GameObject.Find("Comandos");
        PanelMagia = GameObject.Find("MagiasCom");
        MagiaAni = GameObject.Find("Magia");

        tecla1 = GameObject.Find("Tecla1").GetComponent<TextMeshProUGUI>();
        tecla2 = GameObject.Find("Tecla2").GetComponent<TextMeshProUGUI>();
        magia1 = GameObject.Find("Magia1").GetComponent<TextMeshProUGUI>();
        magia2 = GameObject.Find("Magia2").GetComponent<TextMeshProUGUI>();

        PanelItem.SetActive(false);
        Todos.SetActive(false);
        PanelChar.SetActive(false);
        comandos.SetActive(false);
        PanelMagia.SetActive(false);
        BotonLimite.SetActive(false);
    }

    // =========================
    // UPDATE
    // =========================
    void Update()
    {
        if (contadorTurnos == 2)
        {
            control = false;
            controlBoss = true;
        }

        turnos[contadorTurnos] = true;

        if (control)
        {
            EjecutarAnimacion();

            if (Input.GetKeyDown(KeyCode.A) && !inputBoton)
            {
                control = false;
                comandos.SetActive(false);
                AtaqueAni();
                inputBoton = true;
            }

            if (Input.GetKeyDown(KeyCode.D) && !inputBoton)
            {
                control = false;
                comandos.SetActive(false);
                DefensaAni();
                inputBoton = true;
            }

            if (Input.GetKeyDown(KeyCode.M) && !inputBoton)
            {
                ActivarPanelMagia();
                inputBoton = true;
            }

            if (Input.GetKeyDown(KeyCode.I) && !inputBoton)
            {
                ActivarPanelItem();
                inputBoton = true;
            }
        }

        if (controlBoss && !estAnimacion)
        {
            numRandom = Random.Range(0, 2);

            if (numRandom == 0)
                aniBoss[0].SetTrigger("atack1");
            else
                aniBoss[0].SetTrigger("atack2");

            estAnimacion = true;
            StartCoroutine(EsperarJefe(aniBoss[0]));
        }

        Destroy(itema2, 3f);
    }

    // =========================
    // ACCIONES
    // =========================
    public void EjecutarAnimacion()
    {
        if (turnos[contadorTurnos])
        {
            AnimatorStateInfo stateInfo = ani[contaAni].GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Acercarse") && stateInfo.normalizedTime >= 1.0f)
            {
                comandos.SetActive(true);
                inputBoton = false;
            }
            else if (primera)
            {
                ani[contaAni].SetTrigger("Acercar");
                primera = false;
            }
        }
    }

    public void AtaqueAni()
    {
        ani[contaAni].SetTrigger("Ataque");
        StartCoroutine(EsperarTurnos(ani[contaAni]));
    }

    public void DefensaAni()
    {
        ani[contaAni].SetTrigger("Defender");
        StartCoroutine(EsperarTurnos(ani[contaAni]));
    }

    public void ActivarPanelMagia()
    {
        PanelMagia.SetActive(true);
        abi = true;
        EsMagia = true;
    }

    public void ActivarPanelItem()
    {
        PanelItem.SetActive(true);
        abiItem = true;
        EsMagia = false;
    }

    // =========================
    // COROUTINES
    // =========================
    private IEnumerator EsperarTurnos(Animator anim)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float duracion = stateInfo.length / stateInfo.speed;

        yield return new WaitForSeconds(duracion + 1f);

        turnos[contadorTurnos] = false;
        contaAni++;
        contadorTurnos++;
        primera = true;
        control = true;
        EsMagia = false;
    }

    private IEnumerator EsperarJefe(Animator anim)
    {
        controlBoss = false;

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float duracion = stateInfo.length / stateInfo.speed;

        yield return new WaitForSeconds(duracion);

        turnos[contadorTurnos] = false;
        contaAni = 0;
        contadorTurnos = 0;
        primera = true;
        control = true;
        controlBoss = false;
        estAnimacion = false;
    }
}