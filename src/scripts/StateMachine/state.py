class State(object):

	def __init__(self):
		print 'Switching to state:', str(self)

	def __repr__(self):
		return self.__str__()

	def __str__(self):
		return self.__class__.__name__
 
