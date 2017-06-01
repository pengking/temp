#include "rtpsession.h"  
#include "rtpudpv4transmitter.h"  
#include "rtpipv4address.h"  
#include "rtpsessionparams.h"  
#include "rtperrors.h"  
#include "rtppacket.h"  
#ifndef WIN32  
    #include <netinet/in.h>  
    #include <arpa/inet.h>  
#else  
    #include <winsock2.h>  
    #include<windows.h>  
#endif // WIN32  
#include <stdlib.h>  
#include <stdio.h>  
#include <iostream>  
#include <string>  
  
using namespace jrtplib;  
using namespace std;  
  
  
void checkerror(int rtperr)  
{  
    if(rtperr<0)  
    {  
        cout<<"ERROR:"<<RTPGetErrorString(rtperr)<<endl;  
        exit(-1);  
    }  
}  

int main()  
{  
  
    #ifdef WIN32  
    WSADATA dat;  
    WSAStartup(MAKEWORD(2,2),&dat);  
    #endif // WIN32  
  
    list<uint32_t> localip;  
  
    RTPSession sess;  
    uint16_t portbase=6666,destport=7821;  
    uint32_t destip,srcip;  

    //Destination Ip Address
    //string ipstr="10.160.149.246"; 
    string ipstr="10.142.62.193";
    //string ipsrc="114.212.118.99"; 
    
    //Local Ip Address
    string ipsrc = "10.142.62.193";


    int status,i,num;  
    destip=inet_addr(ipstr.c_str());//将字符串转换为32位网络字节序。  
    srcip=inet_addr(ipsrc.c_str());  
  
    if(destip==INADDR_NONE)  
    {  
        cout<<"bad destip address"<<endl;  
        exit(-1);  
    }  
    destip=ntohl(destip);//将32位网络字节序转换成主机字节序  
    srcip=ntohl(srcip);  
    localip.push_back(srcip);  
    //设置传输参数和会话参数  
    RTPUDPv4TransmissionParams transparams;  
    RTPSessionParams sessparams;  
  
    // IMPORTANT: The local timestamp unit MUST be set, otherwise  
    //            RTCP Sender Report info will be calculated wrong  
    // In this case, we'll be sending 10 samples each second, so we'll  
    // put the timestamp unit to (1.0/10.0)  
    sessparams.SetOwnTimestampUnit(1.0/8000);  
  
    sessparams.SetAcceptOwnPackets(true);  
    transparams.SetPortbase(portbase);  
    transparams.SetLocalIPList(localip);  
    transparams.SetMulticastInterfaceIP(srcip);  
    transparams.SetMulticastTTL(255);  
    status = sess.Create(sessparams,&transparams);  
    checkerror(status);  
  
    RTPIPv4Address addr(destip,destport);  
  
    status=sess.AddDestination(addr);  
    checkerror(status);  
  
    if(sess.SupportsMulticasting())  
    {  
        cout<<"支持组播"<<endl;  
    }  
    char *p=new char[100];  
    i=0;  
    sess.SetDefaultPayloadType(96);  
    sess.SetDefaultMark(false);  
    sess.SetDefaultTimestampIncrement(160);  
    while(1)  
    {  
        i++;  
        memset(p,0,100);  
        sprintf(p,"bababba:%d",i);  
        status=sess.SendPacket(p,100);  
        cout<<i<<endl;;  
    }  
  
    sess.BYEDestroy(RTPTime(10,0),0,0);  
    return 0;  
}  