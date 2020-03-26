
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


/// <summary>
/// Ce programme sert à choisir où on va enregistrer le fichier et à effectuer l'enregistrement
/// </summary>

public class SaveSystem
{

    public static void SaveVolume (PauseMenu2 slidos)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/volume.jmjarre";  //chemin d'accès du fichier
        FileStream stream = new FileStream(path, FileMode.Create);

        VolumeData data = new VolumeData(slidos);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static VolumeData LoadVolume()
    {
        string path = Application.persistentDataPath + "/volume.jmjarre";  
        if (File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            VolumeData data = formatter.Deserialize(stream) as VolumeData;
            stream.Close();

            return data;
        }
        else    //si on n'a pas trouvé le chemin, alors il y a une erreur
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
