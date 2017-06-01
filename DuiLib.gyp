{
  'target_defaults': {
    'conditions': [
      ['OS != "win"', {
        'defines': [
          '_LARGEFILE_SOURCE',
          '_FILE_OFFSET_BITS=64',
        ],
        'conditions': [
          ['OS=="solaris"', {
            'cflags': [ '-pthreads' ],
          }],
          ['OS not in "solaris android"', {
            'cflags': [ '-pthread' ],
          }],
        ],
      }],
    ],

    'link_settings': {
            'libraries': [
              'kernel32.lib',
              'user32.lib',
              'gdi32.lib',
              'winspool.lib',
              'comdlg32.lib',
              'advapi32.lib',
              'shell32.lib',
              'ole32.lib',
              'oleaut32.lib',
              'uuid.lib',
              'odbc32.lib',
              'odbccp32.lib',

              # comctl32 miss will result 
              # error LNK2019 unresolved external symbol __imp__InitCommonControls
              # ref http //bbs.csdn.net/topics/280070106

              'comctl32.lib',
              #'Riched20.lib',
            ],
          },
    'configurations': {
        'Debug': {
          'msvs_settings': {
              'VCCLCompilerTool': {
              # 多线程调试 DLL (/MD)
              'RuntimeLibrary': '2',
              # 不优化 /Od
              'Optimization': '0',
              'DebugInformationFormat': '4',
            },
            'VCLinkerTool': {
            'GenerateDebugInformation': 'true',
            'GenerateMapFile': 'false',
            'IgnoreDefaultLibraryNames': [
                #'Libcmtd.lib'
              ],
            },
          },
        }, # Debug

        'Release': {
          'msvs_settings': {
            'VCCLCompilerTool': {
              # 多线程 DLL (/MD)
              'RuntimeLibrary': '2',
              # 完全优化 /Os
              'Optimization': '2',
              # 使用内部函数 /Oi
              'EnableIntrinsicFunctions': 'true',
              # 程序数据库 (/Zi)
              'DebugInformationFormat': '3',
            },
            'VCLinkerTool': {
              'GenerateDebugInformation': 'true',
              'GenerateMapFile': 'false',

              'IgnoreDefaultLibraryNames': [
                #'Libcmtd.lib'
              ],
            },
          },
        }, # Release

      },
   
  },


  'targets': [

    # PROJECT PLUGIN TEST BEGIN 
    {
      'target_name':'Jrtp',
      'type':'static_library',
      'include_dirs':[
        '../src',
      ],
      'sources':[
        
        '../src/jmutex.cpp',
        '../src/jmutex.h',
        '../src/jmutexautolock.h',
        '../src/jthread.cpp',
        '../src/jthread.h',
        '../src/jthreadconfig.h',
        '../src/rtcpapppacket.cpp',
        '../src/rtcpapppacket.h',
        '../src/rtcpbyepacket.cpp',
        '../src/rtcpbyepacket.h',
        '../src/rtcpcompoundpacket.cpp',
        '../src/rtcpcompoundpacket.h',
        '../src/rtcpcompoundpacketbuilder.cpp',
        '../src/rtcpcompoundpacketbuilder.h',
        '../src/rtcppacket.cpp',
        '../src/rtcppacket.h',
        '../src/rtcppacketbuilder.cpp',
        '../src/rtcppacketbuilder.h',
        '../src/rtcprrpacket.cpp',
        '../src/rtcprrpacket.h',
        '../src/rtcpscheduler.cpp',
        '../src/rtcpscheduler.h',
        '../src/rtcpsdesinfo.cpp',
        '../src/rtcpsdesinfo.h',
        '../src/rtcpsdespacket.cpp',
        '../src/rtcpsdespacket.h',
        '../src/rtcpsrpacket.cpp',
        '../src/rtcpsrpacket.h',
        '../src/rtcpunknownpacket.h',
        '../src/rtpabortdescriptors.cpp',
        '../src/rtpabortdescriptors.h',
        '../src/rtpaddress.h',
        '../src/rtpbyteaddress.cpp',
        '../src/rtpbyteaddress.h',
        '../src/rtpcollisionlist.cpp',
        '../src/rtpcollisionlist.h',
        '../src/rtpconfig.h',
        '../src/rtpdebug.cpp',
        '../src/rtpdebug.h',
        '../src/rtpdefines.h',
        '../src/rtperrors.cpp',
        '../src/rtperrors.h',
        '../src/rtpexternaltransmitter.cpp',
        '../src/rtpexternaltransmitter.h',
        '../src/rtphashtable.h',
        '../src/rtpinternalsourcedata.cpp',
        '../src/rtpinternalsourcedata.h',
        '../src/rtpinternalutils.h',
        '../src/rtpipv4address.cpp',
        '../src/rtpipv4address.h',
        '../src/rtpipv4destination.cpp',
        '../src/rtpipv4destination.h',
        '../src/rtpipv6address.cpp',
        '../src/rtpipv6address.h',
        '../src/rtpipv6destination.cpp',
        '../src/rtpipv6destination.h',
        '../src/rtpkeyhashtable.h',
        '../src/rtplibraryversion.cpp',
        '../src/rtplibraryversion.h',
        '../src/rtplibraryversioninternal.h',
        '../src/rtpmemorymanager.h',
        '../src/rtpmemoryobject.h',
        '../src/rtppacket.cpp',
        '../src/rtppacket.h',
        '../src/rtppacketbuilder.cpp',
        '../src/rtppacketbuilder.h',
        '../src/rtppollthread.cpp',
        '../src/rtppollthread.h',
        '../src/rtprandom.cpp',
        '../src/rtprandom.h',
        '../src/rtprandomrand48.cpp',
        '../src/rtprandomrand48.h',
        '../src/rtprandomrands.cpp',
        '../src/rtprandomrands.h',
        '../src/rtprandomurandom.cpp',
        '../src/rtprandomurandom.h',
        '../src/rtprawpacket.h',
        '../src/rtpsecuresession.cpp',
        '../src/rtpsecuresession.h',
        '../src/rtpselect.h',
        '../src/rtpsession.cpp',
        '../src/rtpsession.h',
        '../src/rtpsessionparams.cpp',
        '../src/rtpsessionparams.h',
        '../src/rtpsessionsources.cpp',
        '../src/rtpsessionsources.h',
        '../src/rtpsocketutil.h',
        '../src/rtpsocketutilinternal.h',
        '../src/rtpsourcedata.cpp',
        '../src/rtpsourcedata.h',
        '../src/rtpsources.cpp',
        '../src/rtpsources.h',
        '../src/rtpstructs.h',
        '../src/rtptcpaddress.cpp',
        '../src/rtptcpaddress.h',
        '../src/rtptcptransmitter.cpp',
        '../src/rtptcptransmitter.h',
        '../src/rtptimeutilities.cpp',
        '../src/rtptimeutilities.h',
        '../src/rtptransmitter.h',
        '../src/rtptypes.h',
        '../src/rtptypes_win.h',
        '../src/rtpudpv4transmitter.cpp',
        '../src/rtpudpv4transmitter.h',
        '../src/rtpudpv6transmitter.cpp',
        '../src/rtpudpv6transmitter.h',


      ],
      'link_settings':{
        'libraries':[
        ]
      },
      'defines':[
        'WIN32',
        'NDEBUG',
        '_WINDOWS',
        'UILIB_EXPORTS',
        '_UNICODE',
        'UNICODE',
       ],

    },

    # PROJECT PLUGIN TEST END

    # PROJECT PLUGIN TEST BEGIN 
    {
      'target_name':'JmutexTest',
      'type':'executable',
      'include_dirs':[
        '../src',
      ],
      'sources':[
        '../tests/readlogfile.cpp',
      ],
      'link_settings':{
        'libraries':[
        'ws2_32.lib',
        './Release/lib/Jrtp.lib'
        ]
      },
      'defines':[
        'WIN32',
        'NDEBUG',
        '_WINDOWS',
        'UILIB_EXPORTS',
        '_UNICODE',
        'UNICODE',
       ],

    },

    # PROJECT PLUGIN TEST END

    # PROJECT PLUGIN TEST BEGIN 
    {
      'target_name':'TcpTest',
      'type':'executable',
      'include_dirs':[
        '../src',
      ],
      'sources':[
        '../tests/tcptest.cpp',
      ],
      'link_settings':{
        'libraries':[
        'ws2_32.lib',
        './Release/lib/Jrtp.lib'
        ]
      },
      'defines':[
        'WIN32',
        'NDEBUG',
        '_WINDOWS',
        'UILIB_EXPORTS',
        '_UNICODE',
        'UNICODE',
       ],

    },

    # PROJECT PLUGIN TEST END

    # BEGIN MULTI-SENDER RTP PROJECT TEST

     {
      'target_name':'MultiSender',
      'type':'executable',
      'include_dirs':[
        '../src',
      ],
      'sources':[
        '../example/MultiSender.cpp',
      ],
      'link_settings':{
        'libraries':[
        'ws2_32.lib',
        './Release/lib/Jrtp.lib'
        ]
      },
      'defines':[
        'WIN32',
        'NDEBUG',
        '_WINDOWS',
        'UILIB_EXPORTS',
        '_UNICODE',
        'UNICODE',
       ],

    },
    # END MULTI-SENDER RTP PROJECT TEST 

    # BEGIN MULTI-SENDER RTP PROJECT TEST

     {
      'target_name':'MultiReceiver',
      'type':'executable',
      'include_dirs':[
        '../src',
      ],
      'sources':[
        '../example/MultiReceiver.cpp',
      ],
      'link_settings':{
        'libraries':[
        'ws2_32.lib',
        './Release/lib/Jrtp.lib'
        ]
      },
      'defines':[
        'WIN32',
        'NDEBUG',
        '_WINDOWS',
        'UILIB_EXPORTS',
        '_UNICODE',
        'UNICODE',
       ],

    },
    # END MULTI-SENDER RTP PROJECT TEST 

    # BEGIN MULTI-SENDER RTP PROJECT TEST

     {
      'target_name':'SendData',
      'type':'executable',
      'include_dirs':[
        '../src',
      ],
      'sources':[
        '../example/SendData.cpp',
      ],
      'link_settings':{
        'libraries':[
        'ws2_32.lib',
        './Release/lib/Jrtp.lib'
        ]
      },
      'defines':[
        'WIN32',
        'NDEBUG',
        '_WINDOWS',
        'UILIB_EXPORTS',
        '_UNICODE',
        'UNICODE',
       ],

    },
    # END MULTI-SENDER RTP PROJECT TEST 

    # BEGIN MULTI-SENDER RTP PROJECT TEST

     {
      'target_name':'ReceiveData',
      'type':'executable',
      'include_dirs':[
        '../src',
      ],
      'sources':[
        '../example/ReceiveData.cpp',
      ],
      'link_settings':{
        'libraries':[
        'ws2_32.lib',
        './Release/lib/Jrtp.lib'
        ]
      },
      'defines':[
        'WIN32',
        'NDEBUG',
        '_WINDOWS',
        'UILIB_EXPORTS',
        '_UNICODE',
        'UNICODE',
       ],

    },
    # END MULTI-SENDER RTP PROJECT TEST 


  ]
}
