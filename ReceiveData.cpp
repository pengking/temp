#include <rtpsession.h>  
#include <rtpudpv4transmitter.h>  
#include <rtpipv4address.h>  
#include <rtpsessionparams.h>  
#include <rtperrors.h>  
#include <rtplibraryversion.h>  
#include <rtppacket.h>  
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
    
    RTPSession sess;  
    uint16_t portbase = 6664;  
    int status;  
    bool done = false;  
  
    RTPUDPv4TransmissionParams transparams;  
    RTPSessionParams sessparams;  
    sessparams.SetOwnTimestampUnit(1.0/10.0);         
      
    sessparams.SetAcceptOwnPackets(true);  
  
    transparams.SetPortbase(portbase);  
    status = sess.Create(sessparams,&transparams);    
    checkerror(status);  
  
    sess.BeginDataAccess();  
    RTPTime delay(0.020);  
    RTPTime starttime = RTPTime::CurrentTime();  
      
    while (!done)  
    {  
        status = sess.Poll();  
        checkerror(status);  
              
        if (sess.GotoFirstSourceWithData())  
        {  
            do  
            {  
                RTPPacket *pack;  
                  
                while ((pack = sess.GetNextPacket()) != NULL)  
                {  
                    std::cout << pack->GetPayloadData() << std::endl;  
                    sess.DeletePacket(pack);  
                }  
            } while (sess.GotoNextSourceWithData());  
        }  
                  
        RTPTime::Wait(delay);  
        RTPTime t = RTPTime::CurrentTime();  
        t -= starttime;  
        if (t > RTPTime(60.0))  
            done = true;  
    }  
      
    sess.EndDataAccess();  
    delay = RTPTime(10.0);  
    sess.BYEDestroy(delay,0,0);  
      
    return 0;  
}  