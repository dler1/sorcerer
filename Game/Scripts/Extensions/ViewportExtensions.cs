using Godot;

namespace Game.Scripts.Extensions
{
    public static class ViewportExtensions
    {
        public static T FindChildByType<T>(this Viewport viewport)
        {
            foreach (var child in viewport.GetChild(0).GetChildren())
            {
                if (child is T res)
                    return res;
            }

            return default;
        }
    }
}