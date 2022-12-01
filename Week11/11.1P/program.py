from clock import Clock
import time
import os

def clear_console():
    os.system('clear')

myClock = Clock()

while True:
    clear_console()
    myClock.Tick()
    myClock.TimePrinting()
    time.sleep(1)
    

