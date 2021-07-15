﻿using UnityEngine;

namespace Constants
{
    public static class Tags
    {
        public const string player = "Player";
        public const string target = "Target";
        public const string mainCamera = "MainCamera";
    }
    public static class Layers
    {
        public static readonly int ground = LayerMask.NameToLayer("Ground");
        public static readonly int player = LayerMask.NameToLayer("Player");
    }
}
