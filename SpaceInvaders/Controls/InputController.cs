using System.Collections;

namespace SpaceInvaders.Controls
{
    internal static class InputController
    {
        private static readonly BitArray keys = new(Enum.GetValues(typeof(KeyIndex)).Length);

        public static BitArray Keys => keys;

        public static void SetKey(Keys key)
        {
            switch (key)
            {
                case System.Windows.Forms.Keys.Left:
                    Keys[(int)KeyIndex.Left] = true;
                    break;

                case System.Windows.Forms.Keys.Right:
                    Keys[(int)KeyIndex.Right] = true;
                    break;

                case System.Windows.Forms.Keys.A:
                    Keys[(int)KeyIndex.A] = true;
                    break;

                case System.Windows.Forms.Keys.D:
                    Keys[(int)KeyIndex.D] = true;
                    break;

                case System.Windows.Forms.Keys.Space:
                    Keys[(int)KeyIndex.Space] = true;
                    break;
            }
        }

        public static void ResetKey(Keys key)
        {
            switch (key)
            {
                case System.Windows.Forms.Keys.Left:
                    Keys[(int)KeyIndex.Left] = false;
                    break;

                case System.Windows.Forms.Keys.Right:
                    Keys[(int)KeyIndex.Right] = false;
                    break;

                case System.Windows.Forms.Keys.A:
                    Keys[(int)KeyIndex.A] = false;
                    break;

                case System.Windows.Forms.Keys.D:
                    Keys[(int)KeyIndex.D] = false;
                    break;

                case System.Windows.Forms.Keys.Space:
                    Keys[(int)KeyIndex.Space] = false;
                    break;
            }
        }
    }
}