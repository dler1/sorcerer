using System;
using System.Collections.Generic;
using Godot;

namespace Game.Scripts.Helpers
{
    public static class SceneLoader
    {
        private static readonly Dictionary<Type, string> paths = new()
        {
            [typeof(Slime)] = "res://Scenes/Enemies/Slime/Slime.tscn",
            [typeof(Fireball)] = "res://Scenes/Skills/Fireball/Fireball.tscn"
        };

        public static PackedScene Load<T>()
        {
            GD.Print(paths.TryGetValue(typeof(T), out var r) ? r : "false");
            return (PackedScene) ResourceLoader.Load(paths[typeof(T)]);
        }
    }
}