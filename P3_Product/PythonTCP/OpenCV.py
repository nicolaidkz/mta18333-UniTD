# import the different libaries we are going to use.
import cv2 as cv
import numpy as np
from matplotlib import pyplot as plt
import time

class OpenCV:
    # since we want to use the webcam as our main camera, we are makeing a device variable, where 0 is the bult in webcam in the laptop and 1 is an external webcam
    device = 1
    # we want to capture video from device
    capture = cv.VideoCapture(device)
    # template image for player1tower1, Player1tower2 Player2tower1 and Player2tower2
    p1t1_array = []
    p1t2_array = []
    p2t1_array = []
    p2t2_array = []
    template_p1t1 = cv.imread("template_p1t1.jpg")
    template_p1t2 = cv.imread("template_p1t2.jpg")
    template_p2t1 = cv.imread("template_p2t1.jpg")
    template_p2t2 = cv.imread("template_p2t2.jpg")
    # we grab and retrieve one single frame, and save it as frame
    frame = capture.read()[device]
    # path of the saved image
    file_name = "testing.png"

    # save image to path
    gray_img = cv.cvtColor(frame, cv.COLOR_BGR2GRAY)  # convert image to grayscale
    aTH = cv.adaptiveThreshold(gray_img, 200, cv.ADAPTIVE_THRESH_MEAN_C, cv.THRESH_BINARY, 49, 8)
    cv.imwrite(file_name, aTH)
    
    # load image as variable testImg
    testImgP1t1 = cv.imread(file_name)

    #this is our method that we call later, that does the actual template mathing.
    def detectShape(template_, frame_, towerArray_):

        #take all the template images and convert them to gray, binary  
        gray_img = cv.cvtColor(frame_, cv.COLOR_BGR2GRAY)   # convert image to grayscale
        template = cv.cvtColor(template_, cv.COLOR_BGR2GRAY)  # convert template to grayscale
        aTH = cv.adaptiveThreshold(gray_img, 200, cv.ADAPTIVE_THRESH_MEAN_C, cv.THRESH_BINARY, 191, 3) #adaptive threshold, is when you change the area of the template matching.
        _,bTemp = cv.threshold(template, 80, 200, cv.THRESH_BINARY)
        # save images of the game screen in both binary and adaptive tresh hold
        cv.imwrite("templateEx.jpg", bTemp)
        cv.imwrite("realImg.jpg", aTH)

        result = cv.matchTemplate(aTH, bTemp, cv.TM_CCOEFF_NORMED) # run the template matching and save as result
        # print("template matching..")
        
        print("displaying match at position: ")
        w, h = bTemp.shape[::-1]                         # x and y coordinates of detected object
        location = np.where(result >= 0.60)                  # 0.6 is the accuracy of the the template is detected, 1 is the exact match and 0 is no match.
                                                      

        #for loop that runs trough the image and finds the best value for the template matvhing and makes a rectangle.
        for pt in zip(*location[::-1]):
            cv.rectangle(frame_, pt, (pt[0] + w, pt[1] + h), (0, 0, 255), 3)

        # if an object is found it appends a location to the tower array, otherwise it sets the loctaion to 0 and an error.
        try:
            towerArray_.append([pt[0], pt[1]])
            return towerArray_
        except Exception:
            print("something went horribly wrong")
            towerArray_.append([0, 0])
            return towerArray_
        
     #this is our method that we call later, that does the actual grid detection.
    def detectGrid(frame_):
        # save the image from the video capture
        img = frame_
        
        #using different filters, to make less noise in the template matching.
        img_hsv = cv.cvtColor(img, cv.COLOR_RGB2GRAY)
        median = cv.medianBlur(img_hsv, 5)
        gauss_ = cv.GaussianBlur(median, (5, 5), 0)
        blur = cv.bilateralFilter(gauss_, 9, 75, 75)
       
        _, threshold = cv.threshold(blur, 200, 200, cv.THRESH_BINARY)
        _, contours, _ = cv.findContours(threshold, cv.RETR_TREE, cv.CHAIN_APPROX_NONE)
        # empty array
        rectangle = []

        font = cv.FONT_HERSHEY_COMPLEX

        #loops trough the images and uses contours to locate the template image.
        for cnt in contours:
            approx = cv.approxPolyDP(cnt, 0.01 * cv.arcLength(cnt, True), True)
            cv.drawContours(img, [approx], 0, 0, 5)
            x = approx.ravel()[0]
            y = approx.ravel()[1]

            if len(approx) == 4:
                cv.putText(img, "Rectangle", (x, y), font, 1, 0)
                rectangle.append([x, y])
        
        #we print the location of the rectangle and return the value.
        print(rectangle)

        return rectangle

#   after every run we clear the arrays.
    def clearArrays(ar1, ar2, ar3, ar4):
        ar1.clear()
        ar2.clear()
        ar3.clear()
        ar4.clear()


