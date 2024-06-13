using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataPersistence;
using DataPersistence.Data;

public class PersistentTheme : PersistentDataBehaviour
{
    [PersistentProperty] public int ThemeIndex { get; set; }
    [PersistentProperty] public bool ClassicTheme {  get; set; }

    private void Start()
    {
        Load();
    }
}
