using UnityEngine;

/*
Magias controla:
- Potencia de cada hechizo
- Coste de PM
- Referencias a jugadores y jefes
- Ejecución de cada magia
*/

public class Magias : MonoBehaviour
{
    // ================== POTENCIA DE ATAQUES ==================
    public float ataqueArtema;
    public float ataqueMeteo;
    public float ataqueFulgor;
    public float potenCura;

    // ================== COSTES DE PM ==================
    public float costeArtema;
    public float costeFulgor;
    public float costeMeteo;
    public float costeCura;

    // ================== REFERENCIAS ==================
    public GameObject[] players;
    public Player[] charac;

    public GameObject[] BossesMagic;
    public Boss[] jefesMagic;

    // ================== START ==================
    void Start()
    {
        // Ajuste de dificultad según la batalla actual
        if (GameManager.primeraBatalla == 1)
        {
            ataqueArtema += 100;
            ataqueMeteo += 100;
            ataqueFulgor += 100;
        }

        if (GameManager.primeraBatalla == 2)
        {
            ataqueArtema += 200;
            ataqueMeteo += 200;
            ataqueFulgor += 300;
            potenCura += 200;
            costeCura += 20;
        }

        // Obtengo jugadores
        players = GameObject.FindGameObjectsWithTag("Player");
        charac = new Player[players.Length];

        // Obtengo jefes
        BossesMagic = GameObject.FindGameObjectsWithTag("Boss");
        jefesMagic = new Boss[BossesMagic.Length];

        for (int i = 0; i < players.Length; i++)
        {
            charac[i] = players[i].GetComponent<Player>();
        }

        for (int i = 0; i < BossesMagic.Length; i++)
        {
            jefesMagic[i] = BossesMagic[i].GetComponent<Boss>();
        }
    }

    // ================== EJECUCIÓN DE MAGIAS ==================

    public void EjecucionArtema()
    {
        // Daño al jefe y reducción de PM del personaje 0
        jefesMagic[0].RecibirDanoBoss(ataqueArtema);
        charac[0].ReducirPM(1, costeArtema);
    }

    public void EjecucionFulgor()
    {
        // Daño al jefe y reducción de PM del personaje 0
        jefesMagic[0].RecibirDanoBoss(ataqueFulgor);
        charac[0].ReducirPM(1, costeFulgor);
    }

    public void EjecucionMeteo()
    {
        // Daño al jefe y reducción de PM del personaje 1
        jefesMagic[0].RecibirDanoBoss(ataqueMeteo);
        charac[1].ReducirPM(0, costeMeteo);
    }

    public void EjecucionCura()
    {
        // Si no es cura grupal, reduce PM normalmente
        if (!GameManager.ActivaTodos)
        {
            charac[1].ReducirPM(0, costeCura);
        }
    }
}