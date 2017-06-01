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
    RTPUDPv4TransmissionParams transparams;  
    RTPSessionParams sessparams;  
    list<uint32_t> localip;  
    RTPSession sess;  
    uint16_t portbase=8012;  
    uint32_t destip,srcip;  
    //string ipstr="239.255.0.1";  
    //string ipsrc="114.212.114.200";  
    string ipstr="10.142.62.193";  
    //string ipsrc="114.212.118.99"; 
    
    //Local Ip Address
    //string ipsrc = "10.160.149.246";
    string ipsrc = "10.142.62.193";

    int status,i,num;  
    destip=inet_addr(ipstr.c_str());//将字符串转换为32位网络字节序。  
    srcip=inet_addr(ipsrc.c_str());  
    destip=ntohl(destip);//将32位网络字节序转换成主机字节序  
    srcip=ntohl(srcip);  
    localip.push_back(srcip);  
  
    sessparams.SetOwnTimestampUnit(1.0/8000);  
  
    sessparams.SetAcceptOwnPackets(true);  
    transparams.SetPortbase(portbase);  
    //transparams.SetLocalIPList(localip);  
    transparams.SetBindIP(srcip);  
    transparams.SetMulticastInterfaceIP(srcip);  
    RTPIPv4Address addr(destip,portbase);  
    status = sess.Create(sessparams,&transparams);  
    checkerror(status);  
    status=sess.SupportsMulticasting();  
    checkerror(status);  
    status=sess.JoinMulticastGroup(addr);  
    checkerror(status);  
    //sess.SetDefaultPayloadType(96);  
    //sess.SetDefaultMark(false);  
    //sess.SetDefaultTimestampIncrement(160);  
  
    while(1)  
    {  
        sess.BeginDataAccess();  
  
        if(sess.GotoFirstSourceWithData())  
        {  
            do  
            {  
                RTPPacket *pack;  
                uint32_t packetLen;  
                uint8_t *packetData;  
                uint8_t j = 11;  
                 while ((pack = sess.GetNextPacket()) != NULL)  
                {  
                    packetLen = pack->GetPacketLength() - 1;  
                    packetData = pack->GetPacketData();          
                    printf("RECV data: ");  
                    while(j++ < packetLen)  
                    {  
                            printf("%c", *(packetData + j));  
                    }  
                    printf("\n");  
                    sess.DeletePacket(pack);  
                }  
  
  
            }while(sess.GotoNextSourceWithData());  
  
        }  
        sess.EndDataAccess();  
  
    }  
  
    return 0;  
}  