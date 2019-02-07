# -*- coding: utf-8 -*-
"""
Created on Thu Sep 27 20:29:53 2018

@author: akshatha
"""
from keras.models import Sequential 
import matplotlib.pyplot as plt 
from keras.layers import Dense
from keras.optimizers import Adam
import numpy as np

#Training Data
#Training Data
x1 = np.multiply(np.random.random([1000]),10)
x2 = np.multiply(np.random.random([1000]),10)
y1 = np.add(np.add(pow(x1,2),x2),5)
y2 = np.add((np.add(pow(x1,3),x2)),6)
X_train=np.stack((x1,x2)).T
Y_train=np.stack((y1,y2)).T

#creating layers for the model
model=Sequential()
model.add(Dense(8,input_shape=(2,),activation='relu'))
model.add(Dense(4,activation='relu'))
model.add(Dense(2))
model.summary()

#for compiling the model
model.compile(loss='mean_squared_error',optimizer=Adam(lr=0.003), metrics=['accuracy'])
#for training the model
history=model.fit(Y_train,X_train,epochs=10)

#testing
#
#Training Data
xt_1 = np.multiply(np.random.random([1000]),10)
xt_2 = np.multiply(np.random.random([1000]),10)
yt_1 = np.add(np.add(pow(x1,2),x2),5)
yt_2 = np.add((np.add(pow(x1,3),x2)),6)

Y_test=np.stack((yt_1,yt_2)).T
print(Y_test)


tes=model.predict(Y_test)
print(tes)


def plot_loss_accuracy(history):
    fig = plt.figure(figsize=(12, 6))
    ax = fig.add_subplot(1, 2, 1) 
    ax.plot(history.history["loss"],'r-x', label="Train Loss")
    ax.legend() 
    ax.set_title('Training loss') 
    ax.grid(True)
    
plot_loss_accuracy(history)