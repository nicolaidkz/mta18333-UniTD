#include "OpenCV.h"
#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include<iostream>


OpenCV::OpenCV()
{
}


OpenCV::~OpenCV()
{
}

// Here we detects our webcam and get a live feed from it
void OpenCV::cameraFeed()
{
	// open the video camera no. 0
	cv::VideoCapture cap(1);

	//// Get the width of frames of the video
	//double cWidth = cap.get(cv::CAP_PROP_FRAME_WIDTH);
	//// Get the height of frames of the video
	//double cHeight = cap.get(cv::CAP_PROP_FRAME_HEIGHT);

	//std::cout << "Frame size: " << cWidth << " x " << cHeight << std::endl;

	cv::Mat frame; cap >> frame;

	//// Read a new frame from the video
	//bool bSuccess = cap.read(frame);

	//// if not successful break the loop
	//if (!bSuccess)
	//{
	//	std::cout << "Cannot read a frame from video stream" << std::endl;
	//}
	//else if (bSuccess)
	//{
	//	frame = cap.read(frame);
	//}

	if (frame.empty())
	{
		std::cerr << "Something is wrong with the webcam, could not get frame." << std::endl;
	}
	// Save the frame into a file
	cv::imwrite("captFrame.jpg", frame); // A JPG FILE IS BEING SAVED

	OpenCV::img = cv::imread("captFrame.jpg");

	//detectTower(OpenCV::p1t1_kernel, frame);

}

// here is our method for detecting towers,
// it takes two arguments: the kernel and the frame 
void OpenCV::detectTower(cv::Mat kernel, cv::Mat frame)
{
	// we create variables to hold a greyscale versions
	cv::Mat gKernel;
	cv::Mat gFrame;
	// and then we actually convert them to greyscale
	cv::cvtColor(kernel, gKernel, cv::COLOR_BGR2GRAY);
	cv::cvtColor(frame, gFrame, cv::COLOR_BGR2GRAY);
	// we also need a variable for the result of our template matching
	cv::Mat result;
	// then we can run the actual matching, using a normed cross-coefficient
	cv::matchTemplate(gFrame, gKernel, result, cv::TM_CCOEFF_NORMED);

	cv::imwrite("result.png", result);
	//for(pt in zip ) <- no clue how to do this part in c++, also don't know if it's needed!

	// imshow for test of method
	cv::Mat img;
	
	img = cv::imread("result.png");
	std::cout << "Reading..." << std::endl;
	
	cv::namedWindow("testW");
	std::cout << "Creating Window..." << std::endl;
	
	cv::imshow("testW", img);
	std::cout << "Showing Image..." << std::endl;
}

int OpenCV::displayImageTest()
{
	cv::Mat img;

	img = cv::imread("template_p1t1.jpg");
	if (! img.data)
	{
		std::cout << "Image not found!" << std::endl;
		return -1;
	}

	cv::namedWindow("testW");

	cv::imshow("testW", img);

	cv::waitKey(0);
}