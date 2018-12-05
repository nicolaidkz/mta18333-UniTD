#pragma once
#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include<iostream>

class OpenCV
{
private:
	
public:
	cv::Mat img;
	// we might as well initialize the kernels as well:
	// (-2 makes sure we get the original color image)
	cv::Mat p1t1_kernel = cv::imread("template_p1t1.jpg", -2);
	cv::Mat p1t2_kernel = cv::imread("path", -2);
	cv::Mat p2t1_kernel = cv::imread("path", -2);
	cv::Mat p2t2_kernel = cv::imread("path", -2);
	OpenCV();
	~OpenCV();
	void detectTower(cv::Mat kernel, cv::Mat frame);
	int displayImageTest();
	void cameraFeed();
};

