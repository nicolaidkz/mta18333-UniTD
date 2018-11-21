#
#import UnityEngine
#from UnityEngine import *
import cv2 as cv2
import numpy as np
from matplotlib import pyplot as plt
import time
import sys


def showImg(img_):

	# function that bundles all the plt calls with a sanity-check on the image.
    print("image load complete")
    plt.imshow(img_, cmap='gray')                       # now we call the show image feature of plt (and make sure to not show intensity with color!)
    plt.yticks([])                                      # remove y scale
    plt.xticks([])                                      # remove x scale
    plt.show()                                          # show the plot containing the image



device = 1												# we want second camera in line, since we are expecting a built in webcam
capture = cv2.VideoCapture(device)						# we want to capture video from device
p1t1_array = []
template_p1t1 = cv2.imread("template_p1t1.jpg")
frame = capture.read()[1]								# we grab and retrieve one single frame, and save it as frame
file_name = "testing.png"								# path of the saved image
cv2.imwrite(file_name, frame)							# save image to path
testImg = cv2.imread(file_name)							# load image as variable testImg
global errorCode
paths = sys.path

def detectShape(template_, frame_):
	# empty space to return "nothing found"
	gray_img = cv2.cvtColor(frame_, cv2.COLOR_BGR2GRAY)	# convert image to grayscale
	template = cv2.cvtColor(template_, cv2.COLOR_BGR2GRAY) # convert template to grayscale

	result = cv2.matchTemplate(gray_img, template, cv2.TM_CCOEFF_NORMED) # run the template matching and save as result
	print("template matching..")
	# debug for visible representation of detection
	print("displaying match at position: ")
	w, h = template.shape[::-1]							# x and y coordinates of detected object
	location = np.where(result >= 0.7)					# 0.7 is accuracy used when finding position???
														# return x and y coordinates of detected object

	for pt in zip(*location[::-1]):						
		cv2.rectangle(frame_, pt, (pt[0] + w, pt[1] + h), (0,0,255), 3)
	
	try:
		p1t1_array.append([pt[0],pt[1]])
		#print(errorCode)
		return "no errors"
	except Exception:
		print ("something went horribly wrong")
		return "nothing found"
		#print(errorCode)
	

	#showImg(frame)

errorCode = detectShape(template_p1t1, testImg)

print(p1t1_array)	
print(errorCode)
showImg(testImg)
print(sys.path)

