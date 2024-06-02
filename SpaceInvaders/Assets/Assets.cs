namespace SpaceInvaders.Assets
{
    internal static class Assets
    {
        private static string basePath = AppDomain.CurrentDomain.BaseDirectory;

        private static string assetsPath = Path.Combine(BasePath, "Assets");

        public static string BasePath { get => basePath; set => basePath = value; }
        public static string AssetsPath { get => assetsPath; set => assetsPath = value; }
    }
}