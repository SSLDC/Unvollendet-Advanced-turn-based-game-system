using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
/*
GameManager controla todo el sistema de combate:
- Sistema de turnos
- Animaciones
- Paneles UI
- Magias y objetos
- Ataques límite
- Control de muerte y fin de partida
*/

public class GameManager : MonoBehaviour
{
    // ================== SISTEMA DE TURNOS ==================
    public bool[] turnos = new bool[3];
    public static int contadorTurnos = 0;
    public static int primeraBatalla = 0;

    // ================== ANIMACIONES ==================
    public Animator[] ani;
    public Animator[] aniBoss;
    public int contaAni = 0;
    public Animator Magia;
    private Animator itemani;
    private Animator itemanif;

    // ================== SELECCIÓN ==================
    private int selecCharacter;
    private int contarMuerto;

    // ================== PANELES UI ==================
    private GameObject comandos;
    private GameObject PanelMagia;
    private GameObject MagiaAni;
    private GameObject item;
    private GameObject PanelChar;
    private GameObject PanelItem;
    private GameObject Todos;
    private GameObject BotonLimite;
    private GameObject panel;
    private GameObject tutorial;

    // ================== VARIABLES DE CONTROL ==================
    private bool abi;
    private bool abiItem;
    private bool abiCharac;
    private bool EsMagia = false;
    public bool primera = true;
    private bool control = true;
    private bool controlBoss = false;
    private bool terminado = false;
    bool turnoFinalizado = false;
    bool SoloEstavez = false;
    private bool estAnimacion = false;
    public bool inputBoton = false;

    // ================== ITEMS ==================
    private bool espocion;
    private bool eseter;
    private bool esfenix;
    private bool escura = false;

    // ================== PERSONAJES Y JEFE ==================
    public GameObject[] playerObjects;
    public GameObject[] BossesObjects;
    public Player[] jugador;
    public Magias Skills;

    // ================== CONTROL EXTRA ==================
    private GameObject itema2;
    public int contaT;
    public int numT;
    public static bool ActivaTodos = false;
    private int numRandom;
    public int com;

    // ================== LIMITES (VIDEOS) ==================
    public GameObject[] limitesObj;
    public VideoPlayer[] limitesVideos;

    // ================== UI TEXTO ==================
    TextMeshProUGUI tecla1;
    TextMeshProUGUI tecla2;
    TextMeshProUGUI magia1;
    TextMeshProUGUI magia2;
    public static GameObject lienzoInfo;
    public static TextMeshProUGUI infoestado;
    public TextMeshProUGUI Tema_musica;

    private bool desacTuto;

    // ================== START ==================
    void Start()
    {
        // Inicializo todas las referencias necesarias para el combate
        contadorTurnos = 0;
        turnos[contadorTurnos] = true;

        playerObjects = GameObject.FindGameObjectsWithTag("Player");
        BossesObjects = GameObject.FindGameObjectsWithTag("Boss");
        limitesObj = GameObject.FindGameObjectsWithTag("Limite");

        ani = new Animator[playerObjects.Length];
        jugador = new Player[playerObjects.Length];
        aniBoss = new Animator[BossesObjects.Length];
        limitesVideos = new VideoPlayer[limitesObj.Length];

        for (int i = 0; i < playerObjects.Length; i++)
        {
            ani[i] = playerObjects[i].GetComponent<Animator>();
            jugador[i] = playerObjects[i].GetComponent<Player>();
        }

        for (int i = 0; i < BossesObjects.Length; i++)
        {
            aniBoss[i] = BossesObjects[i].GetComponent<Animator>();
            BossesObjects[i].SetActive(false);
        }

        for (int i = 0; i < limitesObj.Length; i++)
        {
            limitesVideos[i] = limitesObj[i].GetComponent<VideoPlayer>();
            limitesVideos[i].gameObject.SetActive(false);
        }

        // Activo solo el jefe correspondiente
        BossesObjects[primeraBatalla].SetActive(true);
        com = primeraBatalla;

        tutorial = GameObject.Find("Tutorial");
        panel = GameObject.Find("MuertoPanel");
        lienzoInfo = GameObject.Find("LinezoInfo");
        infoestado = GameObject.Find("InfoEstado").GetComponent<TextMeshProUGUI>();
        Skills = FindAnyObjectByType<Magias>();
        BotonLimite = GameObject.Find("Fondo_Limite");
        PanelItem = GameObject.Find("ItemComSelect ");
        Todos = GameObject.Find("TodosSelec");
        PanelChar = GameObject.Find("MagiasComSelect");
        item = GameObject.FindGameObjectWithTag("ObjjItem");
        itemanif = item.GetComponent<Animator>();
        comandos = GameObject.Find("Comandos");
        PanelMagia = GameObject.Find("MagiasCom");
        MagiaAni = GameObject.Find("Magia");

        tecla1 = GameObject.Find("Tecla1").GetComponent<TextMeshProUGUI>();
        tecla2 = GameObject.Find("Tecla2").GetComponent<TextMeshProUGUI>();
        magia1 = GameObject.Find("Magia1").GetComponent<TextMeshProUGUI>();
        magia2 = GameObject.Find("Magia2").GetComponent<TextMeshProUGUI>();

        lienzoInfo.SetActive(false);
        PanelItem.SetActive(false);
        Todos.SetActive(false);
        PanelChar.SetActive(false);
        comandos.SetActive(false);
        PanelMagia.SetActive(false);
        BotonLimite.SetActive(false);
        panel.SetActive(false);
        tutorial.SetActive(false);

        desacTuto = true;
        Time.timeScale = 1;

        if (primeraBatalla == 0)
        {
            Tema_musica.text = "Tema: Let Me Carve Your Way";
            desacTuto = false;
            Invoke("ActivaTutorial", 0.30f);
        }
        if (primeraBatalla == 1)
            Tema_musica.text = "Tema: Requiem";
        if (primeraBatalla == 2)
            Tema_musica.text = "Tema: Six Black Heavens Guns";
    }

