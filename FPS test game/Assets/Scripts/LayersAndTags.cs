using UnityEngine;

namespace Constants
{
    public static class Tags
    {
        public const string player = "Player";
        public const string target = "Target";
    }
    public static class Layers
    {
        public static readonly int ground = LayerMask.NameToLayer("Ground");
    }
}
