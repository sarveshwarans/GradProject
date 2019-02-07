# -*- coding: utf-8 -*-
"""
Created on Sun Sep 16 22:28:43 2018

@author: sarve
"""

import matplotlib.pyplot as trainingData
import numpy as np
from numpy import linalg as la

print('\n')
print('Question 1:')
oneX=np.array([2.5,0.5,2.2,1.9,3.1,2.3,2,1,1.5,1.1])
oneY=np.array([2.4,0.7,2.9,2.2,3.0,2.7,1.6,1.1,1.6,0.9])
print('Given X Dataset is as follows: ')
print(oneX)
print('Given Y Dataset is as follows: ')
print(oneY)
print('\n')

print('Question 2: Plot the graph y(x)')
print('Graph is as follows: ')
trainingData.plot([2.5,0.5,2.2,1.9,3.1,2.3,2,1,1.5,1.1], [2.4,0.7,2.9,2.2,3.0,2.7,1.6,1.1,1.6,0.9], 'ro')
trainingData.axis([0, 4, 0, 4])
trainingData.show()
print('\n')

print('Question 3: Find the mean values of the both x, y.')
threeX=np.array([2.5,0.5,2.2,1.9,3.1,2.3,2,1,1.5,1.1])
print('Mean Value of X: '+str(np.mean(threeX)))
threeY=np.array([2.4,0.7,2.9,2.2,3.0,2.7,1.6,1.1,1.6,0.9])
print('Mean Value of Y: '+str(np.mean(threeY)))
print('\n')

print('Question 4: Calculate the covariance (2x2) matrix')
fourMatrix = np.array([[2.5,0.5,2.2,1.9,3.1,2.3,2,1,1.5,1.1], [2.4,0.7,2.9,2.2,3.0,2.7,1.6,1.1,1.6,0.9]])
print('Covariance of 2x2 Matrix is ')
print(str(np.cov(fourMatrix)))
print('\n')

print('Question 5: Find the eigenvalues and eigenvectors of the covariance matrix.')
fiveW, fiveV = la.eig(np.cov(fourMatrix))
print('Eigen Value is ')
print(fiveW)
print('Eigen Vector is ')
print(fiveV)
print('\n')

print('Question 6: . Compare the vectors to see if there is a vector that can be identified as the principal component.')
print('The Vector that can be identified as Principal Component is ')
print(fiveV)
print('\n')


print('Question 7: Create a learning (regression) model utilizing the principal component.')
P1=0.6778734
P2=0.73517866
sevenX=np.asarray([2.5,0.5,2.2,1.9,3.1,2.3,2,1,1.5,1.1])
sevenNewY=P1*sevenX+P2
print('New Y is computed by using the below formula: NewY= X*P1+P2 where P1 and P2 are Principal Components ')
print('P1 value is '+str(P1) + ' and P2 value is ' +str(P2))
print('New Y Computed Data Set is as follows ')
print(sevenNewY)
print('\n')

print('Question 8: Plot the graph y = f(x) representing this new model.')
print('New Graph y=f(x) is as follows ')
trainingData.plot(sevenX,sevenNewY,'ro')
trainingData.show()
print('\n')

print('Question 9: Use the model to test it for the unused, so far, data. What output the trained model will suggest for x = 2.5 and 5?')
print('New Graph When Considering x=2.5 and 5 is as follows ')
nineNewX=np.asarray([2.5,0.5,2.2,1.9,3.1,2.3,2,1,1.5,1.1,2.5,5])
nineNewY=P1*nineNewX+P2
trainingData.plot(nineNewX,nineNewY,'ro')
trainingData.show()
