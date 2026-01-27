using kataraktaCS.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace kataraktaCS
{
    internal class TemplateFunctions
    {
        VariousFunctions VariousFunctions;
        MainDefinitions MainDefinitions;

        public TemplateFunctions()
        {
            VariousFunctions = new VariousFunctions();
            MainDefinitions = new MainDefinitions();
        }

        public static void SwapFolderSettingsTemplate(string FolderSettingsPath, string TemplateName)
        {
            try
            {
                kCSFolderClass JSONFolderSettings =
                    JsonConvert.DeserializeObject<kCSFolderClass>(File.ReadAllText(FolderSettingsPath));


                var NewFolderSettings = new
                {
                    kCSFolderRevision = "2",
                    Template = new
                    {
                        Filename = TemplateName,
                        CoverSubfolders = JSONFolderSettings.Template.CoverSubfolders
                    }
                };

                using (var SW = new StreamWriter(FolderSettingsPath))
                using (var Writer = new JsonTextWriter(SW))
                {
                    Writer.Formatting = Formatting.Indented;
                    Writer.IndentChar = '\t';
                    Writer.Indentation = 1;

                    var Serializer = new JsonSerializer();
                    Serializer.Serialize(Writer, NewFolderSettings);
                }
            }
            catch
            {
                MessageBox.Show(
                    Resources.Error_NotValidFolderSettings,
                    Resources.Error_Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        public static bool HasFolderSettings(string rootDirectory)
        {
            if (File.Exists(Path.Combine(rootDirectory, "FolderSettings.json")))
                return true;
            return false;
        }

        public static List<string> GetAllFolderSettingsFiles(string rootDirectory)
        {
            return Directory
                .GetFiles(rootDirectory, "FolderSettings.json", SearchOption.AllDirectories)
                .ToList();
        }

        public static List<string> GetAllTemplateFiles(string rootDirectory, bool Subfolders = true)
        {
            if (Subfolders)
                return Directory
                    .GetFiles(rootDirectory, "*.json", SearchOption.AllDirectories)
                    .Where(f => !string.Equals(
                        Path.GetFileName(f),
                        "FolderSettings.json",
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
            else
                return Directory
                    .GetFiles(rootDirectory, "*.json", SearchOption.TopDirectoryOnly)
                    .Where(f => !string.Equals(
                        Path.GetFileName(f),
                        "FolderSettings.json",
                        StringComparison.OrdinalIgnoreCase))
                    .ToList();
        }

        public bool CheckIfRev1(string Path)
        {
            using (StreamReader file = File.OpenText(Path))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                while (reader.Read())
                {
                    // Look for the first property name
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        string propertyName = reader.Value?.ToString();
                        // For some reason, I made the first versions of templates
                        // and folder settings start with "kCSTemplate" and "Folder
                        // Settings" respectively. It's dumb, and that is also what
                        // we will use to see if they are of the first revision.
                        if (propertyName == "kCSFolder" ||
                            propertyName == "kCSTemplate")
                            return true;
                        else return false;
                    }
                }
            }
            return false;
        }

        public void ConvertFolderSettings(string FolderSettingsPath)
        {
            if (CheckIfRev1(FolderSettingsPath))
            {
                kCSFolderRootRev1 JSONFolder =
                    JsonConvert.DeserializeObject<kCSFolderRootRev1>(File.ReadAllText(FolderSettingsPath));

                var ConvertedFolderSettings = new
                {
                    kCSFolderRevision = "2",
                    Template = new
                    {
                        Filename = JSONFolder.kCSFolder.Template.Filename,
                        CoverSubfolders = JSONFolder.kCSFolder.Template.CoverSubfolders
                    }
                };

                using (var SW = new StreamWriter(FolderSettingsPath))
                using (var Writer = new JsonTextWriter(SW))
                {
                    Writer.Formatting = Formatting.Indented;
                    Writer.IndentChar = '\t';
                    Writer.Indentation = 1;

                    var Serializer = new JsonSerializer();
                    Serializer.Serialize(Writer, ConvertedFolderSettings);
                }
            }
        }

        public void ConvertTemplate(string TemplatePath)
        {
            if (CheckIfRev1(TemplatePath))
            {
                kCSTemplateRootRev1 JSONTemplate =
                    JsonConvert.DeserializeObject<kCSTemplateRootRev1>(File.ReadAllText(TemplatePath));

                List<kCSTemplateTexture> ConvertedTextures = new List<kCSTemplateTexture>();

                foreach (kCSTemplateTextureRev1 Texture in JSONTemplate.kCSTemplate.UsedTextures)
                {
                    kCSTemplateTexture ConvertedTexture = new kCSTemplateTexture();

                    ConvertedTexture.Title = Texture.Title;
                    // The first revision had this weird thing where I
                    // used strings instead of booleans for some reason.
                    ConvertedTexture.Display = Texture.Display == "No" ? false : true;
                    ConvertedTexture.AlternativeFilename = Texture.AlternativeFilename;
                    ConvertedTexture.TexturePackFilename = Texture.TexturePackFilename;
                    // The first revision had the hex address start with
                    // “0x”, which makes sense, but there is also really
                    // no point in adding that “0x” because we always use
                    // hex and nothing else.
                    ConvertedTexture.RAM = Texture.RAM.StartsWith("0x") ? Texture.RAM.Substring(2) : Texture.RAM;
                    ConvertedTexture.RAMFormat = Texture.RAMFormat;

                    ConvertedTextures.Add(ConvertedTexture);
                }

                var ConvertedTemplate = new
                {
                    kCSTemplateRevision = "2",
                    Title = JSONTemplate.kCSTemplate.Title,
                    Description = JSONTemplate.kCSTemplate.Description,
                    UsedTextures = ConvertedTextures
                };

                using (var SW = new StreamWriter(TemplatePath))
                using (var Writer = new JsonTextWriter(SW))
                {
                    Writer.Formatting = Formatting.Indented;
                    Writer.IndentChar = '\t';
                    Writer.Indentation = 1;

                    var Serializer = new JsonSerializer();
                    Serializer.Serialize(Writer, ConvertedTemplate);
                }
            }
        }

        public string FindLowestkCSFolderPath(string textureFolder)
        {
            DirectoryInfo Dir = new DirectoryInfo(textureFolder);

            while (Dir != null)
            {
                string FilePath = Path.Combine(Dir.FullName, MainDefinitions.FolderSettingsFile);

                if (File.Exists(FilePath))
                {
                    kCSFolderClass JSONFile =
                        JsonConvert.DeserializeObject<kCSFolderClass>(File.ReadAllText(FilePath));
                    if (JSONFile.Template.CoverSubfolders)
                    {
                        return FilePath;
                    }
                    else if (JSONFile.Template.CoverSubfolders == false &&
                        VariousFunctions.EnsureTrailingSlash(Path.Combine(Path.GetDirectoryName(FilePath), ""))
                        == VariousFunctions.EnsureTrailingSlash(Path.Combine(textureFolder, "")))
                    {
                        return FilePath;
                    }
                }
                Dir = Dir.Parent;
            }

            return null;
        }

        public string GetLowestTemplatePath(string textureFolder)
        {
            string LowestkCSFolderPath = FindLowestkCSFolderPath(textureFolder);
            string TemplatePath;

            switch (File.Exists(LowestkCSFolderPath))
            {
                case true:
                    kCSFolderClass JSONFile =
                        JsonConvert.DeserializeObject<kCSFolderClass>(File.ReadAllText(LowestkCSFolderPath));

                    LowestkCSFolderPath = Path.GetDirectoryName(FindLowestkCSFolderPath(textureFolder)) + "\\";
                    return TemplatePath = $"{LowestkCSFolderPath}{JSONFile.Template.Filename}.json";
                default:
                    return TemplatePath = "";
            }
        }

        public List<kCSTemplateTextureAbsolutePath> GetTexturesInFolder(string textureFolder, bool ShowFileDoesNotExistMessage = false)
        {
            string TemplatePath = GetLowestTemplatePath(textureFolder);
            List<kCSTemplateTextureAbsolutePath> MatchedFiles = new List<kCSTemplateTextureAbsolutePath>();

            if (TemplatePath != "")
            {
                if (File.Exists(TemplatePath))
                {
                    kCSTemplateClass JSONTemplateFolder =
                        JsonConvert.DeserializeObject<kCSTemplateClass>(File.ReadAllText(TemplatePath));

                    string[] textureFolderPNGs = Directory.GetFiles(textureFolder, "*.png", SearchOption.TopDirectoryOnly);
                    HashSet<string> existingFiles = new HashSet<string>(textureFolderPNGs, StringComparer.OrdinalIgnoreCase);

                    foreach (kCSTemplateTexture TextureEntry in JSONTemplateFolder.UsedTextures)
                    {
                        string PathUsed = "";
                        string TexturePackPath = Path.Combine(textureFolder, $"{MainDefinitions.GameName}{TextureEntry.TexturePackFilename}.png");
                        string AltPath = Path.Combine(textureFolder, $"{TextureEntry.AlternativeFilename}.png");

                        if (existingFiles.Contains(TexturePackPath)) PathUsed = TexturePackPath;
                        else if (existingFiles.Contains(AltPath)) PathUsed = AltPath;

                        if (PathUsed != "")
                        {
                            kCSTemplateTextureAbsolutePath AddedTexture = new kCSTemplateTextureAbsolutePath();
                            AddedTexture.Title = TextureEntry.Title;
                            AddedTexture.Display = TextureEntry.Display;
                            AddedTexture.TexturePackFilename = TextureEntry.TexturePackFilename;
                            AddedTexture.AlternativeFilename = TextureEntry.AlternativeFilename;
                            AddedTexture.AbsolutePath = PathUsed;
                            AddedTexture.RAM = TextureEntry.RAM;
                            AddedTexture.RAMFormat = TextureEntry.RAMFormat;

                            MatchedFiles.Add(AddedTexture);
                        }
                    }
                }
                else if (ShowFileDoesNotExistMessage)
                    MessageBox.Show(String.Format(Resources.TemplatePathDoesNotExist, Path.GetFileName(TemplatePath)));
            }

            return MatchedFiles;
        }
    }
}
