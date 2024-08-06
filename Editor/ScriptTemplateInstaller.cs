using System.IO;
using System.Threading.Tasks;
using UnityEditor;

namespace ScriptTemplates
{
    public static class ScriptTemplateInstaller
    {
        const string ScriptTemplatesLocalPath = "/Resources/ScriptTemplates/";
        const string CustomTemplatesLocalPath = "Packages/com.joshua-auer.script-templates/Editor/Templates/";

        const string OriginalBehaviourScriptTemplateName = "81-C# Script-NewBehaviourScript.cs.txt";

        const string BehaviourScriptTemplateName = "81-C# Script__MonoBehaviour-NewBehaviourScript.cs.txt";
        const string ClassScriptTemplateName = "81-C# Script__Class-NewClass.cs.txt";
        const string InterfaceScriptTemplateName = "81-C# Script__Interface-NewInterface.cs.txt";
        const string SOScriptTemplateName = "81-C# Script__ScriptableObject-NewScriptableObjectScript.cs.txt";

        [MenuItem("Tools/Script Templates/Install Script Templates")]
        static async void SetupScriptTemplates()
        {
            var scriptTemplatesFullPath = EditorApplication.applicationContentsPath + ScriptTemplatesLocalPath;
            
            RemoveOriginalBehaviourScriptTemplate(scriptTemplatesFullPath);
            
            EditorUtility.DisplayProgressBar("Creating script templates...", "Creating MonoBehaviour template...", 0f);
            await SetupScriptTemplate(scriptTemplatesFullPath, BehaviourScriptTemplateName);

            EditorUtility.DisplayProgressBar("Creating script templates...", "Creating class template...", 0.25f);
            await SetupScriptTemplate(scriptTemplatesFullPath, ClassScriptTemplateName);
            
            EditorUtility.DisplayProgressBar("Creating script templates...", "Creating interface template...", 0.5f);
            await SetupScriptTemplate(scriptTemplatesFullPath, InterfaceScriptTemplateName);
            
            EditorUtility.DisplayProgressBar("Creating script templates...", "Creating ScriptableObject template...", 0.75f);
            await SetupScriptTemplate(scriptTemplatesFullPath, SOScriptTemplateName);

            EditorUtility.DisplayProgressBar("Creating script templates...", "Finishing up...", 1f);
            EditorUtility.ClearProgressBar();

            if (EditorUtility.DisplayDialog("Script Templates", "An editor restart is required to use the new script templates. Do you want to restart the editor now?", "Yes, restart now", "No, restart later"))
                EditorApplication.OpenProject(Directory.GetCurrentDirectory());
        }

        static void RemoveOriginalBehaviourScriptTemplate(string scriptTemplatesPath)
        {
            var originalBehaviourScriptPath = scriptTemplatesPath + OriginalBehaviourScriptTemplateName;
            if (File.Exists(originalBehaviourScriptPath))
                File.Delete(originalBehaviourScriptPath);
        }

        static async Task SetupScriptTemplate(string scriptTemplatesPath, string templateName)
        {
            var path = scriptTemplatesPath + templateName;
            if (File.Exists(path)) return;

            var fileStream = File.Create(path);
            var bytes = await File.ReadAllBytesAsync(Path.GetFullPath(CustomTemplatesLocalPath + templateName));
            await fileStream.WriteAsync(bytes);
            fileStream.Close();
        }
    }
}