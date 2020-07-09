﻿using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Services
{
    public interface SaveLoadService
    {
        void SavePlayer(PlayerData playerData, Vector2 vector2);
        PlayerData LoadPlayer(Rigidbody2D rigidbody);
        PlayerData NewGame(int id, string playerName, int maxHealth, int maxEndurance);
        void Save(PlayerData playerData);
        PlayerData Load();
    }
}
