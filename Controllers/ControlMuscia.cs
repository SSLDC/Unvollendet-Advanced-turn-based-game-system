using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMuscia : MonoBehaviour
{
        public static ControlMuscia instance;
        public AudioSource musica;
        public string[] escenasConMusica; 
        public string[] escenasDetenerMusica; 

        private string escenaActual;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject); 
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            escenaActual = SceneManager.GetActiveScene().name;

            // Verifica si la escena actual está en la lista de escenas donde se debe mantener la música
            if (escenasConMusica.Contains(escenaActual))
            {
                if (!musica.isPlaying) musica.Play();
            }
            // Si estamos en una escena donde la música debe detenerse se detiene
            else if (escenasDetenerMusica.Contains(escenaActual))
            {
                musica.Stop();
            }
        }

        void Update()
        {
            if (SceneManager.GetActiveScene().name != escenaActual)
            {
                escenaActual = SceneManager.GetActiveScene().name;

                if (escenasConMusica.Contains(escenaActual) && !musica.isPlaying)
                {
                    musica.Play();
                }
                else if (escenasDetenerMusica.Contains(escenaActual))
                {
                    musica.Stop();
                }
            }
        }

}
