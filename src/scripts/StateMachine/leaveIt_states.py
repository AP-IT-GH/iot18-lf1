from state import State

#Elke State is een klasse met zelfde functies (zoals takePictureOf & goIdle, enkel anders ingevuld
class StartupState(State):

	def __init__(self):
		print 'Startup State loaded'

	def takePictureOf(self,camera,plant):
		pass

	def goIdle(self):
		return IdleState()



class IdleState(State):
	def __init__(self):
	#Constructor, steek hier de logica die uitgevoerd moet worden
		State.__init__(self)

		ActiveComponents = [0,1,2,3,4,5,6,7] #TODO: Documenteren wat deze getalletjes betekenen -> getallen voor bordjes in/uit te schakelen
		InactiveComponents = [8,9,10,11]

   #Logica voor stateswitching:
	def takePictureOf(self, camera, plant):
		return TakingPictureState(camera,plant)

	def goIdle(self):
		return self


class TakingPictureState(State):

	def __init__(self, camera, plant):
	#Constructor, steek hier de logica die uitgevoerd moet worden
	#vb.: TakePicture subroutine uitvoeren
		State.__init__(self)
		self.camera = camera
		self.plant = plant
		print 'Taking picture on row {0} of plant {1}'.format(camera,plant)
		ActiveComponents = [0,1,2,3,camera+3,7,8,camera+8]
		InactiveComponents = []
   #Logica voor stateswitching:
	def takePictureOf(self, camera, plant):
		return self

	def goIdle(self):
		return IdleState()


