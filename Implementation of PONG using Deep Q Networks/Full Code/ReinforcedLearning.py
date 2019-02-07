# Importing the necessary libraries 
# Making use of tensorflow
import tensorflow
# Making use of Open CV
import cv2
# The Class which we created 
#import GamePingPong 
import PongNew
import numpy 
import random
# All the experiences will be stored in this data structure
from collections import deque

# Hyperparameters are Defined here
# There are three possible actions - Up, Down and Stay
ACTIONS = 3 
# Learning rate is defined below
GAMMA = 0.99
# Setting the initial and final epsilon values
INITIAL_EPSILON = 1.0
FINAL_EPSILON = 0.05
# Number of frames for observation and exploration
EXPLORE = 500000
OBSERVE = 50000
# The following will be stored as experiences 
REPLAY_MEMORY = 500000
# Batch Sixe - How many times we are going to train
BATCH = 100

# We are going to create a Tensorflow Graph
def tensorFlowGraph():
	# This is a CNN - Convolution Neural Network
	# We will feed Pixel Data and ScoreCounter into this neural network
	# Our Model has five layers. These layers are defined below

	# First Layer
	weight_CL1 = tensorflow.Variable(tensorflow.zeros([8,8,4,32]))
	bias_CL1 = tensorflow.Variable(tensorflow.zeros([32]))

	# Second Layer
	weight_CL2 = tensorflow.Variable(tensorflow.zeros([4,4,32,64]))
	bias_CL2 = tensorflow.Variable(tensorflow.zeros([64]))

	# Third Layer
	weight_CL3 = tensorflow.Variable(tensorflow.zeros([3,3,64,64]))
	bias_CL3 = tensorflow.Variable(tensorflow.zeros([64]))

	# Fourth Layer - Fully Connected Layer
	weight_FC4 = tensorflow.Variable(tensorflow.zeros([3136, 784]))
	bias_FC4 = tensorflow.Variable(tensorflow.zeros([784]))

	# Fifth Layer - Fully Connected Layer
	weight_FC5 = tensorflow.Variable(tensorflow.zeros([784,ACTIONS]))
	bias_FC5 = tensorflow.Variable(tensorflow.zeros([ACTIONS]))

	# Feed the Pixel Data into this input
	ip = tensorflow.placeholder("float",[None,84,84,4])

	#Every layer we will perform ReLU function
	CL1 = tensorflow.nn.relu(tensorflow.nn.conv2d(ip, weight_CL1, strides=[1,4,4,1], padding = "VALID") + bias_CL1)
	CL2 = tensorflow.nn.relu(tensorflow.nn.conv2d(CL1, weight_CL2, strides=[1,2,2,1], padding = "VALID") + bias_CL2)
	CL3 = tensorflow.nn.relu(tensorflow.nn.conv2d(CL2, weight_CL3, strides=[1,1,1,1], padding = "VALID") + bias_CL3)
	CL3_Reshape = tensorflow.reshape(CL3,[-1,3136])
	FC4 = tensorflow.nn.relu(tensorflow.matmul(CL3_Reshape, weight_FC4) + bias_FC4)
	FC5 = tensorflow.matmul(FC4,weight_FC5) + bias_FC5
	return ip, FC5

def deepQNetworkGrapTraining(ip, op, session):
	argmax = tensorflow.placeholder("float",[None,ACTIONS])
	groundTruth = tensorflow.placeholder("float",[None])
	action = tensorflow.reduce_sum(tensorflow.multiply(op, argmax), reduction_indices=1)
	costFunction = tensorflow.reduce_mean(tensorflow.square(action - groundTruth))
	training_step = tensorflow.train.AdamOptimizer(1e-6).minimize(costFunction)
	ppGame = PongNew.PingPong()
	Deque = deque()
	gameFrame = ppGame.returnPresentFrameInformation()
	gameFrame = cv2.cvtColor(cv2.resize(gameFrame, (84,84)), cv2.COLOR_BGR2GRAY)
	ret, gameFrame = cv2.threshold(gameFrame,1,255,cv2.THRESH_BINARY)
	inputTensor = numpy.stack((gameFrame, gameFrame, gameFrame, gameFrame), axis=2)
	saver = tensorflow.train.Saver()
	session.run(tensorflow.initialize_all_variables())
	t = 0
	epsilonValue = INITIAL_EPSILON
	while(1):
		outputTensor = op.eval(feed_dict={ip:[inputTensor]})[0]
		argmaxTensor = numpy.zeros([ACTIONS])
		
		if(random.random() <= epsilonValue):
			maxIndex = random.randrange(ACTIONS)
		else:
			maxIndex = numpy.argmax(outputTensor)
		argmaxTensor[maxIndex] =1

		if(epsilonValue > FINAL_EPSILON):
			epsilonValue -= (INITIAL_EPSILON - FINAL_EPSILON)/EXPLORE

		rewardTensor, gameFrame = ppGame.returnNextFrameInformation(argmaxTensor)
		gameFrame = cv2.cvtColor(cv2.resize(gameFrame, (84,84)), cv2.COLOR_BGR2GRAY)
		ret, gameFrame = cv2.threshold(gameFrame,1,255,cv2.THRESH_BINARY)
		gameFrame = numpy.reshape(gameFrame,(84,84,1))
		inputTensorNew = numpy.append(gameFrame, inputTensor[:,:,0:3], axis=2)
		Deque.append((inputTensor, argmaxTensor, rewardTensor, inputTensorNew))

		if len(Deque)>REPLAY_MEMORY:
			Deque.popleft()

		if(t>OBSERVE):
			newBatch = random.sample(Deque,BATCH)
			inputBatch = [a[0] for a in newBatch]
			argBatch = [a[1] for a in newBatch]
			rewardBatch = [a[1] for a in newBatch]
			inputTensorNewBatch = [a[1] for a in newBatch]
			groundTruthBatch =[]
			outputBatch = op.eval(feed_dict={ip:inputTensorNewBatch})

			for i in range(0, len(newBatch)):
				groundTruthBatch.append(rewardBatch[i]+ GAMMA * numpy.max(outputBatch[i]))

			training_step.run(feed_dict={groundTruth: groundTruthBatch, argmax:argBatch, ip:inputBatch})

		inputTensor = inputTensorNew
		t=t+1

		if(t%10000==0):
			saver.save(session,'./'+'pong'+'-dqn',globalStep = t)
		print("TIMESTEP", t, "/ EPSILON", epsilonValue, "/ ACTION", maxIndex, "/ REWARD", rewardTensor, "/ Q_MAX %e" % numpy.max(outputTensor))

def main():
	session = tensorflow.InteractiveSession()
	ip,op = tensorFlowGraph()
	deepQNetworkGrapTraining(ip,op,session)

if __name__ == "__main__":
	main()
