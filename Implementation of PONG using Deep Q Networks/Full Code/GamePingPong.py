# PYGAME is used here to implement Ping Pong Game in Python
import pygame
# Random is used here to define the direction the ball is going to move
import random

# Variable initialization
# Below defines how fast the game is going to move 
FrameRatePerSecond = 60
# Window Size
HeightOfWindow = 400
WidthOfWindow = 400
# Paddle Size
HeightOfPaddle = 60
WidthOfPaddle = 10
DistanceFromWindow = 10
# Ball Size (Small Rectangle)
HeightOfBall = 10
WidthOfBall = 10
# Paddle and Ball Speed
SpeedOfPaddle = 2
SpeedOfBallInXDirection = 3
SpeedOfBallInYDirection = 2
# Colors for the Ping Pong Game
WhiteColor = (255,255,255)
BlackColor = (0,0,0)

# Game Screen Initialization
GameScreen = pygame.display.set_mode((WidthOfWindow,HeightOfWindow))

# Ball Initialization
def definePingPongBall(XPositionOfBall,YPositionOfBall):
	# Rect function of the PYGAME is used to draw a rectange (ball)
	PingPongBall = pygame.Rect(XPositionOfBall, YPositionOfBall, WidthOfBall, HeightOfBall)
	pygame.draw.rect(GameScreen, WhiteColor, PingPongBall)

# LeftPaddle Initialization - This Paddle learns by itself
def defineLeftPaddle(YPositionOfLeftPaddle):
	LeftPaddle = pygame.Rect(DistanceFromWindow, YPositionOfLeftPaddle, WidthOfPaddle, HeightOfPaddle )
	pygame.draw.rect(GameScreen, WhiteColor, LeftPaddle)

# RightPaddle Initialization = This will be the unbeatable paddle
def defineRightPaddle(YPositionOfRightPaddle):
	RightPaddle = pygame.Rect(WidthOfWindow - DistanceFromWindow - WidthOfPaddle, YPositionOfRightPaddle, WidthOfPaddle, HeightOfPaddle )
	pygame.draw.rect(GameScreen, WhiteColor, RightPaddle)

# Update the position of the ball 
def updatePingPongBall(YPositionOfLeftPaddle, YPositionOfRightPaddle,XPositionOfBall, YPositionOfBall, XDirectionOfBall, YDirectionOfBall):
	XPositionOfBall = XPositionOfBall + XDirectionOfBall * SpeedOfBallInXDirection
	YPositionOfBall = YPositionOfBall + YDirectionOfBall * SpeedOfBallInYDirection
	ScoreCounter = 0
	# If the ball hits the left window, then change the direction of the ball to right and update the ScoreCounter accordingly
	if (XPositionOfBall <= DistanceFromWindow + WidthOfPaddle and YPositionOfBall + HeightOfBall >= YPositionOfLeftPaddle and YPositionOfBall - HeightOfBall <= YPositionOfLeftPaddle + HeightOfPaddle):
		XDirectionOfBall = 1
	elif (XPositionOfBall <= 0):
		XDirectionOfBall = 1
		ScoreCounter = -1
		return[ScoreCounter, YPositionOfLeftPaddle, YPositionOfRightPaddle, XPositionOfBall, YPositionOfBall, XDirectionOfBall, YDirectionOfBall]
	# If the ball hits the right window, then change the direction of the ball to left and update the ScoreCounter accordingly
	if (XPositionOfBall >= WidthOfWindow - WidthOfPaddle - DistanceFromWindow and YPositionOfBall + HeightOfBall >= YPositionOfRightPaddle and YPositionOfBall - HeightOfBall <= YPositionOfRightPaddle + HeightOfPaddle):
		XDirectionOfBall = -1
	elif (XPositionOfBall >= WidthOfWindow - WidthOfBall):
		XDirectionOfBall = -1
		ScoreCounter = 1
		return[ScoreCounter, YPositionOfLeftPaddle, YPositionOfRightPaddle, XPositionOfBall, YPositionOfBall, XDirectionOfBall, YDirectionOfBall]
	# If the ball hits the top window, then change the direction of the ball to down
	if (YPositionOfBall <= 0):
		YPositionOfBall = 0
		YDirectionOfBall = 1
	# If the ball hits the bottom window, then change the direction of the ball to up
	elif (YPositionOfBall >= HeightOfWindow - HeightOfBall):
		YPositionOfBall = HeightOfWindow - HeightOfBall
		YDirectionOfBall = -1
	return[ScoreCounter, YPositionOfLeftPaddle, YPositionOfRightPaddle, XPositionOfBall, YPositionOfBall, XDirectionOfBall, YDirectionOfBall]

# Update the positon of the LeftPaddle
def updateLeftPaddle(action, YPositionOfLeftPaddle):
	# If the ball moves up, then move the positon of the left paddle up
	if(action[1] == 1):
		YPositionOfLeftPaddle = YPositionOfLeftPaddle - SpeedOfPaddle
	# If the ball moves down, then move the positon of the left paddle down
	if(action[2] == 2):
		YPositionOfLeftPaddle = YPositionOfLeftPaddle + SpeedOfPaddle
	# To make sure that the left paddle doesnt go out of the window
	if (YPositionOfLeftPaddle <0):
		YPositionOfLeftPaddle =0;
	if (YPositionOfLeftPaddle > HeightOfWindow - HeightOfPaddle):
		YPositionOfLeftPaddle = HeightOfWindow - HeightOfPaddle
	return YPositionOfLeftPaddle

