using Godot;

namespace Game.Scripts.Helpers
{
    public static class InputChecker
    {
        public static float GetAxis(string action, string alternativeAction)
        {
            return Input.IsActionPressed(action)
                ? 1
                : Input.IsActionPressed(alternativeAction)
                    ? -1
                    : 0;
        }
    }
}