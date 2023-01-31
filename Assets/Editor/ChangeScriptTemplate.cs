using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;
using UnityEditor.ProjectWindowCallback;
using System.Text.RegularExpressions;

public class ChangeScriptTemplate : MonoBehaviour
{
    //脚本模板所在的目录
    private const string MONO_SCRIPT = "Assets/Editor/ScriptTemplates/MonoTemplate.cs.txt";
    private const string SIMPLE_SCRIPT = "Assets/Editor/ScriptTemplates/SimpleTemplate.cs.txt";
    private const string COMMAND_SCRIPT = "Assets/Editor/ScriptTemplates/Command.cs.txt";
    private const string UI_TEMPLATE_SCRIPT = "Assets/Editor/ScriptTemplates/UITemplateClass.cs.txt";
    private const string UI_WINDOW_SCRIPT = "Assets/Editor/ScriptTemplates/UI_Window.cs.txt";
    private const string UI_PANEL_SCRIPT = "Assets/Editor/ScriptTemplates/UI_Panel.cs.txt";

    [MenuItem("Assets/MyCreate/SimpleMonoScript", false, 1)]
    public static void CreateMyScript()
    {
        string locationPath = GetSelectedPathOrFallback();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
            0,
            ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(), // 回调，处理模板中的宏
            locationPath + "/SimpleMonoScript.cs", // 新建文件的路径
            null,
            MONO_SCRIPT); // 模板文件路径
    }

    [MenuItem("Assets/MyCreate/SimpleScript", false, 1)]
    public static void CreateSimpleScript()
    {
        string locationPath = GetSelectedPathOrFallback();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
            0,
            ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(), // 回调，处理模板中的宏
            locationPath + "/SimpleScript.cs", // 新建文件的路径
            null,
            SIMPLE_SCRIPT); // 模板文件路径
    }

    [MenuItem("Assets/MyCreate/Command", false, 1)]
    public static void CreateCommandScript()
    {
        string locationPath = GetSelectedPathOrFallback();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
            0,
            ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(), // 回调，处理模板中的宏
            locationPath + "/Command.cs", // 新建文件的路径
            null,
            COMMAND_SCRIPT); // 模板文件路径
    }

    [MenuItem("Assets/MyCreate/UITemplateClass", false, 1)]
    public static void CreateUITemplateScript()
    {
        string locationPath = GetSelectedPathOrFallback();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
            0,
            ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(), // 回调，处理模板中的宏
            locationPath + "/UITemplateClass.cs", // 新建文件的路径
            null,
            UI_TEMPLATE_SCRIPT); // 模板文件路径
    }

    [MenuItem("Assets/MyCreate/UI_Window", false, 1)]
    public static void CreateUIWindowScript()
    {
        string locationPath = GetSelectedPathOrFallback();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
            0,
            ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(), // 回调，处理模板中的宏
            locationPath + "/UI.cs", // 新建文件的路径
            null,
            UI_WINDOW_SCRIPT); // 模板文件路径
    }

    [MenuItem("Assets/MyCreate/UI_Panel", false, 1)]
    public static void CreateUIPanelScript()
    {
        string locationPath = GetSelectedPathOrFallback();
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
            0,
            ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(), // 回调，处理模板中的宏
            locationPath + "/UI.cs", // 新建文件的路径
            null,
            UI_PANEL_SCRIPT); // 模板文件路径
    }

    // 获取当前在Project视图中选中的文件夹
    public static string GetSelectedPathOrFallback()
    {
        string path = "Assets";
        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.
            Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        // Debug.Log(path);
        return path;
    }
}


class MyDoCreateScriptAsset : EndNameEditAction
{

    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        UnityEngine.Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(o);
    }

    internal static UnityEngine.Object CreateScriptAssetFromTemplate(string pathName,
        string resourceFile)
    {
        string fullPath = Path.GetFullPath(pathName);
        StreamReader streamReader = new(resourceFile);
        string text = streamReader.ReadToEnd();
        streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        //替换文件名
        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
        text = Regex.Replace(text, "#Project#", "SlayTheSpireM");
        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new(encoderShouldEmitUTF8Identifier,
            throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new(fullPath, append, encoding);
        streamWriter.Write(text);
        streamWriter.Close();
        AssetDatabase.ImportAsset(pathName);
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));
    }
}