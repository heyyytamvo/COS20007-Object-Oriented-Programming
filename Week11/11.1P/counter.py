from itertools import count


class Counter:
    def __init__(self, name):
        self.name = name
        self.count = 0

    def Increment(self):
        self.count += 1
    
    def Reset(self):
        self.count = 0

    def Name(self):
        return self.name

    def Tick(self):
        return self.count
    
    