    // ================== UPDATE ==================
    void Update()
    {
        // Control principal del combate en cada frame
        if (!desacTuto) return;

        ControlMuerte();

        if (contadorTurnos >= turnos.Length - 1)
        {
            control = false;
            controlBoss = true;
            contadorTurnos = turnos.Length - 1;
        }

        // ================== TURNO JUGADOR ==================
        if (control)
        {
            jugador[contadorTurnos].Defensa = false;
            EjecutarAnimacion();
        }

        // ================== TURNO JEFE ==================
        if (controlBoss && !estAnimacion)
        {
            inputBoton = true;

            numRandom = Random.Range(0, 2);

            if (numRandom == 0)
                aniBoss[primeraBatalla].SetTrigger("atack1");
            else
                aniBoss[primeraBatalla].SetTrigger("atack2");

            estAnimacion = true;
            StartCoroutine(EsperarJefe(aniBoss[primeraBatalla]));
        }

        Destroy(itema2, 3f);
    }

    // ================== CONTROL ANIMACIÓN INICIAL ==================
    public void EjecutarAnimacion()
    {
        // Hace que el personaje se acerque antes de mostrar comandos
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
                control = true;
            }
        }
    }

    // ================== ESPERAR FIN DE TURNO ==================
    private IEnumerator EsperarTurnos(Animator anim)
    {
        yield return new WaitForEndOfFrame();

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float animDuration = stateInfo.length / stateInfo.speed;

        if (animDuration <= 0)
            animDuration = 1f;

        yield return new WaitForSeconds(animDuration + 1f);

        turnos[contadorTurnos] = false;
        contaAni++;
        contadorTurnos = (contadorTurnos + 1) % turnos.Length;

        primera = true;
        control = true;
        EsMagia = false;
        terminado = false;
        ActivaTodos = false;
    }

    // ================== TURNO JEFE ==================
    private IEnumerator EsperarJefe(Animator anim)
    {
        // Espera a que termine la animación del jefe
        yield return new WaitForEndOfFrame();

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float animDuration = stateInfo.length / stateInfo.speed;

        if (animDuration <= 0)
            animDuration = 1f;

        yield return new WaitForSeconds(animDuration);

        turnos[contadorTurnos] = false;

        contaAni = 0;
        primera = true;
        control = true;
        controlBoss = false;
        estAnimacion = false;
        terminado = false;

        contadorTurnos = (contadorTurnos + 1) % turnos.Length;
    }

    // ================== CONTROL MUERTE ==================
    public void ControlMuerte()
    {
        // Verifica si ambos personajes están muertos
        bool ambosMuertos = true;

        foreach (Player obj in jugador)
        {
            if (!obj.muerto)
                ambosMuertos = false;
        }

        if (ambosMuertos && !SoloEstavez)
            StartCoroutine(FinPartida());
    }

    // ================== FIN PARTIDA ==================
    public IEnumerator FinPartida()
    {
        // Muestra panel de derrota
        SoloEstavez = true;
        yield return new WaitForSeconds(1.2f);

        Time.timeScale = 0;
        panel.SetActive(true);

        if (primeraBatalla == 0) Items.cantidad = 5;
        else if (primeraBatalla == 1) Items.cantidad = 10;
        else if (primeraBatalla == 2) Items.cantidad = 15;
    }

    // ================== TUTORIAL ==================
    public void ActivaTutorial()
    {
        tutorial.SetActive(true);
    }

    public void DesactivarTutorial()
    {
        tutorial.SetActive(false);
        desacTuto = true;
    }
}