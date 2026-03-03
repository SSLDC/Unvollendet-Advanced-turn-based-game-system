using TMPro;
using UnityEngine;

/*
Items controla el sistema de objetos del combate:
- Cantidad disponible
- Información en pantalla
- Consumo de objetos
*/

public class Items : MonoBehaviour
{
    // ================== VARIABLES ESTÁTICAS ==================
    // Controlan la cantidad y el poder de cada objeto
    public static int cantidad = 5;
    public static float pocion = 1000;
    public static float eter = 250;
    public static float fenix;

    // ================== VARIABLES INTERNAS ==================
    private bool NoObjecto = true;
    private TextMeshProUGUI itemInfo;

    public GameObject[] players;
    public Player[] charac;

    // ================== START ==================
    void Start()
    {
        // Busco el texto donde se muestra la cantidad de objetos
        itemInfo = GameObject.Find("ItemsInfo").GetComponent<TextMeshProUGUI>();

        // Obtengo todos los jugadores
        players = GameObject.FindGameObjectsWithTag("Player");
        charac = new Player[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            charac[i] = players[i].GetComponent<Player>();
        }
    }

    // ================== UPDATE ==================
    void Update()
    {
        // Actualiza constantemente la cantidad visible en pantalla
        cantidadItems();
    }

    // ================== CONTROL DE CANTIDAD ==================
    public void cantidadItems()
    {
        // Si no quedan objetos muestra mensaje
        if (NoObjecto == true)
        {
            if (cantidad <= 0)
            {
                GameManager.lienzoInfo.SetActive(true);
                GameManager.infoestado.text = "¡Ya no te quedan Objetos!";

                Invoke("DesactivarLienzoInfo", 2f);
            }
        }

        // Actualiza el texto en pantalla
        itemInfo.text = "Objetos Disponibles: " + cantidad;
    }

    // ================== DESACTIVAR MENSAJE ==================
    public void DesactivarLienzoInfo()
    {
        GameManager.lienzoInfo.SetActive(false);
        GameManager.infoestado.text = "";
        NoObjecto = false;
    }

    // ================== USO DE OBJETOS ==================
    public void recuVida()
    {
        // Reduce la cantidad cuando se usa una poción
        cantidad--;
    }

    public void recuPM()
    {
        // Reduce la cantidad cuando se usa un éter
        cantidad--;
    }

    public void revivir()
    {
        // Reduce la cantidad cuando se usa cola de fénix
        cantidad--;
    }
}