from core.groups.squad import Squad
from core.structure.base.hero import Hero

class Battlefield:
    def __init__(self, size: int):
        self.__size = max(size, 1)
        self.__s1 = Squad(self.__size)
        self.__s2 = Squad(self.__size)

    def fight(self) -> None:
        step = 1
        while self.__s1.any_alive() and self.__s2.any_alive():
            print(f"\nStep: {step}")
            h1: Hero = self.__s1.get_hero()
            h2: Hero = self.__s2.get_hero()
            attack = h1.make_attack()
            print(h1, attack, ">>>", h2)
            h2.take_damage(attack)
            print(h1, " ", h2)
            if h1.is_alive and h2.is_alive:
                attack = h2.make_attack()
                print(h1, "<<<", attack, h2)
                h1.take_damage(attack)
                print(h1, " ", h2)
            step += 1
            input("Press Enter to continue...")
        print(f"\nSquad {1 if self.__s1.any_alive() else 2} Win!")
        print("\nSquad 1\n", self.__s1, sep="")
        print("\nSquad 2\n", self.__s2, sep="")
