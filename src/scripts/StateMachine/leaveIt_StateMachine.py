from leaveIt_states import StartupState, IdleState

class StateMachine(object):

	def __init__(self):
		self.state = StartupState()
		self.state = IdleState()

   #Stateswitching functies, elke functie wordt doorgegeven aan de huidige state
	def takePictureOf(self,camera,plant):
		self.state = self.state.takePictureOf(camera,plant)

	def goIdle(self):
		self.state = self.state.goIdle()
