using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using NUnit.Framework;
using Unity.VisualScripting;

public class Conversaciones : MonoBehaviour
{
    public GameObject caja;
    public GameObject boss;
    private Image imagen;
    public Sprite[] imagenes;
    public string[] textos;
    public string[] textos2;
    private TextMeshProUGUI text;
    private TextMeshProUGUI info;
    private TextMeshProUGUI nombre;
    public int num = 0;
    private int conta = 1;
    public string escena;
    public VideoPlayer[] videos;
    //esta variable ayudara controlar cuando esta en video o no
    public static int contaVideo=0;
    private bool enVideo=false;
    public Animator aniBoss;
    public int numBoss = 0;
    public string[] nomBosses;
    private bool NoaFirts = false;
    private GameObject[] botones;
    private bool enter;

    void Start()
    {
        foreach (VideoPlayer v in videos)
        {
            v.gameObject.SetActive(false);
        }
        enter = false;
        text = GameObject.Find("Texto").GetComponent<TextMeshProUGUI>();
        info = GameObject.Find("Informacion").GetComponent<TextMeshProUGUI>();
        nombre = GameObject.Find("Nombre").GetComponent<TextMeshProUGUI>();
        imagen = boss.GetComponent<Image>();
        aniBoss = boss.GetComponent<Animator>();

        if(GameManager.primeraBatalla>=1) boss.gameObject.SetActive(true);
        else boss.gameObject.SetActive(false);
        caja.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        botones = GameObject.FindGameObjectsWithTag("boton");

        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].gameObject.SetActive(false);
        }

        Invoke("activarCaja", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {

        if (enter == true)
        {

            if (GameManager.primeraBatalla == 0)
            {
                botones[0].gameObject.SetActive(true);
                if (enVideo == false)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        conta++;
                        if (num < textos.Length)
                        {
                            text.text = textos[num++];
                        }

                        if (num == 4)
                        {
                            enVideo = true;
                            videos[contaVideo].gameObject.SetActive(true);
                            ComienzaVdeo();
                        }

                        if (num == 7)
                        {
                            boss.gameObject.SetActive(true);
                            aniBoss.Play("BossAparece");
                        }
                        if (num == 13)
                        {
                            aniBoss.Play("BossDesaparece");
                            enVideo = true;
                            videos[contaVideo].gameObject.SetActive(true);
                            ComienzaVdeo();
                        }

                        if (num % 2 == 1 && num > 8)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        }

                        else if (num % 2 == 0 && num > 8)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 22;
                            nombre.text = nomBosses[0];
                        }


                        if (conta > textos.Length) cambiarEscena();

                    }
                }
            }

            if (GameManager.primeraBatalla == 1)
            {
                botones[1].gameObject.SetActive(true);
                if (enVideo == false)
                {
                    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                    {
                        conta++;
                        if (num < textos2.Length)
                        {
                            text.text = textos2[num++];
                        }

                        if (num == 8)
                        {
                            boss.gameObject.SetActive(true);
                            aniBoss.Play("BossDesaparece");
                        }

                        if (NoaFirts == false)
                        {
                            if (num % 2 == 1)
                            {
                                imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                                nombre.fontSize = 30;
                                nombre.text = "Noa";
                            }
                        }

                        if (num == 10)
                        {
                            enVideo = true;
                            videos[contaVideo].gameObject.SetActive(true);
                            ComienzaVdeo();
                        }

                        if (num % 2 == 0 && num < 9)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 22;
                            nombre.text = nomBosses[0];
                        }
                        else if (num % 2 == 1 && num > 8)
                        {
                            NoaFirts = true;
                            nombre.text = " ";
                        }
                        else if (num % 2 == 0 && num > 9)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        }

                        if (conta > textos2.Length) cambiarEscena("Conver-2");

                    }
                }
            }
        }


    }

    public void activarCaja()
    {
        //activara ciertos objetos para que comience las conversaciones
        if (GameManager.primeraBatalla > 1) GameManager.primeraBatalla = 1;
        num = 0;
        if (!caja.activeSelf) caja.gameObject.SetActive(true);

        info.gameObject.SetActive(true);
        imagen.sprite = imagenes[numBoss];
        if (GameManager.primeraBatalla == 0 && num < textos.Length)
        {
            text.text = textos[num];
        }
        else if (GameManager.primeraBatalla == 1 && num < textos2.Length)
        {
            text.text = textos2[num];
            boss.gameObject.SetActive(true);
            aniBoss.Play("BossAparece");
            RenderizarombreProta();
            nombre.text = "Noa";
        }

        num++;

        enter = true;
    }


    public void cambiarEscena()
    {
        Transicion trans = Object.FindAnyObjectByType<Transicion>();
        StartCoroutine(trans.SceneLoad(escena));
    }

    public void cambiarEscena(string nom)
    {
        Transicion trans = Object.FindAnyObjectByType<Transicion>();
        StartCoroutine(trans.SceneLoad(nom));
    }

    public void ComienzaVdeo()
    {
        //al comenzar el video verificara que cuando acabe lleve a otra funcion
        if (videos[contaVideo].isPlaying)
            return; 

        videos[contaVideo].isLooping = false;
        videos[contaVideo].loopPointReached += OnVideoFinished;
        videos[contaVideo].Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        //En esta funcion lo que hace es que cuando acabe de el control del jugador para que pueda seguir cambiando de dialogos
        videos[contaVideo].gameObject.SetActive(false);
        videos[contaVideo].loopPointReached -= OnVideoFinished;

        enVideo = false;
        contaVideo++;

        if (num == 13)
        {
            aniBoss.Play("BossAparece"); 
        }
    }


    public void RenderizarombreJefe()
    {
        imagen.color = new Color(255f, 255f, 255f);
        nombre.fontSize = 22;
    }

    public void RenderizarombreProta()
    {
        imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
        nombre.fontSize = 30;
    }

}
