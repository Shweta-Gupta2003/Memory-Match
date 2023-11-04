using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private readonly Dictionary<EPuzzleCategories,string> _puzzleCatDirectory = new Dictionary<EPuzzleCategories,string>();
    private int settings;
    private const int SettingsNumber = 2;
    private bool _muteFxPermanently = false;


    public enum EPairNumber
    {
        NotSet = 0,
        E10Pairs = 10,
        E15Pairs = 15,
        E20Pairs = 20,
    }

    public enum EPuzzleCategories    {
        NotSet,
        Fruits,
        Vegetables
    }

    public struct Settings
    {
        public EPairNumber PairsNumber;
        public EPuzzleCategories PuzzleCategory;
    };

    private Settings gameSettings;

    public static GameSettings Instance;

    void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(this);

        }
    }
    void Start()
    {
        SetPuzzleCatDirectory();
        gameSettings = new Settings();
        ResetGameSettings();
        
    }

    private void SetPuzzleCatDirectory()
    {
        _puzzleCatDirectory.Add(EPuzzleCategories.Fruits, "Fruits");
        _puzzleCatDirectory.Add(EPuzzleCategories.Vegetables,"Vegetables");
    }

    public void SetPairNumber(EPairNumber Number)
    {
        if(gameSettings.PairsNumber == EPairNumber.NotSet)
        settings++;

        gameSettings.PairsNumber = Number;
    }

    public void SetCategories(EPuzzleCategories cat)
    {
        if(gameSettings.PuzzleCategory == EPuzzleCategories.NotSet)
        settings++;

        gameSettings.PuzzleCategory = cat;
    }

    public EPairNumber GetPairNumber()
    {
        return gameSettings.PairsNumber;
    }

    public EPuzzleCategories GetPuzzelCategory()
    {
        return gameSettings.PuzzleCategory;
    }

    public void ResetGameSettings()
    {
        settings = 0;
        gameSettings.PuzzleCategory = EPuzzleCategories.NotSet;
        gameSettings.PairsNumber = EPairNumber.NotSet;


    }

    public bool AllSettingsReady()
    {
        return settings== SettingsNumber;
    }

    public string GetMaterialDirectoryName()
    {
        return "Materials/";
    }

    public string GetPuzzleCategoryTextureDirectoryName()
    {
        if(_puzzleCatDirectory.ContainsKey(gameSettings.PuzzleCategory))
        {
            return "Graphics/PuzzleCat/" + _puzzleCatDirectory[gameSettings.PuzzleCategory] + "/";
        }
        else
        {
            Debug.LogError("Error:Cannot get directory name ");
            return "";
        }

    }

    public void MuteSoundEffectPermanently(bool muted)
    {
        _muteFxPermanently = muted;

    }

    public bool IsSoundEffectMutedPermanently()
    {
        return _muteFxPermanently;
    }
}
