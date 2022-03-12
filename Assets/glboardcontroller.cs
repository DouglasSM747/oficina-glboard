using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections.Generic;
using System;

public class glboardcontroller : MonoBehaviour
{
    public GLBoard gLBoard;


    public void IniciarDadosJogo()
    {
        gLBoard.SetLastLogin(dateTime: System.DateTime.Now);
        gLBoard.SetPlayerData("Douglas",  DateTime.Now.ToString(), GENDER.MASCULINO);
    }

    public bool VerificarFaseExiste(string faseId)
    {
        for(int i = 0; i < gLBoard.GetPhasesGames().Count; i++)
        {
            if(gLBoard.GetPhasesGames()[i].phase_id == faseId)
            {
                return true;
            }
        }
        return false;
    }


    async void Start()
    {
        gLBoard = new GLBoard("SSsr8ANwyNt4YjBChrwAyg", "teste");
        await gLBoard.LOAD_USER_DATA();
        IniciarDadosJogo();
        gLBoard.SetQuantPhaseGame(14);

        if (!VerificarFaseExiste("fase1"))
        {
            gLBoard.AddPhaseGame("fase1");
        }

        if (!VerificarFaseExiste("fase2"))
        {
            gLBoard.AddPhaseGame("fase2");
        }

        gLBoard.AddSectionInPhase("fase1", STATUS_SECTION.DERROTA, 0, DateTime.Now, DateTime.Now);
        gLBoard.AddSectionInPhase("fase2", STATUS_SECTION.DERROTA, 0, DateTime.Now, DateTime.Now);
        gLBoard.AddSectionInPhase("fase2", STATUS_SECTION.VITORIA, 100, DateTime.Now, DateTime.Now);

        StartCoroutine(gLBoard.SEND_USER_DATA());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
