using System;
using GameSocket;
using UnityEngine;


/// <summary>
/// DemoCMDProcess 的摘要说明
/// 
/// <para>____________________________________________________________</para>
/// <para>Version：V1.0.0</para>
/// <para>Namespace：GameSocket</para>
/// <para>Author: wboy    Time：2014/4/25 12:32:18</para>
/// </summary>
public class DemoCMDProcess : IProcessCMD
{
    private const int packetMaxLength = 10240;
    private SocketCallBack mCallback;

    private int writeIndex = 0;
    private byte[] buffer;

    public DemoCMDProcess(SocketCallBack Callback)
    {
        this.buffer = new byte[packetMaxLength];
        this.mCallback = Callback;
    }

    override public void IncomingData(byte[] data, int actualSize)
    {
        if (this.writeIndex + actualSize >= packetMaxLength)
        {
            throw new Exception("Buffer Overflow!");
        }
        Array.Copy(data, 0, this.buffer, this.writeIndex, actualSize);
        this.writeIndex += actualSize;
        Debug.Log("writeIndex ： " + writeIndex + "     " + Demo.packetLength);
        while (this.writeIndex >= Demo.packetLength)
        {
            byte[] bytes = new byte[Demo.packetLength];
            Array.Copy(this.buffer, 0, bytes, 0, Demo.packetLength);
            this.mCallback.SendMessage(bytes);
            this.writeIndex = 0;
        }
    }
}
