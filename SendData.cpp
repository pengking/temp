#include <rtpsession.h>  
#include <rtpudpv4transmitter.h>  
#include <rtpipv4address.h>  
#include <rtpsessionparams.h>  
#include <rtperrors.h>  
#include <rtplibraryversion.h>  
#include <stdlib.h>  
#include <stdio.h>  
#include <iostream>  
#include <string>  
  
using namespace jrtplib;  
  
void checkerror(int rtperr)  
{  
    if (rtperr < 0)  
    {  
        std::cout << "ERROR: " << RTPGetErrorString(rtperr) << std::endl;  
        exit(-1);  
    }  
}  
  
int main(void)  
{ 
    #ifdef WIN32  
    WSADATA dat;  
    WSAStartup(MAKEWORD(2,2),&dat);  
    #endif // WIN32 

    int i;  
    int num;  
    int status;  
      
    RTPSession sess;  
    uint16_t portbase = 6666;    
    uint16_t destport = 6664;  
  
#if 0  
    uint32_t destip;      
    destip    = inet_addr("192.168.0.6");   
    if (destip == INADDR_NONE)  
    {  
        std::cerr << "Bad IP address specified" << std::endl;  
        return -1;  
    }  
    destip = ntohl(destip);  
#else  
    uint8_t destip[]={10,142,62,193};  
#endif   
  
    std::cout << "Number of packets you wish to be sent:" << std::endl;  
    std::cin >> num;  
      
    RTPUDPv4TransmissionParams transparams;  
    RTPSessionParams sessparams;  
      
    sessparams.SetOwnTimestampUnit(1.0/10.0);         
      
    sessparams.SetAcceptOwnPackets(true);  
    transparams.SetPortbase(portbase);  
    status = sess.Create(sessparams,&transparams);    
    checkerror(status);  
      
    RTPIPv4Address addr(destip,destport);  
      
    status = sess.AddDestination(addr);  
    checkerror(status);  
      
    for (i = 1 ; i <= num ; i++)  
    {  
        printf("\nSending packet %d/%d\n",i,num);  
          
        status = sess.SendPacket((void *)"1234567890",10,0,false,10);  
        checkerror(status);       
        RTPTime::Wait(RTPTime(1,0));  
    }  
      
    sess.BYEDestroy(RTPTime(10,0),0,0);  
      
    return 0;  
}  