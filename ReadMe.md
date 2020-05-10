# RTP载荷PS流

> 本文主要记录RTP载荷PS流情况下对PS流解析处理，其中PS流主要是从文件中读取。其实主要在于分析PS流相关信息。

##　PS流头

> 针对H264 做如下PS 封装：每个IDR NALU 前一般都会包含SPS、PPS 等NALU，因此将SPS、PPS、IDR 的NALU 封装为一个PS 包，包括ps 头，然后加上PS system header，PS system map，PES header+h264 raw data。所以一个IDR NALU PS 包由外到内顺序是：PSheader| PS system header | PS system Map | PES header | h264 raw data。对于其它非关键帧的PS 包，就简单多了，直接加上PS头和PES 头就可以了。顺序为：PS header | PES header | h264raw data。以上是对只有视频video 的情况，如果要把音频Audio也打包进PS 封装，也可以。当有音频数据时，将数据加上PES header 放到视频PES 后就可以了。顺序如下：PS 包=PS头|PES(video)|PES(audio)，再用RTP 封装发送就可以了。本段参考了如下[网址](http://www.cnblogs.com/lihaiping/p/4181607.html),该网站下详细描述了PS头、PS系统头、PES头等数据结构的实现以及在流中的排布方式。

> 然后在相关网站中去下载PS头文件，[here](https://www.oschina.net/code/snippet_99626_23737).以及参考pudn上的pes提取代码完成PS文件中的视频数据提取,文件名为ps_packet_parse

## 代码实现

> 开始时验证了[网址](http://www.cnblogs.com/lihaiping/p/4181607.html)中的ps头以及psh头等读取操作。然后参考ps_packet_parse，完成视屏裸流的获取到mp4文件中。

## 参考

## 说明

http://gnurantudoc.sourceforge.net/voip/corso_global1/include/RTP_forum.pdf

```
import os
import os.path
import zipfile
import json
import sys
import shutil
from compressFile import *

class LinuxCopyConfig(object):
	def __init__(self):
		self.linuxCopyDirs = [
			"program_linux64"
			#"config",
			#"demo_cases"
		]
		pass
	pass

class WindowsCopyConfig(object):
	def __init__(self):
		pass
	pass

class FilesCopyConfig(object):
	pass

class CopyAndCompressFile(object):

	def __init__(self, resultName = None, FilesPath = None, WinodwsBinaryPath = None, LinuxBinaryPath = None):
		self.ResultFileName = resultName;
		self.WinodwsBinaryPath = WinodwsBinaryPath;
		self.LinuxBinaryPath = LinuxBinaryPath;
		self.FilesPath = FilesPath;
		pass

	def PrepareFiles(self):
		if(self.ResultFileName == None or self.WinodwsBinaryPath == None or self.LinuxBinaryPath == None ):
			print "ResultFileName {0} WinodwsBinaryPath {1} or LinuxBinaryPath {2} is None".format(self.ResultFileName, self.WinodwsBinaryPath, self.LinuxBinaryPath);
			return;

		if(not os.path.exists(self.WinodwsBinaryPath) or not os.path.exists(self.LinuxBinaryPath)):
			print "WinodwsBinaryPath {0} or LinuxBinaryPath {1} not exists".format(self.WinodwsBinaryPath, self.LinuxBinaryPath);
			return;

		if(os.path.exists(self.ResultFileName)):
			shutil.rmtree(file_directory);

		os.path.mkdirs(self.ResultFileName);
		linuxConfig = LinuxCopyConfig();
		windowsConfig = WindowsCopyConfig();
		filesConfig   = FilesCopyConfig();

		self.CopyFiles(self.FilesPath, filesConfig);
		self._ExtractAndCopyLinuxBinary(self.LinuxBinaryPath, linuxConfig);
		self._CopyWindowsBinary(self.WinodwsBinaryPath, windowsConfig);
		pass

	def GetCompressFile(self):
		filename = self.ResultFileName + ".zip";
		pass

	def _ExtractAndCopyLinuxBinary(self, zipBinary, linuxConfig):
		file_directory = "linux_program_files";
		if(os.path.exists(file_directory)):
			shutil.rmtree(file_directory);
		cf = CompressFiles();
		cf.Extractfile(zipBinary,file_directory);

		if(not os.path.exists(self.ResultFileName)):
			print ("ResultFileName {0} not exists".format(self.ResultFileName))
			return
			pass

		for f in linuxConfig.linuxCopyDirs:
			fullpath = os.path.join(self.ResultFileName, f);
			if(not os.path.exists(fullpath)):
				os.mkdirs(fullpath);
			copyfilepath = os.path.join(file_directory,f);
			files = os.listdir(copyfilepath);
			for f in files:
				filesfullpath = os.path.join(copyfilepath, f);
				shutil.copy(filesfullpath, fullpath)
				pass #end for f
			pass #end for dirs
		pass

	def _CopyWindowsBinary(self, filepath, windowsConfig):
		pass

	def CopyFiles(self, filepath, filesConfig):
		self._CopyWindowsBinary(filepath,filesConfig);
		pass


	pass
	```
www.semanticdesigns.com/deliverEval/SD_Cpp~GCC5_TimingProfiler.1.2.6?key=fafd0f83c2
