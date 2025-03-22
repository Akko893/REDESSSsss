using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    // Instancia única del administrador de spawn points
    private static SpawnPointManager instance;
    // Propiedad pública para acceder a la instancia desde otros scripts
    public static SpawnPointManager Instance { get { return instance; } }

    // Array que contiene todos los puntos de aparición disponibles en la escena
    public Transform[] spawnPoints;

    // Se ejecuta al iniciar el objeto, configura el Singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Retorna una posición aleatoria de entre todos los puntos de aparición disponibles
    // Si no hay puntos configurados, retorna Vector3.zero y muestra una advertencia
    public Vector3 GetRandomSpawnPoint()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("No hay spawn points configurados!");
            return Vector3.zero;
        }

        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex].position;
    }
}

