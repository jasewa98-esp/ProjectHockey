using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Tutorial
{
    public class ControladorTextoTuto : MonoBehaviour
    {
        public Text checkTuto;

        private float x, y;

        private String movePlayer = "no", disparo = "no", sprint = "no", guardar = "no", pausa = "no", cargarPartida = "no";
    
        // Start is called before the first frame update
        void Start()
        {
            checkTuto.text = "# Mover Jugador -> " + movePlayer + "\n# Disparo -> " + disparo + "\n# Sprint -> " + sprint + "\n# Guardar -> " + guardar + "\n# Pausa -> " + pausa + "\n# Cargar Partida -> " + cargarPartida;
        }

        // Update is called once per frame
        void Update()
        {
            checkTuto.text = "# Mover Jugador (AWSD) (Joystick Izq) -> " + movePlayer + "\n# Disparo (E) (Cuadrado)-> " + disparo + "\n# Sprint (Left) (L2) -> " + sprint + "\n# Guardar (G) -> " + guardar + "\n# Pausa (Space) (R2) -> " + pausa + "\n# Cargar Partida (L) -> " + cargarPartida;

            if (Input.GetAxis("Horizontal").Equals(1) || Input.GetAxis("Vertical").Equals(1))
            {
                movePlayer = "Completado";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                disparo = "Completado";
            }
            
            if (Input.GetKeyDown(KeyCode.Joystick1Button6))
            {
                sprint = "Completado";
            }
            
            if (Input.GetKeyDown(KeyCode.G))
            {
                guardar = "Completado";
            }
            
            if (Input.GetKeyDown(KeyCode.L))
            {
                cargarPartida = "Completado";
            }
            
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                pausa = "Completado";
            }
        }
    }
}
