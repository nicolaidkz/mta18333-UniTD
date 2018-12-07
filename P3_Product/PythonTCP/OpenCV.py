import cv2 as cv
import numpy as np
from matplotlib import pyplot as plt
import time

class OpenCV:
    # we want second camera in line, since we are expecting a built in webcam
    device = 1
    # we want to capture video from device
    capture = cv.VideoCapture(device)
    # template image for player1tower1
    p1t1_array = []
    p1t2_array = []
    p2t1_array = []
    p2t2_array = []
    template_p1t1 = cv.imread("template_p1t1.jpg")
    template_p1t2 = cv.imread("template_p1t2.jpg")
    template_p2t1 = cv.imread("template_p2t1.jpg")
    template_p2t2 = cv.imread("template_p2t2.jpg")
    # we grab and retrieve one single frame, and save it as frame
    frame = capture.read()[1]
    # path of the saved image
    file_name = "testing.png"
    # save image to path
    cv.imwrite(file_name, frame)
    # load image as variable testImg
    testImgP1t1 = cv.imread(file_name)


    def detectShape(template_, frame_, towerArray_):
        # empty space to return "nothing found"
        gray_img = cv.cvtColor(frame_, cv.COLOR_BGR2GRAY)   # convert image to grayscale
        template = cv.cvtColor(template_, cv.COLOR_BGR2GRAY)  # convert template to grayscale

        result = cv.matchTemplate(gray_img, template, cv.TM_CCOEFF_NORMED)      # run the template matching and save as result
        print("template matching..")
        # debug for visible representation of detection
        print("displaying match at position: ")
        w, h = template.shape[::-1]                         # x and y coordinates of detected object
        location = np.where(result >= 0.7)                  # 0.7 is accuracy used when finding position???
                                                            # return x and y coordinates of detected object

        for pt in zip(*location[::-1]):
            cv.rectangle(frame_, pt, (pt[0] + w, pt[1] + h), (0, 0, 255), 3)

        try:
            towerArray_.append([pt[0], pt[1]])
            return towerArray_
        except Exception:
            print("something went horribly wrong")
            towerArray_.append([0, 0])
            return towerArray_