# Update the position of the RightPaddle
def updateRightPaddle(YPositionOfRightPaddle, YPositionOfBall):
	# To move the right paddle down based on the position of the ball
	if(YPositionOfRightPaddle + HeightOfPaddle/2 < YPositionOfBall + HeightOfBall/2):
		YPositionOfRightPaddle = YPositionOfRightPaddle + SpeedOfPaddle
	# To move the right paddle up based on the position of the ball	
	if(YPositionOfRightPaddle + HeightOfPaddle/2 > YPositionOfBall + HeightOfBall/2):
		YPositionOfRightPaddle = YPositionOfRightPaddle - SpeedOfPaddle
	# To make sure that the right paddle doesnt go out of the window
	if(YPositionOfRightPaddle < 0):
		YPositionOfRightPaddle = 0;
	if(YPositionOfRightPaddle > HeightOfWindow - HeightOfPaddle):
		YPositionOfRightPaddle = HeightOfWindow - HeightOfPaddle
	return YPositionOfRightPaddle

#Class for the GamePingPong
class GamePingPong:
	def __int__(self):
		# Random will be made used to initilise the ball's initial direction
		randomNum = random.randint(0.9)
		# Tally will be used to keep track of the ScoreCounter
		self.tally = 0
		# Left and Right Paddle will be placed in the middle of the left and right window
		self.YPositionOfLeftPaddle = HeightOfWindow/2 - HeightOfPaddle/2
		self.YPositionOfRightPaddle = HeightOfWindow/2 - HeightOfPaddle/2
		# Initialize the Direction of the Ball
		self.XDirectionOfBall = 1
		self.YDirectionOfBall = 1
		# Initialize the Starting Point of the Ball
		self.XPositionOfBall = WidthOfWindow/2 - WidthOfBall/2

		# The below will decide the direction of the movement of the ball randomly
		if(0 < randomNum < 3):
			self.XDirectionOfBall = 1
			self.YDirectionOfBall = 1
		if(3 <= randomNum < 5):
			self.XDirectionOfBall = -1
			self.YDirectionOfBall = 1
		if(5 <= randomNum < 8):
			self.XDirectionOfBall = 1
			self.YDirectionOfBall = -1
		if(8 <= randomNum < 10):
			self.XDirectionOfBall = -1
			self.YDirectionOfBall = -1
		randomNum = random.randint(0,9)
		self.YPositionOfBall = randomNum * (HeightOfWindow - HeightOfBall)/9

	# Gives the present frame at which we are currently at
	def returnPresentFrameInformation(self):
		pygame.event.pump()
		# Fill the screen with black color
		GameScreen.fill(BlackColor)
		# Define the Left Paddle, Right Paddle and the PingPong Ball by calling their respective functions
		defineLeftPaddle(self.YPositionOfLeftPaddle)
		defineRightPaddle(self.YPositionOfRightPaddle)
		definePingPongBall(self.XPositionOfBall, self.YPositionOfBall)
		# Get the pixel information of the frame and store it in a three dimension array
		pixelDataOfFrame = pygame.surfarray.array3d(pygame.display.get_surface())
		# Below is used to update the window
		pygame.display.flip()
		# Return the pixel information
		return pixelDataOfFrame

	# Gives the next frame
	def returnNextFrameInformation(self, action):
		pygame.event.pump()
		# Initialise the ScoreCounter with 0
		ScoreCounter = 0
		# Fill the screen with black color
		GameScreen.fill(BlackColor)
		# Define the Left Paddle, Right Paddle and the PingPong Ball by calling their respective functions
		self.YPositionOfLeftPaddle = updateLeftPaddle(action, self.YPositionOfLeftPaddle)
		defineLeftPaddle(self.YPositionOfLeftPaddle)
		self.YPositionOfRightPaddle = updateRightPaddle(self.YPositionOfRightPaddle, self.YPositionOfBall)
		defineRightPaddle(self.YPositionOfRightPaddle)
		[ScoreCounter, self.YPositionOfLeftPaddle, self.YPositionOfRightPaddle, self.XPositionOfBall, self.YPositionOfBall, self.XDirectionOfBall, self.YDirectionOfBall] = updatePingPongBall(self.YPositionOfLeftPaddle, self.YPositionOfRightPaddle, self.XPositionOfBall, self.YPositionOfBall, self.XDirectionOfBall, self.YDirectionOfBall)
		definePingPongBall(self.XPositionOfBall, self.YPositionOfBall)
		# Get the pixel information of the frame and store it in a three dimension array
		pixelDataOfFrame = pygame.surfarray.array3d(pygame.display.get_surface())
		# Below is used to update the window
		pygame.display.flip()
		self.tally = self.tally + ScoreCounter
		print("Final Score: " + str(self.tally))
		# Return the pixel information and ScoreCounter 
		return pixelDataOfFrame		
