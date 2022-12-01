from counter import Counter

class Clock:
    SEC_LIMIT = 60
    MIN_LIMIT = 60
    HOUR_LIMIT = 24
    list_Of_Counter = []
    def __init__(self):
        for i in range(3):
            counter_name = "Counter " + str(i)
            counter = Counter(counter_name)
            self.list_Of_Counter.append(counter)

    def Tick(self):
        self.list_Of_Counter[2].Increment()

        if self.list_Of_Counter[2].Tick() == self.SEC_LIMIT:
            self.list_Of_Counter[2].Reset()
            self.list_Of_Counter[1].Increment()

        if self.list_Of_Counter[1].Tick() == self.MIN_LIMIT:
            self.list_Of_Counter[1].Reset()
            self.list_Of_Counter[0].Increment()

        if self.list_Of_Counter[0].Tick() == self.HOUR_LIMIT:
            self.list_Of_Counter[0].Reset()

    def TimePrinting(self):
        hour = str(self.list_Of_Counter[0].Tick()).rjust(2, '0')
        minute = str(self.list_Of_Counter[1].Tick()).rjust(2, '0')
        second = str(self.list_Of_Counter[2].Tick()).rjust(2, '0')
        time = hour + ":" + minute + ":" + second
        print("Current time: " + time)
        return
