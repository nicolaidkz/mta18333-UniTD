#pragma once
#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include<iostream>

class OpenCV
{
public:
	OpenCV();
	~OpenCV();
	void detectTower(cv::Mat kernel, cv::Mat frame);
	int displayImageTest();
	int cameraFeed();
};

