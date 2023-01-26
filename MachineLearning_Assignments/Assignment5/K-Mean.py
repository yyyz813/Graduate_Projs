'''
In a coloured image, each pixel is of size 3 bytes (RGB).
Each colour can have intensity values from 0 to 255.
The total number of colours which can be represented are 256*256*256.
'''

from matplotlib import pyplot as io
import numpy as np
from PIL import Image
import random
random.seed(40)

def k_means(point, mean, cluster):

    print("\n String with k = %d" % mean)
    flag = True
    time = 0

    (r, c, a) = point.shape  # (row * column * 3) array
    centers = getCenter(point, mean)
    new = np.zeros([r, c], dtype=int)  # Array to image

    while flag:
        flag = replace(point, new, centers)
        time = time + 1
        print("\r program running: %d times " % time, end='')

    return outputImg(new, centers, cluster)


def getCenter(point, mean):

    (r,c,a) = point.shape

    ci = random.randint(0, r - 1)  # randomly pick centroid using k-means++
    cj = random.randint(0, c - 1)

    centroid = [list(point[ci, cj])]

    while (len(centroid) < mean):  # Avoid stackoverflow
        centroid = nextCentroid(point, centroid)
    return centroid


def nextCentroid(point,centroid):  # closest distance from current centroid to next cluster centroid

    d = 0
    next_r = 0
    next_c = 0

    (row, column, a) = point.shape   # (r,c,a)

    for i in range(row):

        for j in range(column):
            distance = 255 * 255 * 3

            for c in centroid:
                distance2 = getDistance(point[i, j], c)
                if (distance2 < distance):
                    distance = distance2

            if (distance > d):
                d = distance
                next_r, next_c = i, j

    centroid.append(list(point[next_r, next_c]))

    return centroid


def getDistance(point, centroid):

    distance2 = 0
    if (len(point) != len(centroid)):
        return None

    for i in range(len(point)):

        if (point[i] >= centroid[i]):
            distance2 += (point[i] - centroid[i]) ** 2  # d = ||xi-Cj||^2
        else:
            distance2 += (centroid[i] - point[i]) ** 2

    return distance2


def replace(point, new, centers):   # Replace each pixel with its centroid points

    flag = newData(point, new, centers)
    centroidChange(point, new, centers)
    return flag


def newData(point, new, centers):

    flag = False
    (r, c) = new.shape

    for i in range(r):

        for j in range(c):
            temp = -1
            distance = 255 * 255 * 3   # Each colour can have intensity values from 0 to 255.

            for (ci, cj) in enumerate(centers):
                distance2 = getDistance(point[i, j],cj)

                if (distance2 < distance):
                    distance = distance2
                    temp = ci

            if (not flag and new[i, j] != temp):
                flag = True
            new[i, j] = temp

    return flag


def centroidChange(point, new, centers):

    (r, c) = new.shape
    category = [[[], [], []] for _ in centers]

    for i in range(r):
        for j in range(c):
            for k in range(3):
                category[new[i, j]][k].append(point[i, j, k])

    for ci in range(len(centers)):
        if (len(category[ci][0]) > 0):
            for k in range(3):
                centers[ci][k] = np.mean(category[ci][k])


def outputImg(new, centers, cluster):

    (r, c) = new.shape

    # Array to image file
    array = np.zeros([r, c, 3], dtype=np.uint8)
    for i in range(r):
        for j in range(c):
            array[i, j] = centers[new[i, j]]

    img = Image.fromarray(array)
    img.save(cluster)
    print("\n The output image is saved as : " + cluster)

    return img


# Driver
k_value = [2, 5, 10, 15, 20]
pictures = ["Penguins.jpg","Koala.jpg",]
for i in pictures:
    image = io.imread(i)  # image is saved as rows * columns * 3 array
    for j in k_value:
        k_means(image, j, (" k= %d " % j) + i)

