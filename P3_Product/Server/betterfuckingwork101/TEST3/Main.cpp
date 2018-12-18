#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include<iostream>
#include<WS2tcpip.h>
#include "OpenCV.h"
#pragma comment (lib, "ws2_32.lib")

// we initialize the arrays to hold positions
// of the four different towers:
int p1t1[], p1t2[], p2t1[], p2t2[];
// we might as well initialize the kernels as well:
// (-2 makes sure we get the original color image)
cv::Mat p1t1_kernel = cv::imread("path", -2);
cv::Mat p1t2_kernel = cv::imread("path", -2);
cv::Mat p2t1_kernel = cv::imread("path", -2);
cv::Mat p2t2_kernel = cv::imread("path", -2);

int main()
{
	OpenCV cvObjectOne;
	//cvObjectOne.cameraFeed();

	// first we initialize winsock
	WSADATA wData;																				// wsastartup data
	WORD version = MAKEWORD(2, 2);																// give us version 2.2

	int wsOK = WSAStartup(version, &wData);														// does not return a 0 if all is working well
	if (wsOK != 0)
	{
		std::cout << "winsock could not be initialized!" << std::endl;
		return 1; // if we cant initialize winsock, throw error!
	}


	// next we create a socket to bind to
	SOCKET listening = socket(AF_INET, SOCK_STREAM, 0); //TCP specific arguments
	if (listening == INVALID_SOCKET)
	{
		std::cerr << "cannot create socket!" << std::endl;
		return 1; // if we cannot create a socket for listening, throw error!
	}

	// bind socket to an IP and a port
	sockaddr_in hint;
	hint.sin_family = AF_INET;
	hint.sin_port = htons(54000);																// host-to-network-short
	hint.sin_addr.S_un.S_addr = INADDR_ANY;														// give us any address plz..
	bind(listening, (sockaddr*)&hint, sizeof(hint));											// notice the casting as pointer of hint addr!

	// assign the socket for listening
	listen(listening, SOMAXCONN);																// we want listening to be a listening socket!

	// wait for a connection
	sockaddr_in client;
	int clientsize = sizeof(client);

	SOCKET clientSocket = accept(listening, (sockaddr*)&client, &clientsize);
	if (clientSocket == INVALID_SOCKET)
	{
		std::cerr << "invalid socket!" << std::endl;
	}

	char host[NI_MAXHOST];																		// client name
	char service[NI_MAXSERV];																	// port client is connected on

	// zero out the memory
	//memset(host, 0, NI_MAXHOST);
	//memset(service, 0, NI_MAXSERV);
	ZeroMemory(host, NI_MAXHOST);
	ZeroMemory(service, NI_MAXSERV);
	if (getnameinfo((sockaddr*)&client, sizeof(client), host, NI_MAXHOST, service, NI_MAXSERV, 0) == 0)
	{
		std::cout << host << " connected on port " << service << std::endl;
	}
	else																						// try and get a name, otherwise just use the ip
	{
		inet_ntop(AF_INET, &client.sin_addr, host, NI_MAXHOST);
		std::cout << host << " connected on port " << ntohs(client.sin_port) << std::endl;
	}

	// close listening socket
	closesocket(listening);
	char buf[4096];

	while (true)
	{
		ZeroMemory(buf, 4096);																	// zero out our buffer
		//memset(buf, 0, 4096);
		// wait for data from client
		int bytesReceived = recv(clientSocket, buf, 4096, 0);
		if (bytesReceived == SOCKET_ERROR)
		{
			std::cerr << "error when receving!" << std::endl;
			break;
		}

		if (bytesReceived == 0)
		{
			std::cerr << "client disconnected, received 0" << std::endl;
			break;
		}
		
		// echo message back to client
		send(clientSocket, buf, bytesReceived + 1, 0);
	}
	// NOTE: This is meant for a RAW CONNECTION!

	// close the socket when we are done with it
	closesocket(clientSocket);
	// shutdown/cleanup winsock
	WSACleanup();

}