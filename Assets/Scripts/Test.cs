using UnityEngine;
using System.Collections;
using com.CR.GameDataModel;
using System;
using System.Text;

public class Test : MonoBehaviour {
    void Start() {
        DataCenter.packetProcesser.event_Attack += Callback_Attack;

        Attack attack = new Attack();
        attack.hurtValue = 1000;
        attack.weaponId = 100;
        attack.weaponName = "Weapon 001";

        byte[] data = DataCenter.PacketBuilder.Build( attack );

        DataCenter.PacketParser.Parse( data );

    }

    void OnDiable() {
        DataCenter.packetProcesser.event_Attack -= Callback_Attack;

    }

    void Callback_Login(Login message) {

    }

    void Callback_Player( Player player ) {

    }

    void Callback_Attack( Attack attack ) {
        Debug.Log( attack.weaponName + "    " + attack.hurtValue );
    }

  

  


}
