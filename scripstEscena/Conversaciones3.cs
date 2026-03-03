 using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using NUnit.Framework;
using Unity.VisualScripting;

public class Conversaciones3 : MonoBehaviour
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
    public static int contaVideo3 = 0;

    //esta variable ayudara controlar cuando esta en video o no
    private bool enVideo = false;
    public Animator aniBoss;
    public int numBoss = 0;
    public string[] nomBosses;
    private Image imagenFondo;
    public Sprite[] fondos;
    private bool enter;
    private GameObject[] botones;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        imagenFondo=GameObject.Find("Fondo").GetComponent<Image>();
        imagen = boss.GetComponent<Image>();
        aniBoss = boss.GetComponent<Animator>();
        botones = GameObject.FindGameObjectsWithTag("boton");

        boss.gameObject.SetActive(false);
        caja.gameObject.SetActive(false);
        info.gameObject.SetActive(false);

        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].gameObject.SetActive(false);
        }

        //Verificará si el jefe ha muerto o no, para que cambie de fondo

        if (GameManager.primeraBatalla == 2) imagenFondo.sprite = fondos[0];
        else if(GameManager.primeraBatalla == 3) imagenFondo.sprite = fondos[1];

        Invoke("activarCaja", 0.25f);
    }

    // Update is called once per frame
    void Update()
    {

        if (enter == true) {
            if (Input.GetKeyDown(KeyCode.Z)) GameManager.primeraBatalla++;

            if (GameManager.primeraBatalla == 2)
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

                        if (num == 3)
                        {
                            boss.gameObject.SetActive(true);
                            aniBoss.Play("BossAparece");
                        }
                        //------------------------------------------------------------------------
                        if (num % 2 == 0 && num > 3 && num < 9)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        }

                        else if (num % 2 == 1 && num > 3 && num < 9)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 30;
                            nombre.text = nomBosses[0];
                        }

                        //------------------------------------------------------------------------
                        if (num % 2 == 1 && num >= 9 && num < 11)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        } else if (num % 2 == 0 && num >= 9 && num < 11)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 30;
                            nombre.text = nomBosses[0];
                        }
                        //------------------------------------------------------------------------
                        if (num % 2 == 0 && num > 11 && num < 15)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        }
                        else if (num % 2 == 1 && num > 11 && num < 15)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 30;
                            nombre.text = nomBosses[0];
                        }
                        //------------------------------------------------------------------------
                        if (num % 2 == 1 && num > 15)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        }
                        else if (num % 2 == 0 && num > 15)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 30;
                            nombre.text = nomBosses[0];
                        }

                        if (num == 8 || num == 11)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 30;
                            nombre.text = nomBosses[0];
                        }

                        if (num == 14)
                        {
                            aniBoss.Play("BossDesaparece");

                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = " ";

                            enVideo = true;
                            videos[contaVideo3].gameObject.SetActive(true);
                            ComienzaVdeo();
                        }

                        if (num == 15)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        }


                        if (conta > textos.Length) cambiarEscena();

                    }
                }
            }

            if (GameManager.primeraBatalla == 3)
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

                        if (num % 2 == 0 && num < 5)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        }
                        if (num % 2 == 0 && num > 5)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 30;
                            nombre.text = nomBosses[0];
                        }

                        if (num % 2 == 1 && num > 5)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = "Noa";
                        }
                        if (num % 2 == 1 && num < 5)
                        {
                            imagen.color = new Color(255f, 255f, 255f);
                            nombre.fontSize = 30;
                            nombre.text = nomBosses[0];
                        }

                        if (num == 12) aniBoss.Play("BossDesaparece");

                        if (num == 5)
                        {
                            imagen.color = new Color(108f / 255f, 108f / 255f, 108f / 255f);
                            nombre.fontSize = 30;
                            nombre.text = " ";
                        }

                        if (num == 9)
                        {
                            aniBoss.Play("BossDesaparece");
                            enVideo = true;
                            videos[contaVideo3].gameObject.SetActive(true);
                            ComienzaVdeo();
                        }

                        if (conta > textos2.Length) cambiarEscena("FinalScene");

                    }
                }
            }
        }
    }

    public void activarCaja()
    {
        //activara ciertos objetos para que comience las conversaciones

        if (GameManager.primeraBatalla > 3) GameManager.primeraBatalla = 3;
        num = 0;
        if (!caja.activeSelf)caja.gameObject.SetActive(true);

        info.gameObject.SetActive(true);

        if (numBoss >= 0 && numBoss < imagenes.Length)imagen.sprite = imagenes[numBoss];

        if (GameManager.primeraBatalla == 2 && num < textos.Length)
        {
            text.text = textos[num];
        }
        else if (GameManager.primeraBatalla == 3 && num < textos2.Length)
        {
            if (!boss.activeSelf)
            {
                boss.gameObject.SetActive(true);
                aniBoss.Play("BossAparece");
            }

            text.text = textos2[num];
            RenderizarombreJefe();
            nombre.text = "Edén";
        }
        else
        {
            Debug.LogWarning("Índice fuera de rango: numBoss o num");
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
        videos[contaVideo3].isLooping = false;
        videos[contaVideo3].loopPointReached += OnVideoFinished;
        videos[contaVideo3].Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        //En esta funcion lo que hace es que cuando acabe de el control del jugador para que pueda seguir cambiando de dialogos
        if (contaVideo3 < videos.Length)
        {
            videos[contaVideo3].gameObject.SetActive(false);
            videos[contaVideo3].loopPointReached -= OnVideoFinished;
        }

        enVideo = false;

        if (contaVideo3 < videos.Length - 1)
        {
            contaVideo3++;
        }

        switch (num)
        {
            case 14:
            case 9:
                aniBoss.Play("BossAparece");
                break;

            default:
                break;
        }

        if (contaVideo3 < videos.Length)
        {
            ComienzaVdeo();
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
