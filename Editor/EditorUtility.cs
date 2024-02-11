using UnityEditor;

namespace SpatialSys.UnitySDK.Editor
{
    public static class EditorUtility
    {
        public static T LoadAssetFromPackagePath<T>(string relativePath) where T : UnityEngine.Object
        {
            return AssetDatabase.LoadAssetAtPath<T>($"{PackageManagerUtility.PACKAGE_DIRECTORY_PATH}/{relativePath}");
        }

        public static string AbbreviateNumber(int number)
        {
            switch (number)
            {
                case < 1000:
                    return number.ToString();
                case < 10000:
                    return (number / 1000f).ToString("0.#") + "K";
                case < 1000000:
                    return (number / 1000).ToString() + "K";
                case < 10000000:
                    return (number / 1000000f).ToString("0.#") + "M";
                case >= 10000000:
                    return (number / 1000000).ToString() + "M";
            }
        }

        public static void SaveAssetImmediately(UnityEngine.Object asset)
        {
            UnityEditor.EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssetIfDirty(asset);
        }
    }
}
