using UnityEngine;
using UnityEngine.Tilemaps; // Обязательно добавь это для работы с тайлами
using System.Collections.Generic;

public class DungeonRoom : MonoBehaviour
{
    [Header("Настройки плиток")]
    public Tilemap gatesTilemap; // Сюда перетяни объект Gates
    public TileBase openGateTile; // Сюда перетяни тайл с узором
    public TileBase closedGateTile; // Сюда перетяни тайл с линиями

    [Header("Настройки боя")]
    public List<GameObject> enemies;
    private bool isRoomActive = false;
    private BoundsInt gateBounds;

    void Start()
    {
        // Запоминаем область, где нарисованы ворота
        gateBounds = gatesTilemap.cellBounds;
        OpenGates();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isRoomActive)
        {
            ActivateRoom();
        }
    }

    void ActivateRoom()
    {
        isRoomActive = true;
        SwapTiles(closedGateTile); // Меняем на закрытые
        Debug.Log("<color=red>Бой начался!</color>");
    }

    void OpenGates()
    {
        isRoomActive = false;
        SwapTiles(openGateTile); // Меняем на открытые
    }

    // Метод для замены всех плиток на тайлмапе Gates
    void SwapTiles(TileBase newTile)
    {
        foreach (var pos in gateBounds.allPositionsWithin)
        {
            if (gatesTilemap.HasTile(pos))
            {
                gatesTilemap.SetTile(pos, newTile);
            }
        }
    }

    void Update()
    {
        if (isRoomActive)
        {
            enemies.RemoveAll(e => e == null);
            if (enemies.Count == 0)
            {
                OpenGates();
            }
        }
    }
}